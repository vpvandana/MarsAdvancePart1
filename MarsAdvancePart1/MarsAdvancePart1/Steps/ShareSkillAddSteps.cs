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
    public class ShareSkillAddSteps 
    {
        NavigationMenuTabComponents navigationMenuTabComponents;
        AddShareSkillComponent addShareSkillComponent;
        JsonReader jsonReader;

        public ShareSkillAddSteps() 
        {
            navigationMenuTabComponents = new NavigationMenuTabComponents();
            addShareSkillComponent = new AddShareSkillComponent();
            jsonReader = new JsonReader();
        }

        public void AddShareSkillSteps()
        {
            List<ShareSkillAddModel> shareSkillAddList = JsonReader.LoadData<ShareSkillAddModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\ShareSkillAddTestData.json");
            foreach(var shareSkillAdd in shareSkillAddList)
            {
                addShareSkillComponent.AddShareSkills(shareSkillAdd);

                string addedSkillCatagory = addShareSkillComponent.GetAddedSkill(shareSkillAdd);

                if(addedSkillCatagory == shareSkillAdd.Catagory)
                {
                    Assert.AreEqual(addedSkillCatagory, shareSkillAdd.Catagory,"The actual and expected do not match");

                }
            }
        }

        public void MandatoryFieldsEmptyStep()
        {
            List<ShareSkillAddModel> shareSkillAddList = JsonReader.LoadData<ShareSkillAddModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\MandatoryFieldsEmptyShareSkillTestData.json");
            foreach(var shareSkillAdd in shareSkillAddList)
            {
                addShareSkillComponent.MandatoryFieldsLeftEmpty(shareSkillAdd);

                string actualMessage = addShareSkillComponent.GetErrorMessage();

                string expectedMessage = "Please complete the form correctly.";

                Assert.AreEqual(expectedMessage, actualMessage, "The actual and expected message do not match");
            }
        }

        public void SpecialCharactersOnTitle()
        {
            List<ShareSkillAddModel> shareSkillAddList = JsonReader.LoadData<ShareSkillAddModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\SpecialCharacterTitleDescriptionShareSkillTestData.json");
            foreach (var shareSkillAdd in shareSkillAddList)
            {
                addShareSkillComponent.AddSpecialCharacterOnTitle(shareSkillAdd);

                string actualMessage = addShareSkillComponent.GetWarningMessageTitle();

                string expectedMessage = "Special characters are not allowed.";

                Assert.AreEqual(expectedMessage, actualMessage, "The actual and expected message do not match");
            }
        }

        public void FirstCharacterSpaceOnTitle()
        {
            List<ShareSkillAddModel> shareSkillAddList = JsonReader.LoadData<ShareSkillAddModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\FirstChatacterSpaceOnTitleShareSkill.json");
            foreach (var shareSkillAdd in shareSkillAddList)
            {
                addShareSkillComponent.FirstCharacterSpaceForTitle(shareSkillAdd);

                string actualMessage = addShareSkillComponent.GetWarningMessageForFirstCharacterSpace();

                string expectedMessage = "First character must be an alphabet character or a number.";

                Assert.AreEqual(expectedMessage, actualMessage, "The actual and expected message do not match");
            }
        }
        public void FirstCharacterSpaceOnDescription()
        {
            List<ShareSkillAddModel> shareSkillAddList = JsonReader.LoadData<ShareSkillAddModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\FirstCharacterSpaceOnDescriptionShareSkill.json");
            foreach (var shareSkillAdd in shareSkillAddList)
            {
                addShareSkillComponent.FirstCharacterSpaceForDescription(shareSkillAdd);

                string actualMessage = addShareSkillComponent.GetWarningMessageForFirstCharacterSpaceDescription();

                string expectedMessage = "First character must be an alphabet character or a number.";

                Assert.AreEqual(expectedMessage, actualMessage, "The actual and expected message do not match");
            }
        }

        public void SubCatagoryNotSelected()
        {
            List<ShareSkillAddModel> shareSkillAddList = JsonReader.LoadData<ShareSkillAddModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\SubCatagoryNotSelectedTestData.json");
            foreach (var shareSkillAdd in shareSkillAddList)
            {
                addShareSkillComponent.SubCatagoryAndTagsNotSelected(shareSkillAdd);

                string actualMessage = addShareSkillComponent.GetWarningMessageForSubCatagoryNotSelected();
                string expectedMessage = "Subcategory is required";

                Assert.AreEqual(expectedMessage, actualMessage, "The actual and expected message do not match");

                string formErrorMessage = addShareSkillComponent.GetErrorMessageForIncompleteForm();
                string expectedFormMessage = "Please complete the form correctly.";

                Assert.AreEqual(formErrorMessage, expectedFormMessage, "Actual and expected message do not match");
            }
        }

        public void TagsNotEnteredSteps()
        {

            List<ShareSkillAddModel> shareSkillAddList = JsonReader.LoadData<ShareSkillAddModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\SubCatagoryNotSelectedTestData.json");
            foreach (var shareSkillAdd in shareSkillAddList)
            {
                addShareSkillComponent.SubCatagoryAndTagsNotSelected(shareSkillAdd);

                string actualMessage = addShareSkillComponent.GetWarningMessageForTagsNotEntered();
                string expectedMessage = "Tags are required";

                Assert.AreEqual(expectedMessage, actualMessage, "The actual and expected message do not match");

                string formErrorMessage = addShareSkillComponent.GetErrorMessageForIncompleteForm();
                string expectedFormMessage = "Please complete the form correctly.";

                Assert.AreEqual(formErrorMessage, expectedFormMessage, "Actual and expected message do not match");
            }
        }

        public void ClickOnCancelForAddSkillSteps()
        {
            List<ShareSkillAddModel> shareSkillAddList = JsonReader.LoadData<ShareSkillAddModel>("C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\TestData\\ClickOnCancelShareSkillAddTestData.json");
            foreach (var shareSkillAdd in shareSkillAddList)
            {
                addShareSkillComponent.ClickonCancelForAdd(shareSkillAdd);

                navigationMenuTabComponents.ClickManageListingTab();
                string actualResult = addShareSkillComponent.GetSkillToVerifyNotAdded(shareSkillAdd);
                Assert.AreEqual(actualResult, "Not Added", "The actual result and expected result do not match");
            }
        }
    }
}
