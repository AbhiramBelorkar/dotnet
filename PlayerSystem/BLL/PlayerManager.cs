namespace BLL;
using BOL;
using DAL.Connected;

using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;
public class PlayerManager
{
    public List<Player> getAllPlayers()
    {

        List<Player> allPlayers = new List<Player>();
        allPlayers = DBManager.getAllPlayersDb();
        return allPlayers;
    }

    public Player getPlayerById(int id)
    {
        List<Player> allPlayers = getAllPlayers();
        Player foundPlayer = allPlayers.Find((Player) => Player.Id == id);
        return foundPlayer;
    }

    public bool InsertPlayer(Player thePlayer){
        bool status = false;
        DBManager.Insert(thePlayer);
        return status;
    }

    public bool UpdatePlayer(Player thePlayer){
            Console.WriteLine("In updatePlayer method bll");

        bool status = DBManager.Update(thePlayer);
        return status;
    }

    public bool DeletePlayer(int id){
        bool status = DBManager.Delete(id);
        return status;
    }

    public void RegisterUser(string name, string city, string email, string password)
    {
        Console.WriteLine("In register user player manager");
        Customer c = new Customer(name,city,email,password);
        List<Customer> updatedList = Streaming.addData(c);
        var options = new JsonSerializerOptions { IncludeFields = true };
        var customerJson = JsonSerializer.Serialize<List<Customer>>(updatedList, options);
        string fileName = @"d:\customers.json";
        System.IO.File.WriteAllText(fileName, customerJson);

    }

    public bool LoginUser(string email, string password){
        string fileName = @"d:\customers.json";
        string jsonString = System.IO.File.ReadAllText(fileName);
        List<Customer> jsonCustomer = JsonSerializer.Deserialize<List<Customer>>(jsonString);
        Console.WriteLine("\n JSON :Deserializing data from json file\n \n");
        foreach (Customer c in jsonCustomer)
        {
            Console.WriteLine(c);
            if(c.Email == email && c.Password == password){
                Console.WriteLine("in desrialize");
                return true;
            }
            // Console.WriteLine($"{flower.Title} : {flower.Description}");
        }
        return false;
    }

}
