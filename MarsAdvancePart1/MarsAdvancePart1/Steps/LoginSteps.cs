using MarsAdvancePart1.Pages.Components.SignIn;
using MarsAdvancePart1.Pages.Components;
using MarsAdvancePart1.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsAdvancePart1.Model;

namespace MarsAdvancePart1.Steps
{
    public class LoginSteps 
    {
        SplashPage loginPage;
        LoginComponent loginComponent;

        public LoginSteps()
        {
            loginPage = new SplashPage();
            loginComponent = new LoginComponent();
        }

        public void doLogin()
        {

           UserInformationModel userinformation = new UserInformationModel();
            userinformation.setEmail("vandanapradeep1991@gmail.com");
            userinformation.setPassword("abcdabcd");

            loginPage.clickSignInButton();
            loginComponent.doSignin(userinformation);

        }
    }
}
