using System;
using System.Collections.Generic;
using System.IO;
//using System.Text;
using NUnit.Framework;

namespace mantis

{

    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [OneTimeSetUp]
        public void setUpConfig()
        {
            var baseFolder = AppDomain.CurrentDomain.BaseDirectory;
            app.Ftp.BackupFile("/mantis/config_defaults_inc.php");
            using (Stream localFile = File.Open(Path.Combine(baseFolder, "config_defaults_inc.php"), FileMode.Open))
            {
                app.Ftp.Upload("/mantis/config_defaults_inc.php", localFile);
            }

//            app.Ftp.Upload("/mantis/config_defaults_inc.php", null);
        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password ="password",
                Email = "testuser@localhost.localdomain"
            };
            app.Registration.Register(account);

        }

        [OneTimeTearDown]
        public void restoreCongig()
        {
            app.Ftp.RestoreBackupFile("/mantis/config_defaults_inc.php");
        }
    }
}
