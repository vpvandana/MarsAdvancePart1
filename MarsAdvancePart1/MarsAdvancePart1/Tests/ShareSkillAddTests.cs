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
    public class ShareSkillAddTests : GlobalHelper
    {

        private LoginSteps loginSteps;
        private HomePageSteps homePageSteps;
        private ShareSkillAddSteps shareSkillAddSteps;

        public ShareSkillAddTests()
        {
            loginSteps = new LoginSteps();
            homePageSteps = new HomePageSteps();
            shareSkillAddSteps = new ShareSkillAddSteps();
        }

        [Test]

        public void SkillAddTests()
        {
            loginSteps.doLogin();  
            homePageSteps.ValidateIsLoggedIn();
            homePageSteps.ClickOnShareSkill();  

            shareSkillAddSteps.AddShareSkillSteps();
        }

        [Test]

        public void MandatoryFieldAddTest()
        {
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();
            homePageSteps.ClickOnShareSkill();

            shareSkillAddSteps.MandatoryFieldsEmptyStep();  
        }

        [Test]
        public void SpecialCharacteronTitleTests() 
        {
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();
            homePageSteps.ClickOnShareSkill();

            shareSkillAddSteps.SpecialCharactersOnTitle();
        }

        [Test]
        public void FirstCharacterSpaceOnTitleTests()
        {
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();
            homePageSteps.ClickOnShareSkill();

            shareSkillAddSteps.FirstCharacterSpaceOnTitle();
        }

        [Test]
        public void FirstCharacterSpaceOnDescriptionTests()
        {
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();
            homePageSteps.ClickOnShareSkill();

            shareSkillAddSteps.FirstCharacterSpaceOnDescription();
        }

        [Test]

        public void SubCatagoryNotSelectedTests()
        {
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();
            homePageSteps.ClickOnShareSkill();

            shareSkillAddSteps.SubCatagoryNotSelected();
        }
        [Test]
        public void TagsNotEnteredTests()
        {
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();
            homePageSteps.ClickOnShareSkill();

            shareSkillAddSteps.TagsNotEnteredSteps();
        }

        [Test]

        public void ClickOnCancelShareSkillAddTests()
        {
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();
            homePageSteps.ClickOnShareSkill();

            shareSkillAddSteps.ClickOnCancelForAddSkillSteps();
            
        }
    }
}
