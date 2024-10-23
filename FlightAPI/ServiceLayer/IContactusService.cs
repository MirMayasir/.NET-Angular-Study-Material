namespace FlightAPI.ServiceLayer
{
    public interface IContactusService<Contactu>
    {
        List<Contactu> getAll();
        void AddContact(Contactu contact);


    }
}
