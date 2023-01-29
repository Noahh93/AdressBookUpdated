using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adressbok;
using Newtonsoft.Json;

namespace AdressBookTests
{
    [TestClass]
    public class FileSaveTest
    {
        [TestMethod]
        public void Test_Save_Result_Success()
        {

            Contact PersonContact = new Contact();
            PersonContact.FirstName = "Noah";
            PersonContact.LastName = "Amin";
            PersonContact.Email = "Noah_33@homail.com";
            PersonContact.PhoneNumber = "1234567890";
            PersonContact.StreetAddress = "WashingtonStreet";
            PersonContact.ZipCode= "1234567890";
            PersonContact.City= "NewYork";

            FileSave file = new FileSave();
            string filePath = @"C:\Users\Noah\Desktop\ContactList.json";
            string Content = JsonConvert.SerializeObject(PersonContact);
            bool isSaved = file.Save(filePath, Content);
            Assert.IsTrue(isSaved);
        }
        [TestMethod]
        public void Test_Save_Result_WrongPath_UnSuccessful()
        {
            Contact PersonContact = new Contact();
            PersonContact.FirstName = "Noah";
            PersonContact.LastName = "Amin";
            PersonContact.Email = "Noah_33@homail.com";
            PersonContact.PhoneNumber = "1234567890";
            PersonContact.StreetAddress = "WashingtonStreet";
            PersonContact.ZipCode = "1234567890";
            PersonContact.City = "NewYork";

            FileSave file = new FileSave();
            string filePath = @"C:\Users\WrongPath\Desktop\ContactList.json";
            string Content = JsonConvert.SerializeObject(PersonContact);
            bool isSaved = file.Save(filePath, Content);
            Assert.IsFalse(isSaved);
        }
        [TestMethod]
        public void Test_Read_FileSave()
        {
            Contact PersonContact = new Contact();

            FileSave file = new FileSave();
            string filePath = @"C:\Users\Noah\Desktop\ContactList.json";
            string content = file.Read(filePath);

            Assert.IsNotNull(content);
        }
        [TestMethod]
        public void Test_Read_WrongFilePath_Unsuccessful()
        {
            Contact PersonContact = new Contact();

            FileSave file = new FileSave();
            string filePath = @"C:\Users\Noah\WrongPath\ContactList.json";
            string content = file.Read(filePath);

            Assert.IsNull(content);
        }
    }
}
