namespace LogicalQuestion1
{
    internal class Program
    {
        static void Main()
        {
            ContactStorage storage = new ContactStorage();

            // Create a list of contacts
            List<Contact> contacts = new List<Contact>
        {
            new Contact { Id = "1", Name = "John Doe", PhoneNumber = "123-456-7890", Email = "john.doe@example.com" },
            new Contact { Id = "2", Name = "Jane Smith", PhoneNumber = "987-654-3210", Email = "jane.smith@example.com" }
        };

            // Save the contacts to a file
            string filePath = "contacts.dat";
            storage.SaveContactsToFile(contacts, filePath);
            Console.WriteLine("Contacts saved successfully.");

            // Load the contacts from the file
            List<Contact> loadedContacts = storage.LoadContactsFromFile(filePath);
            Console.WriteLine("Contacts loaded successfully.");

            // Display the loaded contacts
            foreach (var contact in loadedContacts)
            {
                Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.Email}");
            }
        }
    }
}