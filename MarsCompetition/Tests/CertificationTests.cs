using MarsCompetition.DataModel;
using MarsCompetition.Pages;
using MarsCompetition.Utilities;
using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using System.Net.Http.Json;

namespace MarsCompetition.Tests
{
    public class CertificationTests : CommonDriver
    {
        

        [Test]
        [Order(1)]
        public void AddCertificationTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting AddCertificationTest...");

            // Read the JSON file
            string jsonFilePath = "C:\\Users\\Ivica\\Desktop\\MarsCompetitionTask\\MarsCompetition\\JSONData\\certification.json";
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON into the  object  CertificationDataModel
            CertificationDataModel certificationDataModel = JsonConvert.DeserializeObject<CertificationDataModel>(jsonContent);



            // Access the values from the DataModel object
            string certificate = certificationDataModel.certificate;
            string from = certificationDataModel.from;
            string year = certificationDataModel.year;

            CertificationPage certificationPage = new CertificationPage();
            certificationPage.AddCertification(certificationDataModel);

            // Assert the results and log the test step in the Extent Report
            Assert.That(certificationPage.GetCertificate(), Is.EqualTo(certificate), "Certificate should match the expected value.");
            test.Pass("Certificate value verified.");

            Assert.That(certificationPage.GetFrom(), Is.EqualTo(from), "From should match the expected value.");
            test.Pass("From value verified.");

            Assert.That(certificationPage.GetYear(), Is.EqualTo(year), "Year should match the expected value.");
            test.Pass("Year value verified.");
        }

        [Test]
        [Order(2)]
        public void AddCertificationTest_NegativeTestJson()
        {
            // Log the test step in the Extent Report
            test.Info("Starting AddCertificationTest_NegativeTestJson...");

            // Read the JSON file
            string jsonFilePath = "C:\\Users\\Ivica\\Desktop\\MarsCompetitionTask\\MarsCompetition\\JSONData\\certification.json";
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON into the  object  CertificationDataModel
            CertificationDataModel certificationDataModel = JsonConvert.DeserializeObject<CertificationDataModel>(jsonContent);

            // Access the values from the DataModel object
            string certificate = certificationDataModel.certificate;
            string from = certificationDataModel.from;
            string year = certificationDataModel.year;

            CertificationPage certificationPage = new CertificationPage();
            certificationPage.AddCertification(certificationDataModel);

            // Assert the results and log the test step in the Extent Report
            Assert.That(certificationPage.GetCertificate(), Is.EqualTo(certificate), "Certificate should match the expected value.");
            test.Pass("Certificate value verified.");

            Assert.That(certificationPage.GetFrom(), Is.EqualTo(from), "From should match the expected value.");
            test.Pass("From value verified.");

            Assert.That(certificationPage.GetYear(), Is.EqualTo(year), "Year should match the expected value.");
            test.Pass("Year value verified.");

            // Read the negative JSON file
            string jsonFilePath1 = "C:\\Users\\Ivica\\Desktop\\MarsCompetitionTask\\MarsCompetition\\JSONData\\negative_certification.json";
            string jsonContent1 = File.ReadAllText(jsonFilePath1);

            // Deserialize the JSON into the  object  CertificationDataModel
            CertificationDataModel certificationDataModel1 = JsonConvert.DeserializeObject<CertificationDataModel>(jsonContent1);

            // Access the values from the DataModel object
            string certificate1 = certificationDataModel1.certificate;
            string from1 = certificationDataModel1.from;
            string year1 = certificationDataModel1.year;
            
            // Assert the results and log the test step in the Extent Report
            Assert.That(certificationPage.GetCertificate(), Is.Not.EqualTo(certificate1), "Certificate should not match the expected value.");
            test.Pass("Negative test for Certificate passed.");

            Assert.That(certificationPage.GetFrom(), Is.Not.EqualTo(from1), "From should not match the expected value.");
            test.Pass("Negative test for From passed.");

            Assert.That(certificationPage.GetYear(), Is.Not.EqualTo(year1), "Year should not match the expected value.");
            test.Pass("Negative test for Year passed.");
        }

        [Test]
        [Order(3)]
        public void EditCertification()
        {
            // Log the test step in the Extent Report
            test.Info("Starting EditCertification...");

            // Read the JSON file
            string jsonFilePath = "C:\\Users\\Ivica\\Desktop\\MarsCompetitionTask\\MarsCompetition\\JSONData\\edit_certification.json";
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON into the  object  CertificationDataModel
            CertificationDataModel certificationDataModel = JsonConvert.DeserializeObject<CertificationDataModel>(jsonContent);

            // Access the values from the DataModel object
            string certificate = certificationDataModel.certificate;
            string from = certificationDataModel.from;
            string year = certificationDataModel.year;

            CertificationPage certificationPage = new CertificationPage();
            certificationPage.EditCertification(certificationDataModel);

            // Assert the results and log the test step in the Extent Report
            Assert.That(certificationPage.GetEditCertification(), Is.EqualTo(certificate), "Certificate should match the expected value.");
            test.Pass("Certificate value verified.");

            Assert.That(certificationPage.GetEditFrom(), Is.EqualTo(from), "From should match the expected value.");
            test.Pass("From value verified.");

            Assert.That(certificationPage.GetEditYear(), Is.EqualTo(year), "Year should match the expected value.");
            test.Pass("Year value verified.");
        }

        [Test]
        [Order(4)]
        public void TestDeleteButton()
        {
            // Log the test step in the Extent Report
            test.Info("Starting TestDeleteButton...");

            CertificationPage certificationPage = new CertificationPage();
            certificationPage.ClickDeleteButton();

            // Assert the results and log the test step in the Extent Report
            bool isRowDeleted = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table")).Count == 1;
            Assert.IsTrue(isRowDeleted, "The table row was not deleted successfully.");
            test.Pass("TestDeleteButton Passed");
        }
       
    }
}
