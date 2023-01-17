namespace FirstApp.Models;

public class BookManager{
    public static List<Book> getAllBooks(){
        List<Book> allBooks = new List<Book>();
        allBooks.Add(new Book("Shoot Dive Fly","Rachna Rawat",300,5.0));
        allBooks.Add(new Book("The Kargil War","Rachna Rawat",350,4.5));
        allBooks.Add(new Book("Insomnia Army stories","Rachna Rawat",250,4));
        allBooks.Add(new Book("The Monk who sold his Ferrari","Robin Sharma",250,4));
        allBooks.Add(new Book("The 5AM Club","Robin Sharma",200,5));
        allBooks.Add(new Book("The Alchemist","Paulo Caulo",250,4.5));
        allBooks.Add(new Book("My Experiment with Truth","MG Gandhi",350,5));
        allBooks.Add(new Book("Half Girlfriend","Chetan Bhagat",300,5));

        return allBooks;
    }
}