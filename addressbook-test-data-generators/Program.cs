using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Addressbook_web_tests;
using Newtonsoft.Json;

namespace Addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {

            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];

            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(20))
                {
                    Header = TestBase.GenerateRandomString(20),
                    Footer = TestBase.GenerateRandomString(20)
                }); 
            }
            if (format == "csv")
            {
                writeGroupsToCsv(groups, writer);
            } 
            else if (format == "xml")
            {
                writeGroupsToXmlFile(groups, writer);
            }
            else if (format == "json")
            {
                writeGroupsToJSonFile(groups, writer);
            }
            else 
            {
                System.Console.Out.Write("Unrecognized format "+ format);
            }

            writeGroupsToCsv(groups, writer);
            writer.Close();
        }
        static void writeGroupsToCsv(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(string.Format("${0},${1},${2}",
                    group.Name, group.Footer, group.Header));
            }

        }
        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }
        static void writeGroupsToJSonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

    }
}

