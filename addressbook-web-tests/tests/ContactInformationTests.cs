using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactInformationTests: AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            // verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromForm.Address, fromTable.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }
        [Test]
        public void TestContactInformationGlue()
        {
            ContactData datafromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData dataFromForm = app.Contacts.GetContactInformationFromEditForm(0);

            string fromTable = app.Contacts.Glue(datafromTable);
            string fromForm = app.Contacts.Glue(dataFromForm);

            // verification
            Assert.AreEqual(fromTable, fromForm);
        }


        [Test]
        public void TestDetailContactInformation()
        {
            string fromProperty = app.Contacts.GetContactInformationFromProperty(0);
            ContactData dataFromForm = app.Contacts.GetContactInformationFromEditForm(0);

            string fromForm = app.Contacts.Glue(dataFromForm);

            // verification
            Assert.AreEqual(fromProperty, fromForm);
        }
    }
}
