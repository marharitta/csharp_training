
using System.Text;

namespace Addressbook_web_tests
{
    public static class StringBuilderHelper
    {
        public static string Append(this string builder, string? data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return builder;
            }

            data = data.Trim();
            if (builder.Length > 0)
            {
                builder += " ";
            }

            builder += data;
            return builder;
        }

        public static string AppendSafeWithNewLine(this string builder, string? data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return builder;
            }

            data = data.Trim();
            builder = builder.AppendLine() + data;
            return builder;
        }

        public static string AppendLine(this string builder)
        {
            if (builder.Length > 0)
            {
                builder = builder + Environment.NewLine;
            }

            return builder;
        }
    }
}
