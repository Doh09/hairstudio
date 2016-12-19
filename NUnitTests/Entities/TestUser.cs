﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hairstudio_DLL.Entities;
using NUnit.Framework;

namespace NUnitTests.Entities
{
    [TestFixture]
    public class TestUser
    {
        [Test]
        public void TestProperties()
        {
            /*User : IEntity
            - ID
            - Username
            - Password
            - Name
            - Phone Number
            - Email
            - UserType(string)*/
            User user = new User();
            //Assert that all simple properties do as expected.
            user.ID = 0;
            user.Username = "Username";
            user.Password = "passWord";
            user.Name = "name";
            user.PhoneNumber = 88888888;
            user.Email = "email@gmail.com";
            user.UserType = "Admin";
            Assert.AreEqual(user.ID, 0);
            Assert.AreEqual(user.Username, "Username");
            Assert.AreEqual(user.Password, "passWord");
            Assert.AreEqual(user.Name, "name");
            Assert.AreEqual(user.PhoneNumber, 88888888);
            Assert.AreEqual(user.Email, "email@gmail.com");
            Assert.AreEqual(user.UserType, "Admin");
        }
    }
}
