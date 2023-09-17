using MarsAdvancePart1.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancePart1.Pages.Components.ProfileOverview
{
    internal class ProfileMenuTabComponents : GlobalHelper
    {
        private IWebElement descriptionEditIcon;
        private IWebElement userNameDropdownIcon;
        private IWebElement availabilityEditIcon;
        private IWebElement hoursEditIcon;
        private IWebElement earnTargetEditIcon;

        public void RenderComponents()
        {
            try
            {
                userNameDropdownIcon = driver.FindElement(By.XPath("//div[@class='title']//i[@class='dropdown icon']"));
                descriptionEditIcon = driver.FindElement(By.XPath("//h3[@class='ui dividing header']//i[@class='outline write icon']"));
                availabilityEditIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
                hoursEditIcon = driver.FindElement(By.XPath("//i[@class='large clock outline check icon']//parent::span//following-sibling::div//span//i"));
                earnTargetEditIcon = driver.FindElement(By.XPath("//i[@class='large dollar icon']//parent::span//following-sibling::div//span//i"));

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void ClickDescriptionIcon()
        {
            RenderComponents();
            descriptionEditIcon.Click();
            Thread.Sleep(1000);
        }

        public void ClickUserNameIcon()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='title']//i[@class='dropdown icon']", 7);

            RenderComponents();
            userNameDropdownIcon.Click();
            Thread.Sleep(2000);
        }

        public void ClickAvailabilityEditIcon()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//span[normalize-space()='Part Time']//i[@class='right floated outline small write icon']", 7);
            RenderComponents();
            availabilityEditIcon.Click();
           // Thread.Sleep(1000);
        }

        public void ClickHoursEditIcon()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//i[@class='large clock outline check icon']//parent::span//following-sibling::div//span//i", 7);
            RenderComponents();
            hoursEditIcon.Click();
            //Thread.Sleep(1000);
        }

        public void ClickEarnTargetEditIcon()
        {
            RenderComponents();
            earnTargetEditIcon.Click();
           // Thread.Sleep(1000);
        }
    }
}
