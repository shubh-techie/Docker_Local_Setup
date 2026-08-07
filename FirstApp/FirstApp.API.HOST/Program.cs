using System.Text.Json;
using FirstApp.Configuration;

namespace FirstApp.API.HOST;

class Program
{
    static Customer customer;
    
    static void Main(string[] args)
    {
        Console.WriteLine(GetCustomer());
        Console.WriteLine("Hello, World!");
    }

    private static string GetCustomer()
    {
        customer = new Customer();
        var result = customer.GetCustomer();
        return JsonSerializer.Serialize(result);
    }
}