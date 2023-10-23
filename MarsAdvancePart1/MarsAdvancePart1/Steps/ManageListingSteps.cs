using MarsAdvancePart1.Model;
using MarsAdvancePart1.Pages.Components.NavigationMenu;
using MarsAdvancePart1.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancePart1.Steps
{
    public class ManageListingSteps
    {
        ManageListingComponent manageListingComponent;
        ManageListingOverviewComponent manageListingOverviewComponent;
        NavigationMenuTabComponents navigationMenuTabComponents;
        AddShareSkillComponent addShareSkillComponent;
        JsonReader jsonReader;

        public ManageListingSteps()
        {
            manageListingComponent = new ManageListingComponent();
            manageListingOverviewComponent = new ManageListingOverviewComponent();
            navigationMenuTabComponents = new NavigationMenuTabComponents();
            addShareSkillComponent = new AddShareSkillComponent();
            jsonReader = new JsonReader();
        }

        public void UpdateShareSkillSteps()
        {
            List<ShareSkillAddModel> manageListingList = JsonReader.LoadData<ShareSkillAddModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\EditManageListingTestData.json");
            foreach(var item in manageListingList) 
            {
               // addShareSkillComponent.AddShareSkills(item);

                manageListingOverviewComponent.ClickUpdateSkillIcon();
                manageListingComponent.UpdateListedSkill(item);

                string actualUpdateResult = manageListingComponent.GetUpdatedSkillList(item);
                if(actualUpdateResult == "Updated")
                {
                    Assert.AreEqual(actualUpdateResult, "Updated", "The actual and expected result does not match");
                }
            }
        }

        public void DeleteShareSkillSteps()
        {
            List<ShareSkillAddModel> manageListingList = JsonReader.LoadData<ShareSkillAddModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\DeleteSkillListingTestData.json");
           
            foreach(var item in manageListingList)
            {
                //manageListingOverviewComponent.ClickDeleteSkillIcon();
               // addShareSkillComponent.AddShareSkills(item);

                manageListingComponent.DeleteListedSkill(item);

                string actualDeleteResult = manageListingComponent.GetDeletedSkill(item);

                if(actualDeleteResult == "Deleted")
                {
                    Assert.AreEqual(actualDeleteResult, "Deleted", "The actual and expected result does not match");
                }
                string expectedDeleteMessage = item.Title + " has been deleted";
                string actualDeleteMessage = manageListingComponent.GetDeletedMessage();
                Assert.AreEqual(actualDeleteMessage, expectedDeleteMessage, "The actual and expected message do not match");          

            }
        }

        public void ViewSkillSteps()
        {
            List<ShareSkillAddModel> manageListingList = JsonReader.LoadData<ShareSkillAddModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\ViewSkillTestData.json");
            foreach(var item in manageListingList)
            {
               
                manageListingComponent.ViewListedSkill(item);

                string actualResult = manageListingComponent.GetViewSkill(item);
                if(actualResult == item.Title)
                {
                    Assert.AreEqual(actualResult, item.Title, "The actual and expected result do not match");                   
                }

            }
        }

        public void PaginationSteps()
        {
            List<ShareSkillAddModel> manageListingList = JsonReader.LoadData<ShareSkillAddModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\PaginationTestData.json");
            foreach(var item in manageListingList)
            {
                
                string actualResult = manageListingComponent.GetTitleByPagination(item);
                Assert.AreEqual(actualResult, "Found", "Title not found");
            }
        }

        public void ActiveDeactivateServiceSteps()
        {
            List<ShareSkillAddModel> manageListingList = JsonReader.LoadData<ShareSkillAddModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\ActiveButtonManageListingTestData.json");
            foreach( var item in manageListingList)
            {
                string actualResult = manageListingComponent.ActivateDeactivateSkills(item);
                if(actualResult == "Activated")
                {
                    Assert.AreEqual(actualResult, "Activated", "The actual and expected result do not match");

                    string message = manageListingComponent.GetActiveMessage();
                    string expectedMessage = "Service has been activated";
                    Assert.AreEqual(message, expectedMessage, "Actual and expected message do not match");
                }
                else
                {
                    Assert.AreEqual(actualResult, "Deactivated", "The actual and expected result do not match");
                    string deactiveMessage = manageListingComponent.GetActiveMessage();
                    string expectedDeactiveMessage = "Service has been deactivated";
                    Assert.AreEqual(deactiveMessage, expectedDeactiveMessage, "Actual and expected message do not match");
                }
             
               
            }
        }

    }
}
