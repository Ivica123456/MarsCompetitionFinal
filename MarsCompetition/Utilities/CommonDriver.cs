using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using MarsCompetition.Pages;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace MarsCompetition.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;

        //Extent Reports configuration for my tests store in CommonDriver part1 starts:
        public ExtentReports extent;
        public ExtentTest test;
        //part1 ends //////////////////////////////////////////////////////////////////
        
        
        public void Initialize()
        {

            driver = new ChromeDriver();
        }
        
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            HomePage homePage = new HomePage();
            homePage.GoToLoginPage();

            LoginPage loginPage = new LoginPage();
            loginPage.goToShareSkillPage();
            

        }



        //Extent Reports configuration for my tests store in CommonDriver part2 start:

        [OneTimeSetUp]
        public void InitializeExtentReports()
        {
            var reportPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "C:\\Users\\Ivica\\Desktop\\MarsCompetitionTask\\MarsCompetition\\ExtentReport\\");
            var extentHtmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(extentHtmlReporter);
        }

        [OneTimeTearDown]
        public void FlushExtentReports()
        {
            extent.Flush();
        }

        [SetUp]
        public void BeforeTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void AfterTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string screenshotPath = TakeScreenshot();
                test.AddScreenCaptureFromPath(screenshotPath);
            }

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                test.Pass("Test Passed");
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                test.Fail("Test Failed");
            }
        }

        private string TakeScreenshot()
        {
            string screenshotDir = "C:\\Users\\Ivica\\Desktop\\MarsCompetitionTask\\MarsCompetition\\ExtentReport\\Screenshot\\";
            Directory.CreateDirectory(screenshotDir);
            string screenshotPath = Path.Combine(screenshotDir, $"{TestContext.CurrentContext.Test.Name}.png");
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            return screenshotPath;
        }
        //part2 ends //////////////////////////////////////////////////////////////////////////////////////////////////


        [TearDown]
        public void Teardown()
        {
            // Quit the WebDriver
            driver.Quit();
        }
    }
}
