namespace customer;

public class Customer{
    public string FirstName{get; set;}
    public string LastName{get; set;}
    public string Email{get; set;}
    public string Password{get; set;}

    public Customer(string firstName, string lastName, string email, string password){
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Password = password;
    }
}