

using System.Diagnostics;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"group.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>)
                new XmlSerializer(typeof(List<GroupData>))
                    .Deserialize(new StreamReader(@"groups.xml"));

        }
        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {

            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));

        }

        [Test, TestCaseSource("GroupDataFromJsonFile")] //"RandomGroupDataProvider"
        public void GroupCreationTest(GroupData group)
        {

            List<GroupData> oldGroups = GroupData.GetAll();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }


        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Footer = "";
            group.Header = "";

            List<GroupData> oldGroups = GroupData.GetAll();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count,GroupData.GetAll().Count);

            List<GroupData> newGroups = GroupData.GetAll();;
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreNotEqual(oldGroups, newGroups);
        }

        [Test]
        public void TestDBConnectivity()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<GroupData> fromUi = app.Groups.GetGroupList();
            System.Console.Out.WriteLine(stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            List<GroupData> fromDb = GroupData.GetAll();
            System.Console.Out.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        [Test]
        public void TestDBConnectivityNew()
        {
            foreach (ContactData  contact in GroupData.GetAll()[0].GetContacts())
            {
                System.Console.Out.WriteLine(contact);
            }
        }
    }
}

