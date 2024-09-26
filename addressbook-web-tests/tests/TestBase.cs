
using System.Text;

namespace Addressbook_web_tests
{
    public  class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECK = true;

        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();

        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble()*max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32+ Convert.ToInt32(rnd.NextDouble() * 65)));
            }

            return builder.ToString();
        }

        public static string GenerateEngNumRandomString(int max)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 ";
            var random = new Random();

            var stringChars = new char[random.Next(max/2, max)];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }
    }
}
