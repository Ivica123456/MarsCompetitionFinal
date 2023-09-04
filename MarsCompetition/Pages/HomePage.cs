using MarsCompetition.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace MarsCompetition.Pages
{
    public class HomePage : CommonDriver
    {
        WebDriverWait wait1;
        

        public HomePage()
        {

            wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            
        }


        public void GoToLoginPage()
        {
            //Open Chrome Driver
          
            driver.Navigate().GoToUrl("http://localhost:5000/Home");
            driver.Manage().Window.Maximize();

        }

    }
}
