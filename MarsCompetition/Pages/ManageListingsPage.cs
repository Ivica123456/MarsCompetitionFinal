using MarsCompetition.DataModel;
using MarsCompetition.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetition.Pages
{
    public class ManageListingsPage: CommonDriver
    {
        WebDriverWait wait1;
        private IWebElement manageListingsButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]"));
        private IWebElement eyeButton => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[1]"));
        private IWebElement newServiceDetails => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i"));
        private IWebElement newTitle => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input"));
        private IWebElement newDescription1 => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea"));
        private IWebElement saveButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));
        private IWebElement updatedDescriptionElement => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]"));
        private IWebElement deleteButton => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i"));
        private IWebElement deleteServiceYes => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));

        public ManageListingsPage()
        {
            wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            
        }

        public void ClickOnManageListings()
        {
            // Wait for the manage listings button to be clickable
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]", 10);
            manageListingsButton.Click();                                  

        }
        public void viewTheService()
        {
            // Wait for the eye button to be clickable
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[1]", 10);
            eyeButton.Click();

        }
        
        //Test Order 4 code
       
        public void editExistingService(RegisterDataModel registerDataModel)
        {
            // Wait for the edit button to be clickable
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i", 10);
            newServiceDetails.Click();
            // Wait for the new title input field to be clickable
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input", 10);
            newTitle.Clear();
            newTitle.SendKeys(registerDataModel.title);
            // Description input field 
            newDescription1.Clear();
            newDescription1.SendKeys(registerDataModel.description);
            // Save button
            saveButton.Click();
        }
        public string GetUpdatedTitle()
        {
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]")));
            IWebElement updatedTitleElement = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
            return updatedTitleElement.Text;                               

        }

        public string GetUpdatedDescription()
        {
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]")));
            return updatedDescriptionElement.Text;
        }
       
        //Test Order 5
        public void deleteManageListings()
        {
            // Wait for the delete button to be clickable
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i", 10);
            deleteButton.Click();
            // Wait for the confirmation button to be clickable
            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[2]/div/div[3]/button[2]", 10);
            deleteServiceYes.Click();

        }
               
        public bool IsListingDeleted()
        {
            try
            {
                wait1.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]")));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

    }   }
}
