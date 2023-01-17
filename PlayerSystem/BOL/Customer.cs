namespace BOL;

public class Customer{
    public string Name {get; set;}
    public string City {get; set;}
    public string Email{get; set;}
    public string Password {get; set;}

    public Customer(string name, string city, string email, string password){
        this.Name = name;
        this.Email = email;
        this.Password = password;
        this.City = city;
    }
}