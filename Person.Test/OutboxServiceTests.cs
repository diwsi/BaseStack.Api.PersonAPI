using MediatRDispatcher;
using Person.API.Person;
using AutoMapper;
using Person.Domain.Maps;
using Person.Domain.Commands.NewPerson;
using EFAdapter;
using Person.Domain.Services.Outbox;
using Repository;
using Person.Domain.Entities;

namespace Person.Test
{
    [TestClass]
    public class OutboxServiceTests: BaseTest
    {
        [TestMethod]
        public async Task Save_Outbox()
        {
            // Arrange
            var uow =InitUOW();
            var repository = new EFRepository<Outbox>(uow);
            var service = new OutboxService(repository, uow);
            var testData = new Domain.DTO.OutBoxDTO()
            {
                Data = new
                {
                    a = 1,
                    b = 2
                },
                DataType = "unitTest",
                ID =Guid.NewGuid()
            };
            //Act
            service.SaveOutBox(testData);
           await uow.Save();
            //Assert
            var entry = DB.Outbox.FirstOrDefault(d => d.DataID == testData.ID);
            Assert.IsNotNull(entry);
            Assert.IsTrue(entry.DataType == "unitTest");
        }
    }
}
