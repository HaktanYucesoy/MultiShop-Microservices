namespace MultiShop.Discount.Constables.Queries
{
    public static class PureSQLQueryCreator
    {

        public static string CreateInsertQuery(string tableName, string[] fields, string[] parameters)
        {
            string query = $"INSERT INTO {tableName} ({string.Join(", ", fields)}) VALUES ({string.Join(", ", parameters)})";
            return query;
        }


        public static string CreateUpdateQuery(string tableName, string[] fields, string[] parameters, string[] whereFields, string[] whereParameters)
        {
            string query = $"UPDATE {tableName} SET {string.Join(", ", fields.Zip(parameters, (f, p) => $"{f} = {p}"))} WHERE {string.Join(" AND ", whereFields.Zip(whereParameters, (f, p) => $"{f} = {p}"))}";
            return query;
        }

       

        public static string CreateSelectConditionQuery(string tableName, string[] fields, string[] whereFields, string[] whereParameters)
        {
            string query = $"SELECT {string.Join(", ", fields)} FROM {tableName} WHERE {string.Join(" AND ", whereFields.Zip(whereParameters, (f, p) => $"{f} = {p}"))}";
            return query;
        }

        public static string CreateSelectWithSelectedFielsQuery(string tableName, string[] fields)
        {
            string query = $"SELECT {string.Join(", ", fields)} FROM {tableName}";
            return query;
        }

        public static string CreateSelectAllQuery(string tableName)
        {
            string query = $"SELECT * FROM {tableName}";
            return query;
        }

        public static string CreateSelectById(string tableName, string fieldId, string parameterId)
        {
            string query = $"SELECT * FROM {tableName} WHERE ${fieldId}=${parameterId}";
            return query;
        }

        public static string CreateDeleteQuery(string tableName,string fieldId,string parameterId)
        {
            string query = $"DELETE FROM {tableName} WHERE {fieldId}={parameterId}";
            return query;
        }


    }
}
