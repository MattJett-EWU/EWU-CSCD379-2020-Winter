using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SecretSanta.Business.Tests
{
    // MethodBeingTested_ConditionBeingTested_WhatWeExpectedToHappen
    [TestClass]
    public class GiftTests
    {
        [TestMethod]
        public void Create_Gift_Success()
        {
            // Arrange
            const int id = 1234;
            const string title = "Test Title";
            const string description = "Example description...";
            const string url = "www.something.com";
            var user = new User(100, "Bob", "Smith", new List<Gift>());

            // Act
            var gift = new Gift(
                id,
                title,
                description,
                url,
                user);

            // Assert
            Assert.AreEqual(id, gift.Id, "ID was unexpected");
            Assert.AreEqual(title, gift.Title, "Title value was unexpected");
            Assert.AreEqual(description, gift.Description, "Description content was unexpected");
            Assert.AreEqual(url, gift.Url, "Url value was unexpected");
            Assert.AreEqual(user, gift.User, "User not found");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("", "test description", "www.url.com")]
        public void Create_TitleWhiteSpace_ThrowArgumentException(string title, string description, string url)
        {
            // Arrange
            // Act
            _ = new Gift(
                0,
                title,
                description,
                url,
                new User());
            // Assert
            // handled from method attributes
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [DataRow(null, "test description", "www.url.com")]
        [DataRow("untitled title", null, "www.url.com")]
        [DataRow("untitled title", "test description", null)]
        public void Create_PropertiesAreNull_ThrowArgumentNullException(string title, string description, string url)
        {
            // Arrange
            // Act
            _ = new Gift(
                0,
                title,
                description,
                url,
                new User());
            // Assert
            // handled from method attributes
        }
    }
}
