using MarsCompetition.DataModel;
using MarsCompetition.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarsCompetition.Pages
{
    public class EducationPage: CommonDriver
    {
        WebDriverWait wait1;
        private IWebElement clickEducationButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));
        private IWebElement clickAddNewButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));
        private IWebElement collegeUniversityName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input"));
        private IWebElement countryOfCollege => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select"));
        private IWebElement addTitle => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select"));
        private IWebElement addDegree => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input"));
        private IWebElement addYear => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select"));
        private IWebElement addButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]"));
        private IWebElement editButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]"));
        private IWebElement editCollegeUniversityName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[1]/div[1]/input"));
        private IWebElement editCountryOfCollege => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[1]/div[2]/select"));
        private IWebElement editTitle => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[1]/select"));
        private IWebElement editDegree => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[2]/input"));
        private IWebElement editYear => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[3]/select"));
        private IWebElement updateButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]"));
        private IWebElement deleteButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[2]"));
       
        public EducationPage() 
        {
            // Initialize WebDriverWait and set implicit wait timeout
            wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }
        public void AddEducation(EducationDataModel educationDataModel)
        {
            // Wait for the education button to be visible
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")));

            // Click the "Education" button
            clickEducationButton.Click();

            // Click the "Add New" button to start adding a new education entry
            clickAddNewButton.Click();

            // Enter the university name into the appropriate field
            collegeUniversityName.SendKeys(educationDataModel.university);

            // Click to open the dropdown for selecting the country of the college
            countryOfCollege.Click();
            // Create a SelectElement to interact with the country dropdown
            SelectElement selectElementselectcountryOfCollege = new(countryOfCollege);
            // Select the specified country from the dropdown
            selectElementselectcountryOfCollege.SelectByValue(educationDataModel.country);

            // Click to open the dropdown for selecting the title
            addTitle.Click();
            // Create a SelectElement to interact with the title dropdown
            SelectElement selectElementselectaddTitle = new(addTitle);
            // Select the specified title from the dropdown
            selectElementselectaddTitle.SelectByValue(educationDataModel.title);

            // Enter the degree information
            addDegree.SendKeys(educationDataModel.degree);

            // Click to open the dropdown for selecting the year
            addYear.Click();
            // Create a SelectElement to interact with the year dropdown
            SelectElement selectElementselectaddYear = new(addYear);
            // Select the specified year from the dropdown
            selectElementselectaddYear.SelectByValue(educationDataModel.year);

            // Click the "Add" button to add the education entry
            addButton.Click();
        }

        public string GetCountryOfCollege()
        {
            // Locate the element containing the country of the college information
            IWebElement actualCountryOfCollege = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[1]"));
            // Return the text of the element, representing the country of the college
            return actualCountryOfCollege.Text;
        }

        public string GetCollegeUniversityName()
        {
            // Locate the element containing the college/university name information
            IWebElement actualCollegeUniversityName = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[2]"));
            // Return the text of the element, representing the college/university name
            return actualCollegeUniversityName.Text;
        }

        public string GetTitle()
        {
            // Locate the element containing the title information
            IWebElement actualTitle = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[3]"));
            // Return the text of the element, representing the title
            return actualTitle.Text;
        }

        public string GetDegree()
        {
            // Locate the element containing the degree information
            IWebElement actualDegree = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[4]"));
            // Return the text of the element, representing the degree
            return actualDegree.Text;
        }

        public string GetYear()
        {
            // Locate the element containing the year information
            IWebElement actualYear = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[5]"));
            // Return the text of the element, representing the year
            return actualYear.Text;
        }

        public void EditEducation(EducationDataModel educationDataModel)
        {
            // Wait for the education button to be visible
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")));

            // Click the "Education" button
            clickEducationButton.Click();

            // Click the "Edit" button to start editing the education entry
            editButton.Click();

            // Clear and update the university name with the new value
            editCollegeUniversityName.Clear();
            editCollegeUniversityName.SendKeys(educationDataModel.university);

            // Click to open the dropdown for selecting the country of the college
            editCountryOfCollege.Click();
            // Create a SelectElement to interact with the country dropdown
            SelectElement selectElementselectEditcountryOfCollege = new(editCountryOfCollege);
            // Select the specified country from the dropdown
            selectElementselectEditcountryOfCollege.SelectByValue(educationDataModel.country);

            // Click to open the dropdown for selecting the title
            editTitle.Click();
            // Create a SelectElement to interact with the title dropdown
            SelectElement selectElementselectaddTitle = new(editTitle);
            // Select the specified title from the dropdown
            selectElementselectaddTitle.SelectByValue(educationDataModel.title);

            // Clear and update the degree information with the new value
            editDegree.Clear();
            editDegree.SendKeys(educationDataModel.degree);

            // Click to open the dropdown for selecting the year
            editYear.Click();
            // Create a SelectElement to interact with the year dropdown
            SelectElement selectElementselectaddYear = new(editYear);
            // Select the specified year from the dropdown
            selectElementselectaddYear.SelectByValue(educationDataModel.year);

            // Click the "Update" button to save the edited education entry
            updateButton.Click();

            // Refresh the page to reflect the changes
            driver.Navigate().Refresh();

            // Wait for the education button to be visible
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")));

            // Click the "Education" button again
            clickEducationButton.Click();
        }

        public string GetEditEducationCountry()
        {
            // Locate the element containing the edited education entry's country information
            IWebElement actualEditEducation = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[1]"));
            // Return the text of the element, representing the edited education entry's country
            return actualEditEducation.Text;
        }

        public string GetEditCollegeUniversityName()
        {
            // Locate the element containing the edited education entry's college/university name information
            IWebElement actualEditCollegeUniversityName = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[2]"));
            // Return the text of the element, representing the edited education entry's college/university name
            return actualEditCollegeUniversityName.Text;
        }

        public string GetEditTitle()
        {
            // Locate the element containing the edited education entry's title information
            IWebElement actualEditTitle = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[3]"));
            // Return the text of the element, representing the edited education entry's title
            return actualEditTitle.Text;
        }

        public string GetEditDegree()
        {
            // Locate the element containing the edited education entry's degree information
            IWebElement actualEditDegree = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[4]"));
            // Return the text of the element, representing the edited education entry's degree
            return actualEditDegree.Text;
        }

        public string GetEditYear()
        {
            // Locate the element containing the edited education entry's year information
            IWebElement actualEditYear = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[5]"));
            // Return the text of the element, representing the edited education entry's year
            return actualEditYear.Text;
        }

        public void DeleteEducationButton()
        {
            // Wait for the education button to be visible
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")));

            // Click the "Education" button
            clickEducationButton.Click();

            // Click the "Delete" button to delete the education entry
            deleteButton.Click();
        }

        public bool IsListingDeleted()
        {
            try
            {
                // Wait until the delete icon becomes invisible, indicating that the entry is deleted
                wait1.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[2]")));
                // Entry is deleted
                return true;
            }
            catch (NoSuchElementException)
            {
                // Entry is not found, hence deleted
                return false;
            }
        }

    }
}
