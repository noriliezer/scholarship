namespace scholarship
{
    public static partial class Session
    {
        public static int StudentId { get; set; }
        public static string Role { get; set; }     // "Admin" | "Student"
        public static string FullName { get; set; }

        public static void Clear()
        {
            StudentId = 0;
            Role = null;
            FullName = null;
        }
    }
}