using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SecretSanta.Business.Tests
{
    // MethodBeingTested_ConditionBeingTested_WhatWeExpectedToHappen
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void Create_User_Success()
        {
            // Arrange
            const int id = 1234;
            const string fname = "Test Title";
            const string lname = "Example description...";
            var gifts = new List<Gift>();

            // Act
            var user = new User(
                id,
                fname,
                lname,
                gifts);

            // Assert
            Assert.AreEqual(id, user.Id, "ID was unexpected");
            Assert.AreEqual(fname, user.FirstName, "Firstname value was unexpected");
            Assert.AreEqual(lname, user.LastName, "Lastname content was unexpected");
            Assert.AreEqual(gifts, user.Gifts, "List of gifts not found");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("", "<lastname>")]
        [DataRow("<firstname>", "")]
        public void Create_PropertiesWhiteSpace_ThrowArgumentException(string fname, string lname)
        {
            // Arrange
            var gifts = new List<Gift>();
            // Act
            _ = new User(
                0,
                fname,
                lname,
                gifts);
            // Assert
            // handled from method attributes
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [DataRow(0, null, "<lastname>")]
        [DataRow(0, "<firstname>", null)]
        public void Create_PropertiesAreNull_ThrowArgumentNullException(int id, string fname, string lname)
        {
            // Arrange
            var gifts = new List<Gift>();
            // Act
            _ = new User(
                id,
                fname,
                lname,
                gifts);
            // Assert
            // handled from method attributes
        }
    }
}
