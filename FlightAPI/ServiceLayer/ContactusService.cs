using FlightAPI.Models;
using FlightAPI.ReopLayer;

namespace FlightAPI.ServiceLayer
{
    public class ContactusService : IContactusService<Contactu>
    {
        private readonly IContactusRepo<Contactu> _context;

        public void AddContact(Contactu contact)
        {
            
            _context.AddContact(contact);
        }

        public List<Contactu> getAll()
        {
            return _context.getAll();
        }
    }
}
