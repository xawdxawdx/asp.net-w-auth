using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DanilaWebApp.IRepositories;
using DanilaWebApp.Models;
using DanilaWebApp.Services;
using Moq;
using Xunit;

namespace XUnitTestDanilaChudom
{
    public class UnitTest1
    {
        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IAddressRepository>();
            var AddresService = new Addresservice(fakeRepository);
            var Address = new Address() { City = "Almaty", Id = 1 };
            await AddresService.AddAndSafe(Address);
        }

        [Fact]
        public async Task GetAddressTest()
        {
            var Addresss = new List<Address>
            {
                new Address() {City = "Almaty", Id = 1 },
                new Address() {City = "Nursultan", Id = 2 },
            };

            var fakeRepositoryMock = new Mock<IAddressRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(Addresss);


            var AddressService = new Addresservice(fakeRepositoryMock.Object);

            var resultAddresss = await AddressService.GetAddresss();

            Assert.Collection(resultAddresss, Address => { Assert.Equal(1,Address.Id); }, Address => { Assert.Equal(2, Address.Id); });
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<IAddressRepository>();
            var AddressService = new Addresservice(fakeRepository);
            int AddressId = 1;
            await AddressService.Delete(AddressId);
        }

        [Fact]
        public async Task EditTest()
        {
            var fakeRepository = Mock.Of<IAddressRepository>();
            var AddressService = new Addresservice(fakeRepository);
            var Address = new Address() { City = "Alakol", Id = 1 };
            await AddressService.Edit(Address);
        }

        [Fact]
        public async Task GetAddressByIdTest()
        {
            int id = 1;
            var Address2 = new Address() { City = "Almaty", Id = 1 };

            var fakeRepositoryMock = new Mock<IAddressRepository>();
            fakeRepositoryMock.Setup(x => x.GetAddressById(id)).ReturnsAsync(Address2);

            var AddressService = new Addresservice(fakeRepositoryMock.Object);
            var resultAddress = await AddressService.GetAddressById(id);
            Assert.Equal(1, resultAddress.Id);
        }

        [Fact]
        public void AddressExistsTest()
        {
            int AddressId = 1;

            var fakeRepositoryMock = new Mock<IAddressRepository>();
            fakeRepositoryMock.Setup(x => x.AddressExistAndId(AddressId)).Returns(true);

            var AddressService = new Addresservice(fakeRepositoryMock.Object);

            var isExist = AddressService.IsAddressExist(AddressId);

            Assert.True(isExist);
        }
    }
}
