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

        [Test,Order(2)]
        public void UpdateManageListingTests()
        {
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();

            homePageSteps.ClickOnShareSkill();
            shareSkillAddSteps.AddShareSkillSteps();

            homePageSteps.ClickOnManageListingTab();
            manageListingSteps.UpdateShareSkillSteps();
        }

        [Test,Order(3)]
        public void DeleteManageListingTests()
        {
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();

            homePageSteps.ClickOnShareSkill();
            shareSkillAddSteps.AddShareSkillSteps();
            
            homePageSteps.ClickOnManageListingTab();
            manageListingSteps.DeleteShareSkillSteps();
        }

        [Test,Order(4)]

        public void ViewManageListingTests()
        {
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();

            homePageSteps.ClickOnShareSkill();
            shareSkillAddSteps.AddShareSkillSteps();

            homePageSteps.ClickOnManageListingTab();

            manageListingSteps.ViewSkillSteps();


        }

        [Test,Order(1)]
        public void SkillPaginationTests()
        {
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();

            homePageSteps.ClickOnManageListingTab();
            manageListingSteps.PaginationSteps();

        }
        [Test,Order(5)]
        public void ActiveButtonManageListingTests()
        {
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();
            homePageSteps.ClickOnManageListingTab();
            manageListingSteps.ActiveDeactivateServiceSteps();
        }

    }
}
