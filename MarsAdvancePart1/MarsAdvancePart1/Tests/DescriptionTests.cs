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
    public class DescriptionTests : GlobalHelper
    {

        private LoginSteps loginSteps;
        private HomePageSteps homePageSteps;
        private DescriptionSteps descriptionSteps;

        public DescriptionTests()
        {
           loginSteps = new LoginSteps();
            homePageSteps = new HomePageSteps();
            descriptionSteps = new DescriptionSteps();  
        }

        [Test]
        public void AddDescriptionTests()
        {
            loginSteps.doLogin();

            homePageSteps.ValidateIsLoggedIn();
            homePageSteps.ClickOnDescriptionIcon();

            descriptionSteps.AddandUpdateDescription();
        }

        [Test]

        public void AddSpecialNumericSymbolTests()
        {
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();
            homePageSteps.ClickOnDescriptionIcon();

            descriptionSteps.AddSpecialNumericSymbol();
        }

        [Test]

        public void DeleteDescriptionTests()
        {
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();
            homePageSteps.ClickOnDescriptionIcon();

            descriptionSteps.DeleteDescription();
        }
        [Test]

        public void FirstCharacterSpaceTests()
        {
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();
            homePageSteps.ClickOnDescriptionIcon();
            descriptionSteps.FirstCharacterSpace();
        }
    }
}
