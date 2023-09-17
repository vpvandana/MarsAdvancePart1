using MarsAdvancePart1.Model;
using MarsAdvancePart1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancePart1.Pages.Components.ProfileOverview
{
    public class ProfileAboutMeAddandUpdateComponent : GlobalHelper
    {
        private IWebElement firstNameTextbox;
        private IWebElement lastName;
        private IWebElement saveButton;
        private IWebElement editIcon;
        
        private IWebElement usernameDropdownIcon;
        private IWebElement addedUserName;
        private IWebElement addedAvailability;
        private IWebElement addedHours;
        private IWebElement addedEarnTarget;

        

        private static IWebElement availabilityDropdown => driver.FindElement(By.Name("availabiltyType"));
        private static IWebElement hoursDropdown => driver.FindElement(By.Name("availabiltyHour"));
        private static IWebElement earnTargetDropdown => driver.FindElement(By.Name("availabiltyTarget"));
        private static IWebElement deleteIcon => driver.FindElement(By.XPath("//*[@class='remove icon']"));
        private static IWebElement messageWindow => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        private static IWebElement closeMessageIcon => driver.FindElement(By.XPath("//a[@class='ns-close']"));


        public void RenderComponents()
        {
            try
            {
                firstNameTextbox = driver.FindElement(By.XPath("//input[@name='firstName']"));
                lastName = driver.FindElement(By.Name("lastName"));
                saveButton = driver.FindElement(By.XPath("//*[text()='Last Name']//parent::div//following-sibling::div//button"));
                usernameDropdownIcon = driver.FindElement(By.XPath("//div[@class='title']//i[@class='dropdown icon']"));
                addedAvailability = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span"));

            }
            
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

      

        public void AddandUpdateUserName(ProfileAboutMeModel profileAboutMe)
        {
           
           Wait.WaitToBeClickable(driver, "Name", "firstName", 20);

            RenderComponents();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            //Saving username
            firstNameTextbox.Click();

            firstNameTextbox.Clear();
            firstNameTextbox.SendKeys(profileAboutMe.FirstName);

            lastName.Click();
            lastName.Clear();
            lastName.SendKeys(profileAboutMe.LastName);

            saveButton.Click();
            Thread.Sleep(2000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            
        }

        public string GetUserName()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='title']", 15);
            addedUserName = driver.FindElement(By.XPath("//div[@class='title']"));
            
            return addedUserName.Text;
        }

        public void AddandUpdateAvailabilityDetails(ProfileAboutMeModel profileAboutMe)
        {
           
            availabilityDropdown.Click();
            availabilityDropdown.SendKeys(profileAboutMe.Availability);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

        }

       public string GetAddedAvailability()
       {
            Wait.WaitToExist(driver, "XPath", "//span[normalize-space()='Full Time']", 15);
            addedAvailability = driver.FindElement(By.XPath("//i[@class='large calendar icon']//parent::span//following-sibling::div//span"));
            return addedAvailability.Text;
       }

        public string GetSuccesMessage()
        {
            //Saving error or success message
            
            String message = messageWindow.Text;

            //If any message visible close it
            Wait.WaitToBeClickable(driver, "XPath", "//*[@class='ns-close']", 5);
            closeMessageIcon.Click();

            return message;
        }

        public void AddandUpdateAvailabilityHourDetails(ProfileAboutMeModel profileAboutMe)
        {
            hoursDropdown.Click();
            hoursDropdown.SendKeys(profileAboutMe.Hours);

           // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        public string GetAddedHours()
       {
            Wait.WaitToExist(driver, "XPath", "//i[@class='large clock outline check icon']//parent::span//following-sibling::div//span", 15);
            addedHours = driver.FindElement(By.XPath("//i[@class='large clock outline check icon']//parent::span//following-sibling::div//span"));
            return addedHours.Text;
       }


        public void AddandUpdateAvailabilityEarnTargetDetails(ProfileAboutMeModel profileAboutMe)
        {
           
            earnTargetDropdown.Click();
            earnTargetDropdown.SendKeys(profileAboutMe.EarnTarget);


             driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }
        public string GetAddedEarnTarget()
        {
            Wait.WaitToExist(driver, "XPath", "//i[@class='large dollar icon']//parent::span//following-sibling::div//span", 15);
            addedEarnTarget = driver.FindElement(By.XPath("//i[@class='large dollar icon']//parent::span//following-sibling::div//span"));
            return addedEarnTarget.Text;
        }

        public void UpdateNoChangesOnCancel()
        {
            availabilityDropdown.Click();
            deleteIcon.Click();

        }
    }
}
