using System;
using System.Linq;
using System.Net.Http;
using AGL.Service.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AGL.Service.Concretes;

namespace AGL.Service.Tests
{
    [TestClass]
    public class PeopleDataServiceTests
    {
        [TestMethod]
        public void Given_GetPeople_IsCalled_When_HttpClient_Returns_SuccessStatus_Then_Result_Is_Returned()
        {
            var httpHandlerMock = new MockHttpHandlerValidResponse();

            var peopleDataService = new PeopleDataService(httpHandlerMock);
            var response = peopleDataService.GetPeople().Result;

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count() == 6);
        }

        [TestMethod]
        public void Given_GetPeople_IsCalled_When_HttpClient_Returns_Error_Then_NullResult_Is_Returned()
        {
            var httpHandlerMock = new MockHttpHandlerErrorResponse();

            var peopleDataService = new PeopleDataService(httpHandlerMock);
            var response = peopleDataService.GetPeople().Result;

            Assert.IsNull(response);
        }
    }
}
