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
    public class ManageListingComponent : GlobalHelper
    {
       

        private IWebElement addTitle;
        private IWebElement addDescription;
        private IWebElement selectCatagory;
        private IWebElement subCatagory;
        private IWebElement addTags;

        private IWebElement availableStartDate;
        private IWebElement availableStartHours;
        private IWebElement availableEndHours;
        private IWebElement availableMonday;
        private IWebElement availableTuesday;
        private IWebElement skillExchangeTrade;
        private IWebElement creditTrade;
        private IWebElement creditAmount;


        private IWebElement skillExchangeTag;
        private IWebElement activeWork;
        private IWebElement hiddenWork;
        private IWebElement saveButton;

        private IWebElement messageBox;
        private IWebElement messageCloseButton;

        private IWebElement warningMessageBoxTitle;
        private IWebElement warningMessageBoxDescription;


        public void RenderComponents()
        {
            try
            {
                addTitle = driver.FindElement(By.XPath("//input[@name='title']"));
                addDescription = driver.FindElement(By.XPath("//textarea[@name='description']"));
                selectCatagory = driver.FindElement(By.XPath("//select[@name='categoryId']"));

                addTags = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));

                availableStartDate = driver.FindElement(By.XPath("//input[@name='startDate']"));

                availableMonday = driver.FindElement(By.XPath("//input[@name='Available' and @index='1']"));
                availableTuesday = driver.FindElement(By.XPath("//input[@name='Available' and @index='2']"));
                availableStartHours = driver.FindElement(By.XPath("//input[@name='StartTime' and @index='1']"));
                availableEndHours = driver.FindElement(By.XPath("//input[@name='EndTime' and @index='1']"));

                creditTrade = driver.FindElement(By.XPath("//input[@name='skillTrades' and @value='false']"));
                skillExchangeTrade = driver.FindElement(By.XPath("//input[@name='skillTrades' and @value='true']"));
                
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

        public void RenderSubCatagoryComponent()
        {
            subCatagory = driver.FindElement(By.XPath("//select[@name='subcategoryId']"));
        }

        public void RenderCreditComponent()
        {
            
            creditAmount = driver.FindElement(By.XPath("//input[@name='charge']"));
        }
        public void RenderMessageComponent()
        {
            messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            messageCloseButton = driver.FindElement(By.XPath("//a[@class='ns-close']"));
        }


        public void UpdateListedSkill(ShareSkillAddModel skill)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//input[@name='title']", 7);
            RenderComponents();

            addTitle.Clear();
            addTitle.SendKeys(skill.Title);

            addDescription.Clear();
            addDescription.SendKeys(skill.Description);
            selectCatagory.SendKeys(skill.Catagory);

            RenderSubCatagoryComponent();
            subCatagory.SendKeys(Keys.Tab);
            subCatagory.SendKeys(skill.SubCatagory);
            // addTags.SendKeys(skill.CatagoryTags);
            // addTags.SendKeys(Keys.Enter);

           

            foreach (string tag in skill.CatagoryTags)
            {
               
                addTags.SendKeys(tag + Keys.Enter);
            }
            IList<IWebElement> serviceRadioButtons = driver.FindElements(By.Name("serviceType"));
            int Size = serviceRadioButtons.Count;

            for (int i = 0; i < Size; i++)
            {

                String Value = serviceRadioButtons.ElementAt(i).GetAttribute("value");


                if (Value.Equals("0"))
                {
                    serviceRadioButtons.ElementAt(i).Click();

                    break;
                }

            }


            IList<IWebElement> locationRadioButtons = driver.FindElements(By.Name("locationType"));
            int locationSize = locationRadioButtons.Count;

            for (int i = 0; i < locationSize; i++)
            {

                String locationValue = locationRadioButtons.ElementAt(i).GetAttribute("value");


                if (locationValue.Equals("1"))
                {
                    locationRadioButtons.ElementAt(i).Click();

                    break;
                }

            }

            DateTime currentDateTime = DateTime.Today;
            string formattedDateTime = currentDateTime.ToString("MM/dd/YYYY");
            availableStartDate.SendKeys(formattedDateTime);

            availableMonday.Click();
            availableStartHours.SendKeys(skill.AvailableStartTime);
            availableEndHours.SendKeys(skill.AvailableEndTime);

            availableTuesday.Click();

            
            creditTrade.Click();
            RenderCreditComponent();
            creditAmount.SendKeys(skill.CreditAmount);

           
            activeWork.Click();

            saveButton.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        public string GetUpdatedSkillList(ShareSkillAddModel skill)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            string result = "";

            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//h2[text()='Manage Listings']//parent::div//child::tbody//tr"));
            foreach (IWebElement row in rows)
            {
                IWebElement catagoryElement = row.FindElement(By.XPath("./td[2]"));
                IWebElement titleElement = row.FindElement(By.XPath("./td[3]"));
                IWebElement descriptionElement = row.FindElement(By.XPath("./td[4]"));
                string updatedCatagory = catagoryElement.Text;
                string updatedTitle = titleElement.Text;
                string updatedDescription = descriptionElement.Text;

                if ((updatedCatagory == skill.Catagory) && (updatedDescription == skill.Description) && (updatedTitle == skill.Title))
                {
                    result = "Updated";
                    break;
                }

            }

            return result;

        }
    }
    
}
