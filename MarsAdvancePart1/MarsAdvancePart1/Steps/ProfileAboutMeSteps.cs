using MarsAdvancePart1.AssertHelpers;
using MarsAdvancePart1.Model;
using MarsAdvancePart1.Pages.Components.ProfileOverview;
using MarsAdvancePart1.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancePart1.Steps
{
    public class ProfileAboutMeSteps 
    {
      //  ProfileAboutMeOverviewComponent profileAboutMeOverviewComponent;
        ProfileAboutMeAddandUpdateComponent profileAboutMeAddandUpdateComponent;
        HomePageSteps homePageSteps;
        JsonReader jsonReader;

        public ProfileAboutMeSteps()
        {
            profileAboutMeAddandUpdateComponent = new ProfileAboutMeAddandUpdateComponent();
            homePageSteps = new HomePageSteps();
            jsonReader = new JsonReader();
        }

        public void UpdateUserName()
        {
            ProfileAboutMeModel profileAboutMeModel = new ProfileAboutMeModel();
            List<ProfileAboutMeModel> profileAboutMeList = JsonReader.LoadData<ProfileAboutMeModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\ProfileAboutMeTestData.json");

           foreach(var profile in profileAboutMeList) 
            {
               // profileAboutMeOverviewComponent.ClickonUsernameIcon();
                profileAboutMeAddandUpdateComponent.AddandUpdateUserName(profile);

                string actualAddedUserName = profileAboutMeAddandUpdateComponent.GetUserName();
                string expectedUserName = profile.FirstName+" "+profile.LastName;
                
                ProfileAddandUpdateUsernameAssert.assertUpdateUserName(expectedUserName, actualAddedUserName);
            }
           
        }

        public void UpdateProfileAvailability()
        {
            ProfileAboutMeModel profileAboutMeModel = new ProfileAboutMeModel();
            List<ProfileAboutMeModel> profileAboutMeList = JsonReader.LoadData<ProfileAboutMeModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\ProfileAvailabilityTestData.json");

            foreach(var profile in  profileAboutMeList)
            { 
                profileAboutMeAddandUpdateComponent.AddandUpdateAvailabilityDetails(profile);

                string actualAddedAvailability = profileAboutMeAddandUpdateComponent.GetAddedAvailability();
                if(actualAddedAvailability == profile.Availability)
                {
                   Assert.AreEqual(profile.Availability, actualAddedAvailability,"Actual and expected availability do not match");
                }

                //Verifying success message
                string expectedMessage = "Availability updated";
                string actualMessage = profileAboutMeAddandUpdateComponent.GetSuccessMessage();

                Assert.AreEqual(expectedMessage, actualMessage, "The availability has not updated");

            }       
            
        }

        public void UpdateProfileAvailabilityHours()
        {
            ProfileAboutMeModel profileAboutMeModel = new ProfileAboutMeModel();


            List<ProfileAboutMeModel> profileAboutMeList = JsonReader.LoadData<ProfileAboutMeModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\AvailabilityHoursTestData.json");

            foreach (var profile in profileAboutMeList)
            {
                // profileAboutMeOverviewComponent.ClickonAvailabilityEditIcon();
                profileAboutMeAddandUpdateComponent.AddandUpdateAvailabilityHourDetails(profile);

                string actualAddedHours = profileAboutMeAddandUpdateComponent.GetAddedHours();
                if (actualAddedHours == profile.Hours)
                {
                    Assert.AreEqual(profile.Hours, actualAddedHours, "Actual and expected Hours do not match");
                }

                //Verifying success message
                string expectedMessage = "Availability updated";
                string actualMessage = profileAboutMeAddandUpdateComponent.GetSuccessMessage();

                Assert.AreEqual(expectedMessage, actualMessage, "The availability has not updated");

            }

        }

        public void UpdateProfileAvailabilityEarnTarget()
        {
            ProfileAboutMeModel profileAboutMeModel = new ProfileAboutMeModel();

            List<ProfileAboutMeModel> profileAboutMeList = JsonReader.LoadData<ProfileAboutMeModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\EarnTargetTestData.json");

            foreach (var profile in profileAboutMeList)
            {
                // profileAboutMeOverviewComponent.ClickonAvailabilityEditIcon();
                profileAboutMeAddandUpdateComponent.AddandUpdateAvailabilityTargetDetails(profile);

                string actualAddedEarnTarget = profileAboutMeAddandUpdateComponent.GetAddedEarnTarget();
                if (actualAddedEarnTarget == profile.EarnTarget)
                {
                    Assert.AreEqual(profile.EarnTarget, actualAddedEarnTarget, "Actual and expected availability do not match");
                }
                //Verifying success message
                string expectedMessage = "Availability updated";
                string actualMessage = profileAboutMeAddandUpdateComponent.GetSuccessMessage();

                Assert.AreEqual(expectedMessage, actualMessage, "The availability has not updated");

            }
        }

        public void ClickonCancelIconSteps()
        {
            ProfileAboutMeModel profileAboutMeModel = new ProfileAboutMeModel();
            List<ProfileAboutMeModel> profileAboutMeList = JsonReader.LoadData<ProfileAboutMeModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\ProfileAvailabilityTestData.json");

            foreach (var profile in profileAboutMeList)
            {
               
                string actualAvailabity = profileAboutMeAddandUpdateComponent.GetAddedAvailability();

                profileAboutMeAddandUpdateComponent.ClickAvailabilityOnCancel();
                string newAvailabity = profileAboutMeAddandUpdateComponent.GetAddedAvailability();

                Assert.AreEqual(actualAvailabity, newAvailabity, "The actual and new availabity does not match");
            }
        }

    }
}
