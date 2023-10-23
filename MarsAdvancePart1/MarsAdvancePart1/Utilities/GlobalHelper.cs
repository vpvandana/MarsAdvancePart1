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
        protected ExtentTest testreport;

        [OneTimeSetUp]
        public void SetupReport()
        {
            string reportPath = "C:\\internship notes\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\MarsAdvancePart1\\Utilities\\report.html";
            // string reportFile = DateTime.Now.ToString().Replace("\\", "/");
            ExtentSparkReporter htmlReporter = new ExtentSparkReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void startBrowser()
        {
            testreport = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            //Thread.Sleep(1000);
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
            

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

        protected void LogScreenshot(string description)
        {
            // Capture a screenshot and log it in the test report
            string screenshotPath = CaptureScreenshot(description);
            if(testreport != null) 
            {
                testreport.Log(Status.Info, description, MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            }
            
        }
        protected string CaptureScreenshot(string screenshotName)
        {
            ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            string screenshotPath = Path.Combine(@"C:\internship notes\MarsAdvancePart1\MarsAdvancePart1\MarsAdvancePart1\MarsAdvancePart1\Utilities\", $"{screenshotName}_{DateTime.Now:yyyyMMddHHmmss}.png");
            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            return screenshotPath;
        }

    }
}
