namespace POC.ASKBLUE.LIBRARY.CORE.Tools
{
    public static class StringUtils
    {
        public static string IsOnlyNumber(this string str, string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }
    }
}
