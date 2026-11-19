namespace scholarship
{
    public static class Session
    {
        public static int AdminId { get; set; }
        public static string Username { get; set; }

        public static string StudentId { get; set; }   // ← MUST be string
        public static string StudentName { get; set; }
        public static string Role { get; set; }

        public static void Clear()
        {
            AdminId = 0;
            Username = null;
            StudentId = null;
            StudentName = null;
            Role = null;
        }
    }
}