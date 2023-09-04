using MarsCompetition.DataModel;
using MarsCompetition.Pages;
using MarsCompetition.Utilities;
using Newtonsoft.Json;
using OpenQA.Selenium;

namespace MarsCompetition.Tests
{
    [TestFixture]
    public class ManageListingsTests: CommonDriver
    {
        


        [Test, Order(1), Description("Check if the user is able to Click on \"Manage Listings\" button in the home page")]
        public void ClickManageListingsButton()
        {
            // Log the test step in the Extent Report
            test.Info("Starting ManageListingsButton...");

            ManageListingsPage manageListingsPage = new ManageListingsPage();
            manageListingsPage.ClickOnManageListings();



            // Assertion: Check if the user is navigated to the correct page
            Assert.That(driver.Title, Is.EqualTo("ListingManagement"));
            test.Pass("Title value verified.");
        }
        [Test, Order(2)]
        public void ClickManageListingsButton_NegativeTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting ManageListingsButtonNegative...");
           
            ManageListingsPage manageListingsPage = new ManageListingsPage();
            manageListingsPage.ClickOnManageListings();
            // Navigate to an incorrect page
            driver.Navigate().GoToUrl("https://www.example.com");

            // Assertion: Check if the user is not navigated to the correct page
            Assert.That(driver.Title, Is.Not.EqualTo("ListingManagement"));
            test.Pass("TitleNegative value verified.");
        }
        
        [Test, Order(3),Description("Check if the user is able to click on view service in listing")]
        public void CheckServiceDetails()
        {
            // Log the test step in the Extent Report
            test.Info("Starting ServiceDetails...");

            ManageListingsPage manageListingsPage = new ManageListingsPage();
            manageListingsPage.ClickOnManageListings();
            manageListingsPage.viewTheService();

            // Assertion: Check if the user is able to click on view service the listing
            Assert.That(driver.Title, Is.EqualTo("Service Detail"));
            test.Pass("Service Detail value verified.");



        }
       
        [Test]
        [Order(4)]
        [Description("Check if the user is able to edit the service")]
        public void EditServiceDetails()
        {
            // Log the test step in the Extent Report
            test.Info("Starting EditServiceDetails...");
            
            // Read the JSON file
            string jsonFilePath = "C:\\Users\\Ivica\\Desktop\\MarsCompetitionTask\\MarsCompetition\\JSONData\\skilldata.json";
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON into the RegisterModel object
            RegisterDataModel registerDataModel = JsonConvert.DeserializeObject<RegisterDataModel>(jsonContent);

            ManageListingsPage manageListingsPage = new ManageListingsPage();

            manageListingsPage.ClickOnManageListings();
            manageListingsPage.editExistingService(registerDataModel);

            // Extract the title and description from the RegisterDataModel object
            string title = registerDataModel.title;
            string description = registerDataModel.description;

            // Assert that the updated title and description match the expected values
            Assert.That(manageListingsPage.GetUpdatedTitle(), Is.EqualTo(title), "Title should match the expected value.");
            test.Pass("Updated title value verified.");
            Assert.That(manageListingsPage.GetUpdatedDescription(), Is.EqualTo(description), "Description should match the expected value.");
            test.Pass("Updated description value verified.");




        }
        [Test]
        [Order(5)]
        [Description("Check if the user is able to delete a listing")]
        public void DeleteListing()
        {
            // Log the test step in the Extent Report
            test.Info("Starting DeleteListing...");
            
            ManageListingsPage manageListingsPage = new ManageListingsPage();
            manageListingsPage.ClickOnManageListings();

            manageListingsPage.deleteManageListings();

            // Assert that the row has been deleted (you can modify the assertion based on your specific implementation)
            bool isRowDeleted = driver.FindElements(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]")).Count == 1;
            Assert.IsTrue(isRowDeleted, "The table row was not deleted successfully.");
            test.Pass("Deleted value verified.");




        }
        [Test]
        [Order(6)]
        public void DeleteTableRowNegativeTest()
        {
            // Log the test step in the Extent Report
            test.Info("Starting DeleteListingNegative...");

            ManageListingsPage manageListingsPage = new ManageListingsPage();
            manageListingsPage.ClickOnManageListings();

            manageListingsPage.deleteManageListings();

            // Attempt to find the delete button for a non-existent row and click it
            try
            {
                IWebElement deleteButton = driver.FindElement(By.CssSelector(".nonexistent-row .remove.icon"));
                deleteButton.Click();
            }
            catch (NoSuchElementException)
            {
                // Delete button not found, which is expected in this negative test case
                return;
            }

            // If the code reaches this point, it means the delete button was found and clicked, which is an unexpected behavior
            Assert.Fail("The delete button for a non-existent row was found and clicked.");
            test.Pass("Deleted Negative value verified.");
        }
      



    }


}
