using MarsAdvancePart1.Pages.Components;
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
    public class LoginTests : GlobalHelper
    {
        private LoginSteps loginSteps;
        private HomePageSteps homePageSteps;
        private SplashPage loginPage;

        public LoginTests()
        {
            loginSteps = new LoginSteps();  
            homePageSteps = new HomePageSteps();
            loginPage = new SplashPage();
        }

        [Test,Order(1)]

        public void ValidLogin()
        {
            loginSteps.ValidLoginSteps();
        }
        [Test,Order(2)]
        public void InvalidUsernameValidPasswordTests()
        {
            loginSteps.InvalidUsernameValidPasswordSteps();

        }

        [Test,Order(3)]

        public void IncorrectPasswordValidUsernameTests()
        {
            loginPage.clickSignInButton();
            loginSteps.IncorrectPasswordValidUsernameSteps();
        }

       
        [Test,Order(4)]

        public void ForgotPasswordFunctionalityTests()
        {
            loginPage.clickSignInButton();
            loginSteps.ForgotPasswordFunctionalitySteps();
        }

        [Test,Order(5)]

        public void InvalidVerificationIdInForfotPasswordTests()
        {
            loginPage.clickSignInButton();
            loginSteps.InvalidVerificationIdForgotPasswordSteps();
        }
        [Test,Order(6)]
        public void PasswordCharacterSpecificationTest()
        {
            loginPage.clickSignInButton();
            loginSteps.PasswordCharacterSpecificationSteps();
        }
    }
}
