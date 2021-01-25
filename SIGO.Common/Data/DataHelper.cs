using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SIGO.Common.Data
{
    public static class DataHelper
    {
        public static bool TableExists(IDbConnection db, string name)
        {
            return db.QuerySingleOrDefault<bool>($"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = '{name}'");
        }

        public static void CreateTableIfNotExists<T>(IDbConnection db, string table, string seedFilepath = "")
        {
            if (!TableExists(db, table))
            {
                var columns = GetColumns<T>();
                var sql = $@"CREATE TABLE {table} ([Id] [bigint] IDENTITY(1,1) NOT NULL, {string.Join(",", columns.Select(a => $"[{a.ColumnName}] {a.ColumnType}"))})";
                db.Execute(sql);
                if (!string.IsNullOrWhiteSpace(seedFilepath) && File.Exists(seedFilepath))
                {
                    string json = File.ReadAllText(seedFilepath);
                    IEnumerable<T> data = JsonConvert.DeserializeObject<IEnumerable<T>>(json);
                    data.AsList().ForEach(a => Insert(db, table, a));
                }
            }
        }

        public static long Insert(IDbConnection db, string table, object model)
        {
            var columns = GetColumns(model.GetType());
            var sql = $"INSERT INTO {table} ({string.Join(",", columns.Select(a => $"[{a.ColumnName}]"))}) VALUES ({string.Join(",", columns.Select(a => $"@{a.PropertyName}"))}); SELECT SCOPE_IDENTITY()";
            return db.QuerySingleOrDefault<long>(sql, model);
        }

        public static void Update(IDbConnection db, string table, object model)
        {
            var columns = GetColumns(model.GetType());
            var sql = $"UPDATE {table} SET {string.Join(",", columns.Select(a => $"[{a.ColumnName}] = @{a.PropertyName}"))} WHERE Id = @Id";
            db.Execute(sql, model);
        }

        public static IEnumerable<T> SearchByObject<T>(IDbConnection db, string table, object where, bool strict = true)
        {
            var json = JsonConvert.SerializeObject(where);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            return Search<T>(db, table, dictionary, strict);
        }

        public static IEnumerable<T> Search<T>(IDbConnection db, string table, IDictionary<string, object> where, bool strict = true)
        {
            var sql = $"SELECT * FROM {table} WITH(NOLOCK) WHERE {string.Join(",", where.Select(a => strict ? $"{a.Key} = @{a.Key}" : $"{a.Key} LIKE CONCAT('%', @{a.Key}, '%')"))}";
            return db.Query<T>(sql, where);
        }

        private static List<ColumnMeta> GetColumns<T>()
        {
            return GetColumns(typeof(T));
        }

        private static List<ColumnMeta> GetColumns(Type type)
        {
            List<ColumnMeta> columns = new List<ColumnMeta>();
            foreach (var field in type.GetProperties())
            {
                ColumnAttribute columnAttribute = field.GetCustomAttribute<ColumnAttribute>();
                if (columnAttribute != null)
                {
                    columns.Add(new ColumnMeta
                    {
                        PropertyName = field.Name,
                        PropertyType = field.GetType(),
                        ColumnName = columnAttribute.Name ?? field.Name
                    });
                }
            }
            return columns;
        }
    }
}
