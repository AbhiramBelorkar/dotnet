using BOL;

// using BOL.customer;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Streaming{

    public static List<Customer> list = new List<Customer>();
    
    public static List<Customer> addData(Customer c){
        
        list.Add(c);

        return list;
    }
}