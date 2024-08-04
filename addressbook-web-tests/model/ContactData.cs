using System.Xml.Linq;

namespace Addressbook_web_tests
{
    public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName = "";
        private string middlename = "";
        private string lastname = "";
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string telephoneHome = "";
        private string mobile  = "";
        private string telwork = "";
        private string fax   = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homePage = "";
        private string bday = "";
        private string bmonth = "";
        private string byear = "";
        private string group = "";

        private string allPhones;

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(this, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public int GetHashCode()
        {
            return $"{FirstName}{LastName}".GetHashCode();

        }

        public override string ToString()
        {
            return "name=" + FirstName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            else
            {
                int lastNameCompareResult = LastName.CompareTo(other.LastName);
                if (lastNameCompareResult != 0)
                {
                    return lastNameCompareResult;
                }

                return FirstName.CompareTo(other.FirstName);
            }
        }
        public ContactData() { }
        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
           
        }
        public string Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
 
        public string MiddleName { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string TelephoneHome { get; set; }
        public string Mobile { get; set; }
        public string Telwork { get; set; }
        public string AllPhones 
        {
            get
            {
                if (allPhones != null)
                { return allPhones; }
                else { return CleanUp( TelephoneHome) + CleanUp(Mobile ) + CleanUp(Telwork).Trim(); }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "")+ "\r\n";
        }

        public string Fax { get; set; }
        public string Email { get; set; }
        public string HomePage { get; set; }
        public string Bday { get; set; }
        public string Bmonth { get; set; }
        public string Byear { get; set; }
        public string Group { get; set; }
    }
}
