using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Library_Management_System;
internal class Program
{
   static void Main(string[] args)
    {
       Book book1=new Book(1,"Shabeeb","Ahmed_khaled_tawfik");
       Book book2 = new Book(2, "Uotubia", "Ahmed_khaled_tawfik");
       Book book3 = new Book(3, "Room 207", "Ahmed_khaled_tawfik");
       Book book4 = new Book(4, "Rainbow", "Ahmed_khaled_tawfik");
       Library library = new Library();
        user user1 = new user(100100);
        user user2 = new user(100101);
        user user3 = new user(100102);
        Librarian l1=new Librarian(1,"Ahmed",3000);
        Librarian l2 = new Librarian(2, "Adham", 3500);

        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(book3);
        library.AddBook(book4);
        library.DisplayBooks();


        Console.ReadKey();
    }
}
public class Book
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string Author { get; set; }
    public bool IsAvailable { get; set; }
    public static int numOfBooks { get; set; }

    public Book(int Book_id, string Book_name, string Book_Author)
    {
        Id = Book_id;
        Name = Book_name;
        Author = Book_Author;
        IsAvailable = true;
        numOfBooks++;
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"ID:{Id} - Title: {Name} - Author: {Author} - Available: {IsAvailable}");
    }
}
public class Library
{
    public List<Book> Books { get; set; } = new List<Book>();
    public void AddBook(Book book)
    {
        Books.Add(book);
        Console.WriteLine($"Book '{book.Name}' added to the library.");
    }

    public void RemoveBook(Book book)
    {
        if (Books.Contains(book))
        {
            Books.Remove(book);
            Console.WriteLine($"Book '{book.Name}' removed from the library.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    public void DisplayBooks()
    {
        foreach (var book in Books)
        {
            book.DisplayInfo();
        }
    }

}
public class user
{
    public int library_card { get; set; }
    public user(int cardNumber)
    {
        library_card = cardNumber;
    }
    List<Book> borrowed_books = new List<Book>();
    public void BorrowBook( Book book)
    {
        if (book.IsAvailable)
        {
            book.IsAvailable = false;
            borrowed_books.Add(book);
            Console.WriteLine("user Has Number" + library_card + "borrow Book" + book.Name);
        }
        else
        {
            Console.WriteLine($"Book '{book.Name}' is not available.");
        }
    }
    public void ReturnBook( Book book)
    {
        if (borrowed_books.Contains(book))
        {
  borrowed_books.Remove(book);
        book.IsAvailable =true;
        Console.WriteLine("user Has Number" + library_card + "Return Book" + book.Name);
        }
        else
        {
            Console.WriteLine("You don’t have this book.");
        }
    }
    public void DisplayBorrowedBooks()
    {
        Console.WriteLine($"Books borrowed by user {library_card}:");
        foreach (var book in borrowed_books)
        {
            Console.WriteLine(book.Name);
        }
    }


}

public class Librarian
{
    public int id {  get; set; }
    public string name { get; set; }
    public int salary { get; set; }
    public Librarian(int id, string name, int salary)
    {
        this.id = id;
        this.name = name;
        this.salary = salary;
    }

  
    public List<Book> books = new List<Book>();
    public void AddBookToLibrary(Book book, Library library)
    {
        library.AddBook(book);
    }

    public void RemoveBookFromLibrary(Book book, Library library)
    {
        library.RemoveBook(book);
    }

    public void DisplayLibraryBooks(Library library)
    {
        library.DisplayBooks();
    }

}


