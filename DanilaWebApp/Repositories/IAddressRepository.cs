using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DanilaWebApp.Data;
using DanilaWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DanilaWebApp.IRepositories
{
    public class AddressRepository:IAddressRepository
    {
        readonly DataContext _context;

        public AddressRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Address Address)
        {
            _context.Add(Address);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var Address = _context.Addresses.Find(id);
            _context.Remove(Address);
        }

        public Task<List<Address>> GetAll()
        {
            return _context.Addresses.ToListAsync();
        }

        public Task<List<Address>> GetAddresses(Expression<Func<Address, bool>> predicate)
        {
            return _context.Addresses.Where(predicate).ToListAsync();
        }

        public void Edit(Address Address)
        {
            _context.Update(Address);
        }

        public Task<Address> GetAddressById(int id)
        {
            return _context.Addresses.FirstOrDefaultAsync(m => m.Id == id);
        }

        public bool AddressExistAndId(int id)
        {
            return _context.Addresses.Any(m => m.Id == id);
        }

    }
}
