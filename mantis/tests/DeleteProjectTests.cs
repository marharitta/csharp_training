using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis
{
    public class DeleteProjectTests : TestBase
    {
        [Test]
        public void TestProjectDelete()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "newPass",

            };

            app.Project.LogInMantis(account);
            app.Project.DeleteProject(2);//придумать как вычислить айдишник
        }

    }
}
