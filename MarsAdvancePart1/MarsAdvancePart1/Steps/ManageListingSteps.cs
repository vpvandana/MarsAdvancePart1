using MarsAdvancePart1.Model;
using MarsAdvancePart1.Pages.Components.NavigationMenu;
using MarsAdvancePart1.Utilities;
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
        JsonReader jsonReader;

        public ManageListingSteps()
        {
            manageListingComponent = new ManageListingComponent();
            manageListingOverviewComponent = new ManageListingOverviewComponent();
            navigationMenuTabComponents = new NavigationMenuTabComponents();
            jsonReader = new JsonReader();
        }

        public void UpdateShareSkillSteps()
        {
            List<ShareSkillAddModel> manageListingList = JsonReader.LoadData<ShareSkillAddModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\EditManageListingTestData.json");
            foreach(var item in manageListingList) 
            {
                manageListingOverviewComponent.ClickUpdateSkillIcon();
                manageListingComponent.UpdateListedSkill(item);

                string actualUpdateResult = manageListingComponent.GetUpdatedSkillList(item);
                if(actualUpdateResult == "Updated")
                {
                    Assert.AreEqual(actualUpdateResult, "Updated", "The actual and expected result does not match");
                }
            }
        }
    }
}
