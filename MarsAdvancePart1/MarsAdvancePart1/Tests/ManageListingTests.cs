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
        private ShareSkillAddSteps shareSkillAddSteps;

        public ManageListingTests()
        {
            loginSteps = new LoginSteps();
            homePageSteps = new HomePageSteps();
            manageListingSteps = new ManageListingSteps();
            shareSkillAddSteps = new ShareSkillAddSteps();
        }

        [Test]
        public void UpdateManageListingTests()
        {
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();

            homePageSteps.ClickOnShareSkill();
            shareSkillAddSteps.AddShareSkillSteps();

            homePageSteps.ClickOnManageListingTab();
            manageListingSteps.UpdateShareSkillSteps();
        }

        [Test]
        public void DeleteManageListingTests()
        {
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();

            homePageSteps.ClickOnShareSkill();
            shareSkillAddSteps.AddShareSkillSteps();
            
            homePageSteps.ClickOnManageListingTab();
            manageListingSteps.DeleteShareSkillSteps();
        }

        [Test]

        public void ViewManageListingTests()
        {
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();

            homePageSteps.ClickOnShareSkill();
            shareSkillAddSteps.AddShareSkillSteps();

            homePageSteps.ClickOnManageListingTab();

            manageListingSteps.ViewSkillSteps();


        }

        [Test]
        public void SkillPaginationTests()
        {
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();

            homePageSteps.ClickOnManageListingTab();
            manageListingSteps.PaginationSteps();

        }
        [Test]
        public void ActiveButtonManageListingTests()
        {
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();
            homePageSteps.ClickOnManageListingTab();
            manageListingSteps.ActiveDeactivateServiceSteps();
        }

    }
}
