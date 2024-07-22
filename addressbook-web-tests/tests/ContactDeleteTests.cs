using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactDeleteTests: AuthTestBase
    {
        [Test]
        public void DeleteContactTest()
        {
            List<ContactData> oldContact = app.Contact.GetContactList();

            app.Contact.Remove(0);

            List<ContactData> newContact = app.Contact.GetContactList();

            oldContact.RemoveAt(0);
            Assert.AreEqual(oldContact, newContact);

        }
    }
}
