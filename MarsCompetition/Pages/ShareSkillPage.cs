using MarsCompetition.DataModel;
using MarsCompetition.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MarsCompetition.Pages
{
    public class ShareSkillPage: CommonDriver
    {
        WebDriverWait wait1;
       private IWebElement titledDescribeService => driver.FindElement(By.Name("title"));
       private IWebElement descriptionTextBox => driver.FindElement(By.Name("description"));
       private IWebElement shareSkillButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[2]/a"));
       
       private IWebElement categoryIdDropBox => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div/div/select"));
       private IWebElement subCategoryIdDropBox => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select"));
       private IWebElement tagInputField => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
       private IWebElement tagInputField2 => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
       private IWebElement tagInputField3 => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
       private IWebElement serviceType => driver.FindElement(By.Name("serviceType"));
       private IWebElement hourlybasisService => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input"));
       private IWebElement locationType => driver.FindElement(By.Name("locationType"));
       private IWebElement onSite => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[1]/div/label"));
       private IWebElement startDateInput => driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@name='startDate']"));
       private IWebElement endDateInput => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input"));
       private IWebElement sundayCheckbox => driver.FindElement(By.XPath("//div[@class='ui checkbox']/input[@name='Available'][@index='0']"));
       private IWebElement sundayStartTime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[2]/div[2]/input"));
       private IWebElement sundayEndTime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[2]/div[3]/input"));
       private IWebElement mondayCheckbox => driver.FindElement(By.XPath("//div[@class='ui checkbox']/input[@name='Available'][@index='1']"));
       private IWebElement mondayStartTime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[3]/div[2]/input"));
       private IWebElement mondayEndTime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[3]/div[3]/input"));
       private IWebElement tuesdayCheckbox => driver.FindElement(By.XPath("//div[@class='ui checkbox']/input[@name='Available'][@index='2']"));
       private IWebElement tuesdayStartTime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[4]/div[2]/input"));
       private IWebElement tuesdayEndTime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[4]/div[3]/input"));
       private IWebElement skillTradeOptions => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));
       private IWebElement creditServiceCharge => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/input"));
       private IWebElement activeServices => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input"));
       private IWebElement saveButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));
       


        public ShareSkillPage()
        {
            wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
           
            
        }
        public void AddShareSkill(RegisterDataModel registerDataModel)
        {
            // Click on the share skill button
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/div[2]/a", 10);
            shareSkillButton.Click();



            EnterTitleAndDescription(registerDataModel.title, registerDataModel.description);
            SelectCategory(registerDataModel.category);

            EnterTags(registerDataModel.tags, registerDataModel.tags2, registerDataModel.tags3);

            GetTags();
            SelectServiceType(registerDataModel.serviceType);
            SelectLocationType(registerDataModel.locationType);
            SelectAvailability(registerDataModel.startDate, registerDataModel.endDate, registerDataModel.startTime, registerDataModel.endTime);
            SelectSkillTradeOptions();
            //UploadFile();
            SetActiveServices();
           



        }
        //Save Share Skill button, need separate to be able to run the assertion

        public void SaveShareSkills(RegisterDataModel registerDataModel)
        {
           
            ClickSaveButton();

        }

        // Enter the title and description
        public void EnterTitleAndDescription(string title,string description)
        {
            titledDescribeService.Clear();
            titledDescribeService.SendKeys(title);

            descriptionTextBox.Clear();
            descriptionTextBox.SendKeys(description);
        }
        public string GetEnteredTitle()
        {
                
            
            IWebElement updatedTitleElement = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input"));
            return updatedTitleElement.GetAttribute("value");              

        }
        public string GetEnteredDescription()
        {
            return descriptionTextBox.Text;
        }
        
        // Select the category
        public void SelectCategory(string category)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div/div/select", 15);
            categoryIdDropBox.Click();
            SelectElement selectElementcategoryId = new SelectElement(categoryIdDropBox);
            selectElementcategoryId.SelectByText(category);

            

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select", 15);
            subCategoryIdDropBox.Click();
            SelectElement subSelectElementcategoryId = new SelectElement(subCategoryIdDropBox);
            subSelectElementcategoryId.SelectByText("Health, Nutrition & Fitness");
        }

        public string GetSelectCategory()
        {
            IWebElement categoryIdDropBox = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[9]"));
            return categoryIdDropBox.Text;     
        }           
        // Enter the tags
       
        public void EnterTags(String tags , String tags2 , String tag3)
        {
            
            tagInputField.SendKeys(tags);
            tagInputField.SendKeys(Keys.Enter);
            tagInputField2.SendKeys(tags2);
            tagInputField2.SendKeys(Keys.Enter);
            tagInputField3.SendKeys(tag3);
            tagInputField3.SendKeys(Keys.Enter);


        }
     
        public string GetTags()
        {
            IWebElement tagInputField = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/span[1]"));
            var one = tagInputField.Text.Substring(0,tagInputField.Text.Length-1);
            
            return one;
            
           

        }
        public string GetTags2()
        {
            IWebElement tagInputField2 = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/span[2]"));
            var two = tagInputField2.Text.Substring(0, tagInputField2.Text.Length - 1);

            return two;

        }

        public string GetTags3()
        {
            IWebElement tagInputField3 = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/span[3]"));
            var three = tagInputField3.Text.Substring(0, tagInputField3.Text.Length - 1);

            return three;

        }


        // Select the service type
       
        public void SelectServiceType(string serviceType)
        {
            hourlybasisService.Click();
        }
        public string GetServiceType()
        {
           
            IWebElement serviceType = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/label"));

            return serviceType.Text;           


        }

        // Select the location type
        public void SelectLocationType(string locationType)
        {
            //locationType.Click();

            onSite.Click();
        }
        public string GetLocationType() 
        {

           
            IWebElement onSite = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[1]/div/label"));
            return onSite.Text;



        }
        // Select the availability
        public void SelectAvailability(string startDate, string endDate,string startTime, string endTime)
        {

            DateTime varStartDate = DateTime.ParseExact(startDate, "yyyy-MM-dd",CultureInfo.InvariantCulture);
            string varstartDate1 = varStartDate.ToString("dd-MM-yyyy");
            startDateInput.SendKeys(varstartDate1);
            

            DateTime varendDate = DateTime.ParseExact(endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string varendDate1 = varendDate.ToString("dd-MM-yyyy");
            endDateInput.SendKeys(varendDate1);
            
            sundayCheckbox.Click();
            
            sundayStartTime.Click();
            sundayStartTime.SendKeys("11:45am");
            
            sundayEndTime.Click();
            sundayEndTime.SendKeys("02:45pm");
            
            mondayCheckbox.Click();
            
            mondayStartTime.Click();
            mondayStartTime.SendKeys("11:45am");
           
            mondayEndTime.SendKeys("02:45pm");
            
            tuesdayCheckbox.Click();

            tuesdayStartTime.Click();
            tuesdayStartTime.SendKeys("11:45am");

            tuesdayEndTime.Click();
            tuesdayEndTime.SendKeys("02:45pm");

            
            
            

        }
        public string GetStartDate()
        {

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[1]", 10);
            IWebElement eyeButton = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[1]"));
            eyeButton.Click();
            IWebElement startDateInput = driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[1]/div/div[2]"));
            return startDateInput.Text;


        }
        public string GetEndDate()
        {
                       
            IWebElement endDateInput = driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[2]/div/div[2]"));
            return endDateInput.Text;
            

        }
        public string GetStartTime()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]", 10);
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]"));
            editButton.Click();
      
            IWebElement sundayStartTime = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[2]/div[2]/input"));
            sundayStartTime.Click();
            return sundayStartTime.Text;
        }
        // Select the skill trade options
        
        public void SelectSkillTradeOptions()
        {
            
            skillTradeOptions.Click();

            
            creditServiceCharge.SendKeys("5");
        }


        // Upload a file
        public void UploadFile()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement uploadButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")));
            uploadButton.Click();

            // Specify the path to the compiled AutoIt executable
            string autoItExePath = @"C:\Users\Ivica\Desktop\MarsCompetitionTask\MarsCompetition\AutoIt\fileupload.exe";



            // Start the AutoIt executable to handle the file upload dialog
            Process process = new Process();
            process.StartInfo.FileName = autoItExePath;
            process.Start();
            process.WaitForExit(); // Wait for the AutoIt script to finish

           

        }
        
        //Set active services
        public void SetActiveServices()
        {
            
            activeServices.Click();
        }
       
        public void ClickSaveButton()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]", 10);
            
            saveButton.Click();

        }











    }
}
