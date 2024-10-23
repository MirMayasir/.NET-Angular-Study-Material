using Microsoft.CodeAnalysis.Editing;
using FlightAPI.Models;
namespace FlightAPI.ReopLayer
{
    public interface IContactusRepo<Contactu>
    {
        List<Contactu> getAll();
        void AddContact(Contactu contact);
    }
}
