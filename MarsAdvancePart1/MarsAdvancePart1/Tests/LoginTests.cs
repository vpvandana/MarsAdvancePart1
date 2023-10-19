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

        [Test]

        public void ValidLogin()
        {
            loginSteps.ValidLoginSteps();
        }
        [Test]
        public void InvalidUsernameValidPasswordTests()
        {
            loginSteps.InvalidUsernameValidPasswordSteps();

        }

        [Test]

        public void IncorrectPasswordValidUsernameTests()
        {
            loginPage.clickSignInButton();
            loginSteps.IncorrectPasswordValidUsernameSteps();
        }

       
        [Test]

        public void ForgotPasswordFunctionalityTests()
        {
            loginPage.clickSignInButton();
            loginSteps.ForgotPasswordFunctionalitySteps();
        }

        [Test]

        public void InvalidVerificationIdInForfotPasswordTests()
        {
           // loginPage.clickSignInButton();
            loginSteps.InvalidVerificationIdForgotPasswordSteps();
        }
        [Test]
        public void PasswordCharacterSpecificationTest()
        {
            loginPage.clickSignInButton();
            loginSteps.PasswordCharacterSpecificationSteps();
        }
    }
}
