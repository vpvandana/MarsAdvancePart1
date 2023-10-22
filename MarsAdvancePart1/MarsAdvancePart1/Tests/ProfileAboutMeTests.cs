using MarsAdvancePart1.Pages.Components.ProfileOverview;
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
    public class ProfileAboutMeTests : GlobalHelper
    {
       
        private LoginSteps loginSteps;
        private HomePageSteps homePageSteps;
        private ProfileAboutMeSteps profileAboutMeSteps;

       public ProfileAboutMeTests() 
        {
            loginSteps = new LoginSteps();
            homePageSteps = new HomePageSteps();
            profileAboutMeSteps = new ProfileAboutMeSteps();
        }

        [Test,Order(1)]

        public void UpdateUsernameTests()
        {
            

            loginSteps.doLogin();

            homePageSteps.ValidateIsLoggedIn();

            homePageSteps.ClickOnProfileIcon();
            Thread.Sleep(1000);
            profileAboutMeSteps.UpdateUserName();



        }

        [Test,Order(2)]
        public void AddandUpdateAvailabilityTests()
        {
           
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();
            homePageSteps.ClickOnAvailabilityEditIcon();

            profileAboutMeSteps.UpdateProfileAvailability();
        }

        [Test,Order(3)]
        public void AddandUpdateHoursTests()
        {
           

            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();
            homePageSteps.ClickOnHoursEditIcon();

            profileAboutMeSteps.UpdateProfileAvailabilityHours();
        }

        [Test,Order(4)]
        public void AddandUpdateEarnTargetTests()
        {
            
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();
            homePageSteps.ClickOnEarnTargetEditIcon();

            profileAboutMeSteps.UpdateProfileAvailabilityEarnTarget();
        }

        [Test,Order(5)]
        public void NoChangeOnCancelForAvailabilityTests()
        {
            loginSteps.doLogin();
            homePageSteps.ValidateIsLoggedIn();

            homePageSteps.ClickOnAvailabilityEditIcon();
          
            profileAboutMeSteps.ClickonCancelIconSteps();
        }

    }
}
