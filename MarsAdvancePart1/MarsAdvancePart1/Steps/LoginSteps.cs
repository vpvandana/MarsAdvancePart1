using MarsAdvancePart1.Pages.Components.SignIn;
using MarsAdvancePart1.Pages.Components;
using MarsAdvancePart1.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvancePart1.Model;
using NUnit.Framework;
using AventStack.ExtentReports.Gherkin.Model;
using System.Numerics;
using System.Security.Policy;

namespace MarsAdvancePart1.Steps
{
    public class LoginSteps 
    {
        SplashPage loginPage;
        LoginComponent loginComponent;
        HomePage homePage;
        JsonReader jsonReader;

        public LoginSteps()
        {
            loginPage = new SplashPage();
            loginComponent = new LoginComponent();
            homePage = new HomePage();
            jsonReader = new JsonReader();
        }

        public void doLogin()
        {

           UserInformationModel userinformation = new UserInformationModel();
           List<UserInformationModel> userInformationList = JsonReader.LoadData<UserInformationModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\UserInformationTestData.json");
           foreach(var user in userInformationList)
            {
                loginPage.clickSignInButton();
                loginComponent.doSignin(user);
            }
           

        }

        public void ValidLoginSteps()
        {
            UserInformationModel userinformation = new UserInformationModel();
            List<UserInformationModel> userInformationList = JsonReader.LoadData<UserInformationModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\UserInformationTestData.json");
            foreach(var user in userInformationList)
            {
                loginPage.clickSignInButton();
                loginComponent.doSignin(user);

                string expectedUsername = homePage.getFirstName();
                string actualUsername = "Hi "+user.FirstName;

                Assert.AreEqual(expectedUsername, actualUsername, "Actual and expected username do not match");
            }

        }

        public void InvalidUsernameValidPasswordSteps()
        {
            UserInformationModel userinformation = new UserInformationModel();
            List<UserInformationModel> userInformationList = JsonReader.LoadData<UserInformationModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\InvalidUsernameValidPasswordTestData.json");
            foreach (var user in userInformationList)
            {
                loginPage.clickSignInButton();
                loginComponent.InvalidUsernameValidPassword(user);
                string actualErrorMessage = "Please enter a valid email address";
                string expectedErrorMessage = loginComponent.GetInvalidUsernameErrorMessage();
               // string expectedUsername = homePage.getFirstName();
                //string actualUsername = "Hi " + user.FirstName;

                Assert.AreEqual(expectedErrorMessage, actualErrorMessage, "Actual and expected message do not match");
            }
        }

        public void IncorrectPasswordValidUsernameSteps()
        {
            UserInformationModel userinformation = new UserInformationModel();
            List<UserInformationModel> userInformationList = JsonReader.LoadData<UserInformationModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\IncorrectPasswordTestData.json");
            foreach( var user in userInformationList) 
            {
                loginComponent.ValidUsernameIncorrectPassword(user);

                //Error Message validation

                string expectedErrorMessage = "Confirm your email";
                string actualErrorMessage = loginComponent.GetIncorrectPasswordErrorMessage();
                Assert.AreEqual(expectedErrorMessage, actualErrorMessage, "The actual and expected message do not match");

                //Email Verification Validation

               // string actualMessage = loginComponent.GetEmailVerification(user);
               // string expectedMessage = "Email Verification Sent";

               // Assert.AreEqual(expectedMessage, actualMessage, "The actual and expected message do not match");

            }
        }

     
        public void ForgotPasswordFunctionalitySteps()
        {
            UserInformationModel userinformation = new UserInformationModel();
            List<UserInformationModel> userInformationList = JsonReader.LoadData<UserInformationModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\ForgotPasswordTestData.json");
            foreach( var user in userInformationList) 
            {
                loginComponent.ForgotPasswordFunctionality(user);
               

                string expectedConfirmationMessage = loginComponent.GetEmailVerificationConfirmationBox();
                string actualConfirmationMessage = "A recovery link has been sent to your inbox.\r\nPlease use the link to recover your account.";

                Assert.AreEqual(expectedConfirmationMessage, actualConfirmationMessage, "Actual and expected message do not match");

                string expectedMessage =  loginComponent.GetEmailVerificationSuccessMessage();
                string actualMessage = "Please check your email to reset your password";

                Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected message do not match");
            }
        }

        public void InvalidVerificationIdForgotPasswordSteps()
        {
            UserInformationModel userinformation = new UserInformationModel();
            List<UserInformationModel> userInformationList = JsonReader.LoadData<UserInformationModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\InvalidVerificationIdTestData.json");
            foreach( var user in userInformationList) 
            {
                loginPage.clickSignInButton();
                loginComponent.InvalidVerificationEmailIdInForgotPassword(user);
                string expectedErrorMessage = loginComponent.GetInvalidVerificationIdMessage();
                string actualErrorMessage = "Email is Invalid";

                Assert.AreEqual(expectedErrorMessage, actualErrorMessage, "Actual and expected message do not match");
            }
        }

        public void PasswordCharacterSpecificationSteps()
        {
            UserInformationModel userinformation = new UserInformationModel();
            List<UserInformationModel> userInformationList = JsonReader.LoadData<UserInformationModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\PasswordCharacterSpecificationTestData.json");
            foreach(var user in userInformationList)
            {
                loginComponent.LoginEntries(user);
                string expectedMessage = loginComponent.GetLessPasswordCharacterMessage();
                string actualMessage = "Password must be at least 6 characters";

                Assert.AreEqual(expectedMessage, actualMessage, "Actual and expected characters do not match");
                    
                
            }
        }
    }
}
