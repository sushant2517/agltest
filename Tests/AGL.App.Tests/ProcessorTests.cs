using System;
using System.Collections.Generic;
using System.Linq;
using AGL.Domain;
using AGL.Service.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;

namespace AGL.App.Tests
{
    [TestClass]
    public class ProcessorTests
    {
        [TestMethod]
        public void Given_GetResponseIsCalled_Then_GetPeopleIsCalled_Once()
        {
            var peopleServiceMock = new Mock<IPeopleDataService>();
            peopleServiceMock.Setup(x => x.GetPeople()).ReturnsAsync(new List<Person>()).Verifiable();

            var processor = new Processor(peopleServiceMock.Object);
            var result = processor.GetResponse().Result;

            peopleServiceMock.Verify(x => x.GetPeople(),Times.Once);
        }

        [TestMethod]
        public void Given_GetResponseIsCalled_Then_Expected_Response_Is_Returned()
        {
            var peopleServiceMock = new Mock<IPeopleDataService>();
            peopleServiceMock.Setup(x => x.GetPeople())
                .ReturnsAsync(
                    JsonConvert.DeserializeObject<IEnumerable<Person>>(
                        "[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"}]},{\"name\":\"Steve\",\"gender\":\"Male\",\"age\":45,\"pets\":null},{\"name\":\"Fred\",\"gender\":\"Male\",\"age\":40,\"pets\":[{\"name\":\"Tom\",\"type\":\"Cat\"},{\"name\":\"Max\",\"type\":\"Cat\"},{\"name\":\"Sam\",\"type\":\"Dog\"},{\"name\":\"Jim\",\"type\":\"Cat\"}]},{\"name\":\"Samantha\",\"gender\":\"Female\",\"age\":40,\"pets\":[{\"name\":\"Tabby\",\"type\":\"Cat\"}]},{\"name\":\"Alice\",\"gender\":\"Female\",\"age\":64,\"pets\":[{\"name\":\"Simba\",\"type\":\"Cat\"},{\"name\":\"Nemo\",\"type\":\"Fish\"}]}]"));

            var processor = new Processor(peopleServiceMock.Object);
            var result = processor.GetResponse().Result;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() == 2);
        }
    }
}
