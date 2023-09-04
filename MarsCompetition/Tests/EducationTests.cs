using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using MarsCompetition.DataModel;
using MarsCompetition.Pages;
using MarsCompetition.Utilities;
using Newtonsoft.Json;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarsCompetition.Tests
{
    public class EducationTests: CommonDriver
    {
        
       
        [Test]
        [Order(1)]
        public void AddEducationTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting AddEducationTest...");

            // Read the JSON file
            string jsonFilePath = "C:\\Users\\Ivica\\Desktop\\MarsCompetitionTask\\MarsCompetition\\JSONData\\education.json";
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON into the  object  CertificationDataModel
            EducationDataModel educationDataModel = JsonConvert.DeserializeObject<EducationDataModel>(jsonContent);

            // Access the values from the DataModel object
            string country = educationDataModel.country;
            string university = educationDataModel.university;
            string title = educationDataModel.title;
            string degree = educationDataModel.degree;
            string year = educationDataModel.year;

            EducationPage educationPage = new EducationPage();
            educationPage.AddEducation(educationDataModel);

            // Assert the results and log the test step in the Extent Report
            Assert.That(educationPage.GetCountryOfCollege(), Is.EqualTo(country), "Certificate should match the expected value.");
            test.Pass("CountryOfCollege value verified.");

            Assert.That(educationPage.GetCollegeUniversityName(), Is.EqualTo(university), "From should match the expected value.");
            test.Pass("CollegeUniversityName value verified.");

            Assert.That(educationPage.GetTitle(), Is.EqualTo(title), "Year should match the expected value.");
            test.Pass("Title value verified.");

            Assert.That(educationPage.GetDegree(), Is.EqualTo(degree), "From should match the expected value.");
            test.Pass("Degree value verified.");

            Assert.That(educationPage.GetYear(), Is.EqualTo(year), "Year should match the expected value.");
            test.Pass("Year value verified.");
        }
        [Test]
        [Order(2)]
        public void AddNegativeEducationTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting AddNegativeEducationTest...");

            // Read the JSON file
            string jsonFilePath = "C:\\Users\\Ivica\\Desktop\\MarsCompetitionTask\\MarsCompetition\\JSONData\\education.json";
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON into the  object  CertificationDataModel
            EducationDataModel educationDataModel = JsonConvert.DeserializeObject<EducationDataModel>(jsonContent);

            // Access the values from the DataModel object
            string country = educationDataModel.country;
            string university = educationDataModel.university;
            string title = educationDataModel.title;
            string degree = educationDataModel.degree;
            string year = educationDataModel.year;

            EducationPage educationPage = new EducationPage();
            educationPage.AddEducation(educationDataModel);

            // Assert the results and log the test step in the Extent Report
            Assert.That(educationPage.GetCountryOfCollege(), Is.EqualTo(country), "Education should match the expected value.");
            test.Pass("CountryOfCollege value verified.");

            Assert.That(educationPage.GetCollegeUniversityName(), Is.EqualTo(university), "University should match the expected value.");
            test.Pass("CollegeUniversityName value verified.");

            Assert.That(educationPage.GetTitle(), Is.EqualTo(title), "Title should match the expected value.");
            test.Pass("Title value verified.");

            Assert.That(educationPage.GetDegree(), Is.EqualTo(degree), "Degree should match the expected value.");
            test.Pass("Degree value verified.");

            Assert.That(educationPage.GetYear(), Is.EqualTo(year), "Year should match the expected value.");
            test.Pass("Year value verified.");


            // Read the negative JSON file
            string jsonFilePath1 = "C:\\Users\\Ivica\\Desktop\\MarsCompetitionTask\\MarsCompetition\\JSONData\\negative_education.json";
            string jsonContent1 = File.ReadAllText(jsonFilePath1);

            // Deserialize the JSON into the  object  CertificationDataModel
            EducationDataModel educationDataModel1 = JsonConvert.DeserializeObject<EducationDataModel>(jsonContent1);

            // Access the values from the DataModel object
            string country1 = educationDataModel1.country;
            string university1 = educationDataModel1.university;
            string title1 = educationDataModel1.title;
            string degree1 = educationDataModel1.degree;
            string year1 = educationDataModel1.year;

            // Assert the results and log the test step in the Extent Report
            Assert.That(educationPage.GetCountryOfCollege(), Is.Not.EqualTo(country1), "Country should not match the expected value.");
            test.Pass("Negative CountryOfCollege value verified.");

            Assert.That(educationPage.GetCollegeUniversityName(), Is.Not.EqualTo(university1), "University should not match the expected value.");
            test.Pass("Negative CollegeUniversityName value verified.");

            Assert.That(educationPage.GetTitle(), Is.Not.EqualTo(title1), "Title should not match the expected value.");
            test.Pass("Negative Title value verified.");

            Assert.That(educationPage.GetDegree(), Is.Not.EqualTo(degree1), "Degree should not match the expected value.");
            test.Pass("Negative Degree value verified.");

            Assert.That(educationPage.GetYear(), Is.Not.EqualTo(year1), "Year should not match the expected value.");
            test.Pass("Negative Year value verified.");


        }
        [Test]
        [Order(3)]
        public void EditEducationTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting EditEducationTest...");

            // Read the JSON file
            string jsonFilePath = "C:\\Users\\Ivica\\Desktop\\MarsCompetitionTask\\MarsCompetition\\JSONData\\edit_education.json";
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON into the  object  CertificationDataModel
            EducationDataModel educationDataModel = JsonConvert.DeserializeObject<EducationDataModel>(jsonContent);

            // Access the values from the DataModel object
            string country = educationDataModel.country;
            string university = educationDataModel.university;
            string title = educationDataModel.title;
            string degree = educationDataModel.degree;
            string year = educationDataModel.year;

            EducationPage educationPage = new EducationPage();
            educationPage.EditEducation(educationDataModel);

            // Assert the results and log the test step in the Extent Report
            Assert.That(educationPage.GetEditEducationCountry(), Is.EqualTo(country), "Certificate should match the expected value.");
            test.Pass("CountryOfCollege value verified.");

            Assert.That(educationPage.GetCollegeUniversityName(), Is.EqualTo(university), "From should match the expected value.");
            test.Pass("CollegeUniversityName value verified.");

            Assert.That(educationPage.GetEditTitle(), Is.EqualTo(title), "Year should match the expected value.");
            test.Pass("Title value verified.");

            Assert.That(educationPage.GetEditDegree(), Is.EqualTo(degree), "From should match the expected value.");
            test.Pass("Degree value verified.");

            Assert.That(educationPage.GetEditYear(), Is.EqualTo(year), "Year should match the expected value.");
            test.Pass("Year value verified.");
        }
        [Test]
        [Order(4)]
        public void TestDeleteButton()
        {
            // Log the test step in the Extent Report
            test.Info("Starting TestDeleteButton...");

            EducationPage educationPage = new EducationPage();
            educationPage.DeleteEducationButton();

            // Assert the results and log the test step in the Extent Report
            bool isRowDeleted = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table")).Count == 1;
            Assert.IsTrue(isRowDeleted, "The table row was not deleted successfully.");
            test.Pass("TestDeleteButton Passed");
        }

        


    }
}
