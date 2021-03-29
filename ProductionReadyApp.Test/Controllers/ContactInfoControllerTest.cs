using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductionReadyApp_API.Controllers;
using ProductionReadyApp_API.Models;
using ProductionReadyApp_API.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductionReadyApp.Test.Controllers
{
    [TestClass]
    public class ContactInfoControllerTest
    {
        private readonly Mock<IContactInfoRepo<ContactInfo>> _contactInfoRepoMock;
        private readonly ContactInfoController _contactInfoControllerMock;
        public ContactInfoControllerTest()
        {
            _contactInfoRepoMock = new Mock<IContactInfoRepo<ContactInfo>>();
            _contactInfoControllerMock = new ContactInfoController(_contactInfoRepoMock.Object);
        }

        List<ContactInfo> contactInfoListFake = new List<ContactInfo>
            {
                new ContactInfo{ID=1 , Email="mock_email@gmal.com", FirstName="mockFirstName",LastName="mockLastName", PhoneNumber="8888888888", Status="active"}
        };

        ContactInfo contactInfoFake = new ContactInfo
        {
            ID = 1,
            Email = "mock_email@gmal.com",
            FirstName = "mockFirstName",
            LastName = "mockLastName",
            PhoneNumber = "8888888888",
            Status = "active"
        };

        [TestMethod]
        public void ContactInfo_GetAll_Test()
        {
            _contactInfoRepoMock.Setup(p => p.GetAll()).Returns(contactInfoListFake);
            var result= _contactInfoControllerMock.Get();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ContractInfo_GetAll_CheckNull_Test()
        {
            var emptyContactInfoFake = new List<ContactInfo> { };
            _contactInfoRepoMock.Setup(p => p.GetAll()).Returns(emptyContactInfoFake);
            var result = _contactInfoControllerMock.Get();
            Assert.IsTrue(((ObjectResult)result).Value.ToString().IndexOf("404") > 0);
        }

        [TestMethod]
        public void ContactInfo_Get_Test()
        {
            _contactInfoRepoMock.Setup(p => p.Get(1)).Returns(contactInfoFake);
            var result = _contactInfoControllerMock.Get(1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ContactInfo_Get_CheckNull_Test()
        {
            contactInfoFake = null;
            _contactInfoRepoMock.Setup(p => p.Get(1)).Returns(contactInfoFake);
            var result = _contactInfoControllerMock.Get(1);
            Assert.IsNull(contactInfoFake);
            Assert.IsTrue(((ObjectResult)result).Value.ToString().IndexOf("404") > 0);
        }

        [TestMethod]
        public void ContactInfo_Post_Test()
        {
            _contactInfoRepoMock.Setup(p => p.Add(contactInfoFake));
            var result = _contactInfoControllerMock.Post(contactInfoFake);
            Assert.IsTrue(((ObjectResult)result).Value.ToString().IndexOf("201") > 0);
        }

        [TestMethod]
        public void ContactInfo_Post_CheckNull_Test()
        {
            contactInfoFake = null;
            _contactInfoRepoMock.Setup(p => p.Add(contactInfoFake));
            var result = _contactInfoControllerMock.Post(contactInfoFake);
            //Check Bad Request code
            Assert.IsTrue(((ObjectResult)result).Value.ToString().IndexOf("400") > 0);
        }

        [TestMethod]
        public void ContactInfo_Put_Test()
        {
            _contactInfoRepoMock.Setup(x => x.Get(1)).Returns(contactInfoFake);
            var result = _contactInfoControllerMock.Put(1, contactInfoFake);
            Assert.IsTrue(((ObjectResult)result).Value.ToString().IndexOf("200") > 0);
        }

        [TestMethod]
        public void ContactInfo_Put_CheckNull_Test()
        {
            contactInfoFake = null;
            _contactInfoRepoMock.Setup(x => x.Get(2)).Returns(contactInfoFake);
            var result = _contactInfoControllerMock.Put(2,contactInfoFake);
            Assert.IsTrue(((ObjectResult)result).Value.ToString().IndexOf("400") > 0);
        }

        [TestMethod]
        public void ContactInfo_Delete_Test()
        {
            _contactInfoRepoMock.Setup(x => x.Get(1)).Returns(contactInfoFake);
            var result = _contactInfoControllerMock.Delete(1);
            Assert.IsTrue(((ObjectResult)result).Value.ToString().IndexOf("200") > 0);
        }

        [TestMethod]
        public void ContactInfo_Delete_CheckNull_Test()
        {
            contactInfoFake = null;
            _contactInfoRepoMock.Setup(x => x.Get(2)).Returns(contactInfoFake);
            var result = _contactInfoControllerMock.Delete(2);
            Assert.IsTrue(((ObjectResult)result).Value.ToString().IndexOf("404") > 0);
        }
    }
}
