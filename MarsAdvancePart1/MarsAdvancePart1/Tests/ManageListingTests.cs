using MarsAdvancePart1.Steps;
using MarsAdvancePart1.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancePart1.Tests
{
    [TestFixture]
    public class ManageListingTests : GlobalHelper
    {
        private LoginSteps loginSteps;
        private HomePageSteps homePageSteps;
        private ManageListingSteps manageListingSteps;

        public ManageListingTests()
        {
            loginSteps = new LoginSteps();
            homePageSteps = new HomePageSteps();
            manageListingSteps = new ManageListingSteps();
        }

        [Test]
        public void UpdateManageListingTests()
        {
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();
            homePageSteps.ClickOnManageListingTab();

            manageListingSteps.UpdateShareSkillSteps();
        }

    }
}
