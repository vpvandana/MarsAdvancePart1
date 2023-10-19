using MarsAdvancePart1.Pages.Components.ProfileOverview;
using MarsAdvancePart1.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancePart1.Pages.Components
{
    public class HomePage : GlobalHelper
    {
        private IWebElement userNameLabel;
        private ProfileMenuTabComponents profileMenuTabComponents;

        public HomePage() 
        {
            profileMenuTabComponents = new ProfileMenuTabComponents();
        }

        public void RenderComponents()
        {
            try
            {
                userNameLabel = driver.FindElement(By.XPath("//span[contains(@class,'item ui')]"));
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

       /* public ProfileMenuTabComponents GetProfileMenuTabComponents()
        {
            return profileMenuTabComponents;

        }*/

        public String getFirstName()
        {
            //Return username
            try
            {
                RenderComponents();
                return userNameLabel.Text;

            }
            catch (Exception ex)
            {
                driver.Navigate().Refresh();
                return ex.Message;
            }
        }
    }
}
