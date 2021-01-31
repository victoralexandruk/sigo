using System;

namespace SIGO.Common.Data
{
    class ColumnMeta
    {
        public string PropertyName { get; set; }
        public Type PropertyType { get; set; }
        public string ColumnName { get; set; }
        public string ColumnType
        {
            get
            {
                switch (PropertyType.Name)
                {
                    case "Int32":
                        return "INT";
                    case "long":
                        return "BIGINT";
                    case "DateTime":
                        return "DATETIME2(7)";
                }
                return "NVARCHAR(MAX)";
            }
        }
    }
}
