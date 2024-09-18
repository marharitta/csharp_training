﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace Addressbook_web_tests
{
    public class AddressBookDB : LinqToDB.Data.DataConnection
    {
        public AddressBookDB() : base(ProviderName.MySql, @"server=localhost; database=addressbook; port=3306; Uid=root; Pwd=; charset=utf8; Allow Zero Datetime=true")
        {
        }

        public ITable<GroupData> Groups { get { return this.GetTable<GroupData>(); } }
        public ITable<ContactData> Contacts{ get { return this.GetTable<ContactData>(); } }
    }
}
