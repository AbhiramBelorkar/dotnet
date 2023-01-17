namespace FirstApp.Models;

public class Book{
    public string Name{get;set;}
    public string Author{get;set;}
    public double Price{get;set;}
    public double Stars{get;set;}

    public Book(string name, string author, double price, double stars){
        this.Name = name;
        this.Author = author;
        this.Price = price;
        this.Stars = stars;
    }
}