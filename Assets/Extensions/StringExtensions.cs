namespace Assets.Extensions
{
    public static class StringExtensions
    {
        public static string ToFormat(this string s, params object[] p)
        {
            return string.Format(s, p);
        }

        public static bool IsEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static bool IsNotEmpty(this string s)
        {
            return !s.IsEmpty();
        }
    }
}
