using MarsCompetition.Pages;
using MarsCompetition.Utilities;
using OpenQA.Selenium.Chrome;
using Newtonsoft.Json;
using System.IO;
using MarsCompetition.DataModel;
using System.Net.Http.Json;
using System.Text.Json;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;

namespace MarsCompetition.Tests
{
    [TestFixture]
    public class ShareSkillTests : CommonDriver
    {
        //// Deserialize the JSON into the RegisterModel object
        //RegisterDataModel registerDataModel = JsonConvert.DeserializeObject<RegisterDataModel>(jsonContent);



        [Test, Order(1)]
        public void ClickShareSkillPageButtonJson()
        {

            // Log the test step in the Extent Report
            test.Info("Starting ClickShareSkillPageButtonJson...");

            // Read the JSON file
            string jsonFilePath = "C:\\Users\\Ivica\\Desktop\\MarsCompetitionTask\\MarsCompetition\\JSONData\\skilldata.json";
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON into the RegisterModel object
            RegisterDataModel registerDataModel = JsonConvert.DeserializeObject<RegisterDataModel>(jsonContent);

            // Access the values from the DataModel object
            string title = registerDataModel.title;
            string description = registerDataModel.description;
            string category = registerDataModel.category;
            string tags2 = registerDataModel.tags2;
            string tags = registerDataModel.tags;
            string tags3 = registerDataModel.tags3;
            string serviceType = registerDataModel.serviceType;
            string locationType = registerDataModel.locationType;
            string startDate = registerDataModel.startDate;
            string endDate = registerDataModel.endDate;
            string startTime = registerDataModel.startTime;
            string endTime = registerDataModel.endTime;
            string skillTradeOptions = registerDataModel.skillTradeOptions;
            string creditServiceCharge = registerDataModel.creditServiceCharge;
            string activeServices = registerDataModel.activeServices;
            string filePath = Path.Combine(jsonFilePath);
            string url = registerDataModel.url;


            ShareSkillPage shareSkillPage = new ShareSkillPage();
            
            shareSkillPage.AddShareSkill(registerDataModel);


            // Assertion: Check if the user is navigated to the correct page
            Assert.That(driver.Title, Is.EqualTo("ServiceListing"));

            //Perform assertions

            Assert.That(shareSkillPage.GetEnteredTitle(), Is.EqualTo(title), "Title should match the expected value.");
            test.Pass("GetEnteredTitle value verified.");
            Assert.That(shareSkillPage.GetEnteredDescription(), Is.EqualTo(description), "Description should match the expected value.");
            test.Pass("GetEnteredDescription value verified.");
            Assert.That(shareSkillPage.GetSelectCategory(), Is.EqualTo(category), "Category should match the expected value.");
            test.Pass("GetEnteredCategory value verified.");
            Assert.That(shareSkillPage.GetTags2(), Is.EqualTo(tags2), "Tags should match the expected value.");
            test.Pass("GetEnteredTags2 value verified.");
            Assert.That(shareSkillPage.GetTags(), Is.EqualTo(tags), "Tags should match the expected value.");
            test.Pass("GetEnteredTags value verified.");
            Assert.That(shareSkillPage.GetTags3(), Is.EqualTo(tags3), "Tags should match the expected value.");
            test.Pass("GetEnteredTags3 value verified.");
            Assert.That(shareSkillPage.GetServiceType(), Is.EqualTo(serviceType), "ServiceType should match the expected value.");
            test.Pass("GetService value verified.");
            Assert.That(shareSkillPage.GetLocationType(), Is.EqualTo(locationType), "LocationType should match the expected value.");
            test.Pass("GetLocationType value verified.");

            shareSkillPage.SaveShareSkills(registerDataModel);

            Assert.That(shareSkillPage.GetStartDate, Is.EqualTo(startDate), "StartDate should match the expected value.");
            test.Pass("GetStartDate value verified.");
            Assert.That(shareSkillPage.GetEndDate, Is.EqualTo(endDate), "EndDate should match the expected value.");
            test.Pass("GetEndDate value verified.");

        }




        [Test, Order(2)]
        public void ClickShareSkillPageButton_NegativeTestJson()
        {
            // Log the test step in the Extent Report
            test.Info("ClickShareSkillPageButton_NegativeTestJson...");

            // Read the JSON file
            string jsonFilePath = "C:\\Users\\Ivica\\Desktop\\MarsCompetitionTask\\MarsCompetition\\JSONData\\skilldata.json";
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON into the RegisterModel object
            RegisterDataModel registerDataModel = JsonConvert.DeserializeObject<RegisterDataModel>(jsonContent);

            // Access the values from the DataModel object
            string title = registerDataModel.title;
            string description = registerDataModel.description;
            string category = registerDataModel.category;
            string tags2 = registerDataModel.tags2;
            string tags = registerDataModel.tags;
            string tags3 = registerDataModel.tags3;
            string serviceType = registerDataModel.serviceType;
            string locationType = registerDataModel.locationType;
            string startDate = registerDataModel.startDate;
            string endDate = registerDataModel.endDate;
            string startTime = registerDataModel.startTime;
            string endTime = registerDataModel.endTime;
            string skillTradeOptions = registerDataModel.skillTradeOptions;
            string creditServiceCharge = registerDataModel.creditServiceCharge;
            string activeServices = registerDataModel.activeServices;
            string filePath = Path.Combine(jsonFilePath);
            string url = registerDataModel.url;


            ShareSkillPage shareSkillPage = new ShareSkillPage();

            shareSkillPage.AddShareSkill(registerDataModel);


            // Read the negative JSON file
           
            string jsonFilePath1 = "C:\\Users\\Ivica\\Desktop\\MarsCompetitionTask\\MarsCompetition\\JSONData\\negative_skilldata.json";
            string jsonContent1 = File.ReadAllText(jsonFilePath1);

            
            // Deserialize the JSON into the RegisterDataModel object using Newtonsoft.Json
            RegisterDataModel registerDataModel1 = Newtonsoft.Json.JsonConvert.DeserializeObject<RegisterDataModel>(jsonContent1);

            // Access the values from the DataModel object
            string title1 = registerDataModel1.title;
            string description1 = registerDataModel1.description;
            string category1 = registerDataModel1.category;
            string tags21 = registerDataModel1.tags2;
            string tags11 = registerDataModel1.tags;
            string tags31 = registerDataModel1.tags3;
            string serviceType1 = registerDataModel1.serviceType;
            string locationType1 = registerDataModel1.locationType;

            // calling method SaveShareSkill to click on save button,because startDate is on another page
            
            shareSkillPage.SaveShareSkills(registerDataModel);
           
            string startDate1 = registerDataModel1.startDate;
            string endDate1 = registerDataModel1.endDate;
            
            
            //Perform assertions on the invalid data
            Assert.That(shareSkillPage.GetEnteredTitle(), Is.Not.EqualTo(title1), "Title should be invalid");
            test.Pass("GetEnteredTitle value verified.");
            Assert.That(shareSkillPage.GetEnteredDescription(), Is.Not.EqualTo(description1), "Description should be invalid");
            test.Pass("GetEnteredDescription value verified.");
            Assert.That(shareSkillPage.GetSelectCategory(), Is.Not.EqualTo(category1), "Category should be invalid");
            test.Pass("GetSelectCategory value verified.");
            Assert.That(shareSkillPage.GetTags2, Is.Not.EqualTo(tags21), "Tags should be invalid");
            test.Pass("GetTags2 value verified.");
            Assert.That(shareSkillPage.GetTags3, Is.Not.EqualTo(tags31), "Tags should be invalid");
            test.Pass("GetTags3 value verified.");
            Assert.That(shareSkillPage.GetServiceType, Is.Not.EqualTo(serviceType1), "ServiceType should be invalid");
            test.Pass("GetServiceType value verified.");
            Assert.That(shareSkillPage.GetLocationType, Is.Not.EqualTo(locationType1), "LocationType should be invalid");
            test.Pass("GetLocationType value verified.");
            Assert.That(shareSkillPage.GetStartDate, Is.Not.EqualTo(startDate1), "StartDate should be invalid");
            test.Pass("GetStartDate value verified.");
            Assert.That(shareSkillPage.GetEndDate, Is.Not.EqualTo(endDate1), "EndDate should be invalid");
            test.Pass("GetEndDate value verified.");








        }



    }
}
