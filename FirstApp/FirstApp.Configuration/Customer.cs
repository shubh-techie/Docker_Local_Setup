namespace FirstApp.Configuration;

public class Customer
{
    public  int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }

    public Customer GetCustomer()
    {
        return new Customer()
        {
            Id = 1001,
            Name = "John Doe",
            Address = "123 Main Street",
            City = "London"
        };
    }
}