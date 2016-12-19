using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hairstudio_DLL.Entities;
using NUnit.Framework;

namespace NUnitTests.Entities
{
    [TestFixture]
    public class TestServiceOffered
    {
        [Test]
        public void TestProperties()
        {
            /*ServiceOffered : IEntity
            - ID
            - Message
            - Price
             */
            ServiceOffered serviceOffered = new ServiceOffered();
            serviceOffered.ID = 1;
            serviceOffered.Message = "test";
            serviceOffered.Price = 159.99;
            
            Assert.AreEqual(serviceOffered.ID, 1);
            Assert.AreEqual(serviceOffered.Message, "test");
            Assert.AreEqual(serviceOffered.Price, 159.99);
        }
    }
}
