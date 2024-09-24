﻿using LinqToDB.Mapping;

namespace Addressbook_web_tests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public GroupData()
        {
        }
        public GroupData(string name)
        {
            this.Name = name;
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(this, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name + "\nHeader= " + Header + "\nfooter= " + Footer;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }
        
        [Column (Name = "group_name")]
        public string Name { get; set; }

        [Column(Name = "group_header")]

        public string Header { get; set; }

        [Column(Name = "group_footer")]
        public string Footer { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }
        
        public List<ContactData> GetContacts ()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts
                            from gcr in db.GCR.Where(p => p.GroupId == Id && p.ContactId == c.Id && (c.Deprecated == null || c.Deprecated == "0000-00-00 00:00:00"))
                                select c).Distinct().ToList();
            }
        }

        public static GroupData GetOneByIndex(int index)
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups orderby g.Id ascending select g).Skip(index).Take(1).FirstOrDefault();
            }
        }

        public static GroupData GetOneWithContacts()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups join cdr in db.GCR on g.Id equals cdr.GroupId orderby g.Id ascending select g).Take(1).FirstOrDefault();
            }
        }
    }
}
