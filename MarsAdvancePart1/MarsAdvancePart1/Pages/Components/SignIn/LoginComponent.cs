using MarsAdvancePart1.Model;
using MarsAdvancePart1.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancePart1.Pages.Components.SignIn
{
    public class LoginComponent : GlobalHelper
    {
        private IWebElement emailTextbox;
        private IWebElement passwordTextbox;
        private IWebElement loginButton;
        private IWebElement signInButton;

        public void RenderComponents()
        {
            try
            {
                emailTextbox = driver.FindElement(By.XPath("//*[@placeholder='Email address']"));
                passwordTextbox = driver.FindElement(By.XPath("//*[@placeholder='Password']"));
                loginButton = driver.FindElement(By.XPath("//*[text()='Login']"));
                signInButton = driver.FindElement(By.XPath("//*[text()='Sign In']"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void doSignin(UserInformationModel userinformation)
        {
            RenderComponents();
            //Enter valid Username and Password

            emailTextbox.SendKeys(userinformation.getEmail());
            passwordTextbox.SendKeys(userinformation.getPassword());

            //Sign In using Login Button

            loginButton.Click();
            // Thread.Sleep(3000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[2]/div/div/div[1]/div/div[4]", 7);
        }
    }
}
