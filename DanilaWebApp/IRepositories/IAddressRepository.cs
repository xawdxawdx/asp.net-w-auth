using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DanilaWebApp.Models;

namespace DanilaWebApp.IRepositories
{
    public interface IAddressRepository
    {
        void Add(Address Address);

        Task Save();

        void Delete(int id);

        Task<List<Address>> GetAll();

        Task<List<Address>> GetAddresses(Expression<Func<Address, bool>> predicate);

        void Edit(Address Address);

        Task<Address> GetAddressById(int id);

        bool AddressExistAndId(int id);
    }
}
