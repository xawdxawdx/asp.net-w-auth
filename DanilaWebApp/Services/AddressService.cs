using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanilaWebApp.IRepositories;
using DanilaWebApp.Models;

namespace DanilaWebApp.Services
{
    public class Addresservice
    {
        private readonly IAddressRepository _AddressRepository;

        public Addresservice(IAddressRepository AddressRepository)
        {
            _AddressRepository = AddressRepository;
        }

        public async Task<List<Address>> GetAddresss() => await _AddressRepository.GetAll();

        public async Task AddAndSafe(Address Address)
        {
            _AddressRepository.Add(Address);
            await _AddressRepository.Save();
        }

        public async Task Edit(Address Address)
        {
            _AddressRepository.Edit(Address);
            await _AddressRepository.Save();
        }

        public async Task<List<Address>> Edit(int id)
        {
            var searchedAddresss = await _AddressRepository.GetAddresses(Address => Address.Id == id);
            return searchedAddresss;
        }

        public async Task Delete(int id)
        {
            _AddressRepository.Delete(id);
            await _AddressRepository.Save();
        }

        public async Task<Address> GetAddressById(int id)
        {
            return await _AddressRepository.GetAddressById(id);
        }

        public bool IsAddressExist(int id)
        {
            return _AddressRepository.AddressExistAndId(id);
        }

    }
}
