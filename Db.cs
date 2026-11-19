using Microsoft.Data.SqlClient;

namespace ScholarshipApp
{
    public static class Db
    {
        private const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=scholarship_db;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection Open()
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        public static int Execute(string sql, params (string Name, object Value)[] parameters)
        {
            using var conn = Open();
            using var cmd = Build(conn, sql, parameters);
            return cmd.ExecuteNonQuery();
        }

        public static object Scalar(string sql, params (string Name, object Value)[] parameters)
        {
            using var conn = Open();
            using var cmd = Build(conn, sql, parameters);
            return cmd.ExecuteScalar();
        }

        public static object NullIfEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? (object)DBNull.Value : value;
        }

        public static string Str(SqlDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? "" : reader.GetValue(index).ToString();
        }

        public static string Friendly(SqlException ex)
        {
            return ex.Number switch
            {
                2627 or 2601 => "That value already exists. Use a unique value.",
                547 => "This record is linked to other records (for example, applications), so that action can't be done.",
                _ => "Database error: " + ex.Message
            };
        }

        private static SqlCommand Build(SqlConnection conn, string sql, (string Name, object Value)[] parameters)
        {
            var cmd = new SqlCommand(sql, conn);
            foreach (var p in parameters)
            {
                cmd.Parameters.AddWithValue(p.Name, p.Value);
            }
            return cmd;
        }
    }
}