using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace MarsAdvancePart1.Utilities
{
    public class GlobalHelper
    {
        public static IWebDriver driver;
        protected ExtentReports extent;
        protected ExtentTest test;

        [OneTimeSetUp]
        public void SetupReport()

        {

            string reportPath = "C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\Utilities\\ExtentReports\\report.html";
            // string reportFile = DateTime.Now.ToString().Replace("\\", "/");
            ExtentSparkReporter htmlReporter = new ExtentSparkReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

        }


        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            //Thread.Sleep(1000);
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }



        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }

        [OneTimeTearDown]
        public void TearDownReport()
        {
            extent.Flush();
        }

    }
}
