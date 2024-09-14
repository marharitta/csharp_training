using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
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
            string filename = args[1];
            string format = args[2];
            string datatype = args[3];

            if( datatype == "group")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(20))
                    {
                        Header = TestBase.GenerateRandomString(20),
                        Footer = TestBase.GenerateRandomString(20)
                    }); 
                }

                if (format == "excel")
                {
                   // writeGroupsToExcel(groups, filename);
                }
                else
                {
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
                    writer.Close();
                }
            }
            else if (datatype == "contact")
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(20), TestBase.GenerateRandomString(20))
                    {
                        Nickname = TestBase.GenerateRandomString(20),
                        Address = TestBase.GenerateRandomString(20),
                        TelephoneHome = TestBase.GenerateRandomString(20),
                    });
                }

                if (format == "json")
                {
                    writeContactsToJSonFile(contacts, writer);
                }
                else 
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }
            }

           writer.Close();
        }

        static void writeContactsToJSonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

/*        static void writeGroupsToExcel(List<GroupData> groups, string filenamev)
        {
            throw new NotImplementedException();
        }
*/
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

