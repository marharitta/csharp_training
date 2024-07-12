﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook_web_tests
{
    public class AuthTestBase: TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            app.Auth.LogIn(new AccountData("admin", "secret"));

        }
    }
}
