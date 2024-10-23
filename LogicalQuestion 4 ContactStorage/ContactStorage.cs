using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace LogicalQuestion1
{
    public class ContactStorage
    {
        public void SaveContactsToFile(List<Contact> contacts, string filePath)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(contacts, options);
                File.WriteAllText(filePath, jsonString);
            }
            catch (IOException ex)
            {
                throw new IOException("An error occurred while writing to the file.", ex);
            }
            catch (JsonException ex)
            {
                throw new JsonException("The object cannot be serialized to JSON.", ex);
            }
        }

        public List<Contact> LoadContactsFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The file does not exist.");
            }

            try
            {
                string jsonString = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Contact>>(jsonString);
            }
            catch (IOException ex)
            {
                throw new IOException("An error occurred while reading from the file.", ex);
            }
            catch (JsonException ex)
            {
                throw new JsonException("The data in the file cannot be deserialized from JSON.", ex);
            }
        }
    }
}
