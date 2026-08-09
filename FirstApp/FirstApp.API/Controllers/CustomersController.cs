using FirstApp.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CustomersController : ControllerBase
{
    private readonly Customer _customer;

    public CustomersController()
    {
        _customer = new Customer();
    }

    [HttpGet]
    public ActionResult<Customer> GetSample()
    {
        return Ok(_customer.GetCustomer());
    }
}
