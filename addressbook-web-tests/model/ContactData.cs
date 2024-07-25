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

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        public string MiddleName
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }
        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public string TelephoneHome
        {
            get
            {
                return telephoneHome;
            }
            set
            {
                telephoneHome = value;
            }
        }
        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value;
            }
        }
        public string Telwork
        {
            get
            {
                return telwork;
            }
            set
            {
                telwork = value;
            }
        }
        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string HomePage
        {
            get
            {
                return homePage;
            }
            set
            {
                homePage = value;
            }
        }
        public string Bday
        {
            get
            {
                return bday;
            }
            set
            {
                bday = value;
            }
        }
        public string Bmonth
        {
            get
            {
                return bmonth;
            }
            set
            {
                bmonth = value;
            }
        }
        public string Byear
        {
            get
            {
                return byear;
            }
            set
            {
                byear = value;
            }
        }
        public string Group
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
            }
        }
    }
}
