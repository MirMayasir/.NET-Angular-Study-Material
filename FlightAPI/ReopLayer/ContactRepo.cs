using FlightAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace FlightAPI.ReopLayer
{
    public class ContactRepo : IContactusRepo<Contactu>
    {
        private readonly FlightDatabaseContext _context;

        public ContactRepo(FlightDatabaseContext contact)
        {
            _context = contact;
        }
        public void AddContact(Contactu contact)
        {
            _context.Contactus.Add(contact);
            _context.SaveChanges();
        }

        public List<Contactu> getAll()
        {
            return _context.Contactus.ToList();
        }
    }
}
