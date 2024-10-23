using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

[Serializable]
public class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
}

public class LibraryService
{
    public List<Book> Books { get; private set; } = new List<Book>();

    public void AddBook(string isbn, string title, string author)
    {
        // Validate ISBN
        if (string.IsNullOrEmpty(isbn) || isbn.Length != 13 || !isbn.All(char.IsDigit))
        {
            throw new ArgumentException("ISBN must be exactly 13 digits.");
        }

        // Validate title and author
        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author))
        {
            throw new ArgumentException("Title and author must contain at least 1 character.");
        }

        // Check for duplicate ISBN
        if (Books.Any(b => b.ISBN == isbn))
        {
            throw new ArgumentException("A book with the same ISBN already exists.");
        }

        // Add the book to the collection
        Book newBook = new Book
        {
            ISBN = isbn,
            Title = title,
            Author = author
        };

        Books.Add(newBook);

        // Save the updated list to the file
        SaveLibraryDataToFile();
    }

    public List<Book> SearchBooks(string isbn = null, string title = null, string author = null)
    {
        var query = Books.AsQueryable();

        if (!string.IsNullOrEmpty(isbn))
        {
            query = query.Where(b => b.ISBN == isbn);
        }

        if (!string.IsNullOrEmpty(title))
        {
            query = query.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(author))
        {
            query = query.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase));
        }

        return query.ToList();
    }

    public void SaveLibraryDataToFile(string filePath = "libraryData.json")
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(Books, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }
        catch (Exception ex)
        {
            // Handle errors such as file access issues
            throw new IOException("Failed to save library data to file.", ex);
        }
    }

    public void LoadLibraryDataFromFile(string filePath = "libraryData.json")
    {
        try
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                Books = JsonSerializer.Deserialize<List<Book>>(jsonString);
            }
            else
            {
                Books = new List<Book>();
            }
        }
        catch (Exception ex)
        {
            // Handle errors such as file access issues or deserialization errors
            throw new IOException("Failed to load library data from file.", ex);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        LibraryService libraryService = new LibraryService();

        // Load existing library data
        libraryService.LoadLibraryDataFromFile();

        try
        {
            // Adding a book
            libraryService.AddBook("7418529631234", "The C Programming", "Brian W. Kernighan, Dennis M. Ritchie");
            Console.WriteLine("Book added successfully.");

            // Searching for a book by title
            var books = libraryService.SearchBooks(title: "C Programming");
            Console.WriteLine("Search Results:");
            foreach (var book in books)
            {
                Console.WriteLine($"ISBN: {book.ISBN}, Title: {book.Title}, Author: {book.Author}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Save library data
        libraryService.SaveLibraryDataToFile();
    }
}
