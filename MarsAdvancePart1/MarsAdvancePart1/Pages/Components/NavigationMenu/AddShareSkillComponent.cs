using MarsAdvancePart1.Model;
using MarsAdvancePart1.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancePart1.Pages.Components.NavigationMenu
{
    public class AddShareSkillComponent : GlobalHelper
    {
        private IWebElement addTitle;
        private IWebElement addDescription;
        private IWebElement selectCatagory;
        private IWebElement selectSubCatagory;
        private IWebElement addTags;
        private IWebElement hourlyServiceType;
        private IWebElement oneoffServiceType;
        private IWebElement onlineLocationType;
        private IWebElement offlineLocationType;
        private IWebElement availableStartDate;
        private IWebElement availableEndDate;
        private IWebElement availableDays;
        private IWebElement availableStartHours;
        private IWebElement skillExchangeTrade;
        private IWebElement creditTrade;
        private IWebElement creditAmount;
        private IWebElement skillExchangeTag;
        private IWebElement activeWork;
        private IWebElement hiddenWork;
        private IWebElement saveButton;

        public void RenderComponents()
        {
            try
            {
                addTitle = driver.FindElement(By.XPath("//input[@name='title']"));
                addDescription = driver.FindElement(By.XPath("//textarea[@name='description']"));
                selectCatagory = driver.FindElement(By.XPath("//select[@name='categoryId']"));
                selectSubCatagory = driver.FindElement(By.Name("subcategoryId"));
                addTags = driver.FindElement(By.XPath("//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]"));
                hourlyServiceType = driver.FindElement(By.XPath("//input[@name='serviceType' and @value='0']"));
                oneoffServiceType = driver.FindElement(By.XPath("//input[@name='serviceType' and @value='1']"));
                onlineLocationType = driver.FindElement(By.XPath("//input[@name='locationType' and @value='0']"));
                offlineLocationType = driver.FindElement(By.XPath("//input[@name='locationType' and @value='1']"));
                availableStartDate = driver.FindElement(By.XPath("//input[@name='startDate']"));
                availableEndDate = driver.FindElement(By.XPath("//input[@name='endDate']"));
                availableDays = driver.FindElement(By.Name("Available"));
                availableStartHours = driver.FindElement(By.Name("StartTime"));
                skillExchangeTrade = driver.FindElement(By.XPath("//input[@name='skillTrades' and @value='true']"));
                creditTrade = driver.FindElement(By.XPath("//input[@name='skillTrades' and @value='false']"));
                creditAmount = driver.FindElement(By.XPath("//input[@name='charge']"));
                skillExchangeTag = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
                activeWork = driver.FindElement(By.XPath("//input[@name='isActive' and @value='true']"));
                hiddenWork = driver.FindElement(By.XPath("//input[@name='isActive' and @value='false']"));
                saveButton = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
            }
        }

        public void AddShareSkills(ShareSkillAddModel skill )
        {
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='title']", 15);
            RenderComponents();

            addTitle.Click();
            addTitle.SendKeys(skill.Title);

            addDescription.Click();
            addDescription.SendKeys(skill.Description); 

            selectCatagory.Click();
            selectCatagory.SendKeys(skill.Catagory);
            selectSubCatagory.Click();
            selectSubCatagory.SendKeys(skill.SubCatagory);

            addTags.Click();
            addTags.SendKeys(skill.CatagoryTags);

            hourlyServiceType.Click();
            onlineLocationType.Click();

            availableStartDate.Click();
            availableStartDate.SendKeys(skill.AvailableStartDate);

            skillExchangeTrade.Click(); 
            skillExchangeTag.Click();
            skillExchangeTag.SendKeys(skill.SkillExchange);

            activeWork.Click();

            saveButton.Click();


        }
    }
}
