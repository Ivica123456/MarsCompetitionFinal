using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsCompetition.Utilities;
using MarsCompetition.DataModel;

namespace MarsCompetition.Pages
{
    public class CertificationPage: CommonDriver
    {
        WebDriverWait wait1;
        private IWebElement clickCertificationButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));
        private IWebElement certificateOrAwardTextBox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input"));
        private IWebElement certificationFromTextBox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[1]/input"));
        private IWebElement certificationYeardropdown => driver.FindElement(By.Name("certificationYear"));
        private IWebElement clickAddNewButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
        private IWebElement addButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]"));
        private IWebElement actualCertificate => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]"));
        private IWebElement actualFrom => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[2]"));
        private IWebElement actualYear => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[3]"));
        private IWebElement editButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[1]"));
        private IWebElement editCertificationAwordTextBox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/div/div[1]/input"));
        private IWebElement editFromTextBox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/div/div[2]/input"));
        private IWebElement editYearTextBox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/div/div[3]/select"));
        private IWebElement updateButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
        private IWebElement actualEditCertificate => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]"));
        private IWebElement actualEditFrom => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[2]"));
        private IWebElement actualEditYear => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[3]"));
        private IWebElement deleteButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]"));

        public CertificationPage() 
        {

            wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

        }
        public void AddCertification(CertificationDataModel certificationDataModel)
        {
            //Wait for the certification button to be visible:
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")));
            //Click on the certification button:
            clickCertificationButton.Click();
            //Click on the "Add New" button:
            clickAddNewButton.Click();
            //Enter the certificate name:
            certificateOrAwardTextBox.SendKeys(certificationDataModel.certificate);
            //Enter the provider from:
            certificationFromTextBox.SendKeys(certificationDataModel.from);
            //Select the certification year from the dropdown:
            certificationYeardropdown.Click();
            SelectElement selectElementselectCertificationYear = new(certificationYeardropdown);
            selectElementselectCertificationYear.SelectByValue(certificationDataModel.year);
            //Click on the "Add" button:
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]")));
            addButton.Click();


        }
        public string  GetCertificate()
        {
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]")));
            
            return actualCertificate.Text;

        }
        public string GetFrom()
        {
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[2]")));
            
            return actualFrom.Text;

        }
        public string GetYear()
        {
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[3]")));
            
            return actualYear.Text;

        }
        public void EditCertification(CertificationDataModel certificationDataModel)
        {
            //Wait for the certification button to be visible:
            //Click on the certification button:
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")));
            clickCertificationButton.Click();
            //Click on edit button
            editButton.Click();
            //Edit the certificate name:
            editCertificationAwordTextBox.Click();
            editCertificationAwordTextBox.Clear();
            editCertificationAwordTextBox.SendKeys(certificationDataModel.certificate);
            //Edit the provider From:
            editFromTextBox.Click();
            editFromTextBox.Clear();
            editFromTextBox.SendKeys(certificationDataModel.from);
            //Edit the certification year from the dropdown:
             editYearTextBox.Click();
            SelectElement selectElementselectCertificationYear = new(editYearTextBox);
            selectElementselectCertificationYear.SelectByValue(certificationDataModel.year);
            //Update button click
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/span/input[1]")));
            updateButton.Click();
            //Refresh page
            driver.Navigate().Refresh();
            //Wait for the certification button to be visible:
            //Click on the certification button:
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")));
            clickCertificationButton.Click();



        }
        public string GetEditCertification()
        {
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]")));
            
            return actualEditCertificate.Text;                               
        }
        public string GetEditFrom()
        {
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[2]")));
            
            return actualEditFrom.Text;

        }
        public string GetEditYear()
        {
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[3]")));
            
            return actualEditYear.Text;

        }
        
        public void ClickDeleteButton()
        {
            //Wait for the certification button to be visible:
            //Click on the certification button:
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")));
            clickCertificationButton.Click();
                   
                           
            // Click the delete button
            deleteButton.Click();

           
        }
        public bool IsListingDeleted()
        {

            try
            {
                wait1.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]")));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }





    }
}
