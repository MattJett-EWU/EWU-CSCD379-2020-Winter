using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SecretSanta.Business.Tests
{
    // MethodBeingTested_ConditionBeingTested_WhatWeExpectedToHappen
    [TestClass]
    public class BlogPostTest
    {
        [TestMethod]
        public void Create_BlogPost_Success()
        {
            // Arrange
            const string title = "Sample Blog Post";
            const string content = "Hello my name is...";
            const string author = "Matthew Jett";

            // Act
            var blogPost = new BlogPost(
                title,
                content,
                DateTime.Now,
                author);

            // Assert
            Assert.AreEqual(title, blogPost.Title, "Title value is unexpected");
            Assert.AreEqual(content, blogPost.Content, "Content value is unexpected");
            Assert.AreEqual(author, blogPost.Author, "Author value is unexpected");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_PropertiesAreNotNotNull_NotNull()
        {
            // Arrange
            string title = null;
            string content = "hjldsjkdhs";
            string author = "jklasjas";

            // Act
            var blogPost = new BlogPost(
                title,
                content,
                DateTime.Now,
                author);

            // Assert
            Assert.AreEqual(title, blogPost.Title, "Title value is unexpected");
            Assert.AreEqual(content, blogPost.Title, "Content value is unexpected");
            Assert.AreEqual(author, blogPost.Title, "Author value is unexpected");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Properties_AssignNull_ThrowArgumentNullException()
        {
            var blogPost = new BlogPost("", "", DateTime.Now, "");
            blogPost.Content = null;
        }
    }
}
