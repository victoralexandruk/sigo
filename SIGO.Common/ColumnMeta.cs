using System;

namespace SIGO.Common
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
                    case "int":
                        return "INT";
                    case "long":
                        return "BIGINT";
                }
                return "NVARCHAR(max)";
            }
        }
    }
}
