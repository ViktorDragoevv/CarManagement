using NUnit.Framework;
using DiplomnaCarProject;
using System.Transactions;
using System.Data.SqlClient;
using MySqlConnector;

namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }
        



           
        

        [Test]
        public void Test1()
        {
            ClassDocumentDetails classDocumentDetails = new ClassDocumentDetails(0,1,1,1,1);
            
            Assert.True(classDocumentDetails.isValidData(classDocumentDetails));

        }
        [Test]
        public void Test2()
        {
            ClassDocumentDetails classDocumentDetails = new ClassDocumentDetails(1,0,0,0,0);

            Assert.True(classDocumentDetails.isDocumentInDatabase(classDocumentDetails));
            
        }
        [Test]
        public void Test3()
        {
            PeopleClass peopleClass = new PeopleClass();
            peopleClass.mail = "testsome@abv.bg";

            Assert.True(peopleClass.IsValidEmail(peopleClass.mail));

        }

    }
}