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
    public class DescriptionSteps
    {
        ProfileDescriptionComponent profileDescriptionComponent;
        JsonReader jsonReader;

        public DescriptionSteps()
        {
            profileDescriptionComponent = new ProfileDescriptionComponent();  
            jsonReader = new JsonReader();
        }


        public void AddandUpdateDescription()
        {
           
            List<DescriptionModel> profileDescriptionList = JsonReader.LoadData<DescriptionModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\DescriptionTestData.json");

            foreach (var profiledescription in profileDescriptionList)
            {
                profileDescriptionComponent.AddDescription(profiledescription);
                string actualMessage = "Description has been saved successfully";
                string expectedMessage = profileDescriptionComponent.GetAddedSuccessMessage();

                Assert.AreEqual(expectedMessage, actualMessage,"Description not added");

                string addedDescription = profileDescriptionComponent.GetAddedDescription();
                if(addedDescription == profiledescription.DescriptionText)
                {
                    Assert.AreEqual(addedDescription, profiledescription.DescriptionText, "Description does not match");
                }
                
            }

        }

        public void AddSpecialNumericSymbol()
        {
            List<DescriptionModel> profileDescriptionList = JsonReader.LoadData<DescriptionModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\DescriptionSpecialNumericSymbolTestData.json");

            foreach (var profiledescription in profileDescriptionList)
            {
                profileDescriptionComponent.AddDescription(profiledescription);
                string actualMessage = "Description has been saved successfully";
                string expectedMessage = profileDescriptionComponent.GetAddedSuccessMessage();

                Assert.AreEqual(expectedMessage, actualMessage, "Description not added");

                string addedDescription = profileDescriptionComponent.GetAddedDescription();
                if (addedDescription == profiledescription.DescriptionText)
                {
                    Assert.AreEqual(addedDescription, profiledescription.DescriptionText, "Description does not match");
                }

            }
        }

        public void DeleteDescription()
        {
            List<DescriptionModel> profileDescriptionList = JsonReader.LoadData<DescriptionModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\DeleteDescriptionTestData.json");
            foreach (var profiledescription in profileDescriptionList)
            {
                profileDescriptionComponent.DeleteDescription(profiledescription);
                string actualMessage = "Please, a description is required";
                string expectedMessage = profileDescriptionComponent.GetDeletedMessage();

                Assert.AreEqual(expectedMessage, actualMessage, "Description not deleted");
            }
        }

        public void FirstCharacterSpace()
        {
            List<DescriptionModel> profileDescriptionList = JsonReader.LoadData<DescriptionModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\FirstCharacterSpaceTestData.json");
            foreach(var  profiledescription in profileDescriptionList)
            {
                profileDescriptionComponent.FirstCharacterSpace(profiledescription);
                string actualMessage = "First character can only be digit or letters";

                string expectedMessage = profileDescriptionComponent.GetFirstCharacterSpaceErrorMessage();

                Assert.AreEqual(expectedMessage, actualMessage, "Description added. Error");
            }
        }
    }
}
