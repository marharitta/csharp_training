using System;
using System.Collections.Generic;
using System.IO;
//using System.Text;
using NUnit.Framework;

namespace mantis_tests

{

    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [OneTimeSetUp]
        public void setUpConfig()
        {
            app.Ftp.BackupFile("/config_defaults_inc.php");
            using (Stream localFile = File.Open("/config_defaults_inc.php",FileMode.Open))
            {
                app.Ftp.Upload("/config_defaults_inc.php", localFile);
            }
            app.Ftp.Upload("/config_defaults_inc.php", null);
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

            Assert.That(true == true);
        }

        [OneTimeTearDown]
        public void restoreCongig()
        {
            app.Ftp.RestoreBackupFile("/config_defaults_inc.php");
        }
    }
}
