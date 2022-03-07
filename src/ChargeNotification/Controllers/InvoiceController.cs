using ChargeNotification.Data;
using ChargeNotification.Models;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace ChargeNotification.Controllers;

public class InvoiceController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<HomeController> _logger;

    public InvoiceController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// View pdf generation as IActionResult
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    // [Route("{id:int}")]
    public IActionResult Invoice(int id)
    {
        Customer? customer = this._context.Customers.FirstOrDefault(i => i.CustomerId == id);

        List<GameCharge>? charges = this._context.GameCharges
                        .Where(i => i.CustomerId == id)
                        .ToList();

        if (customer == null || charges == null)
        {
            return NotFound();
        }
        Notification notification = new()
        {
            CustomerNumber = customer.CustomerId,
            CustomerName = customer.CustomerName,
            Charges = charges
        };
        // return new ViewAsPdf(notification);
        return View(notification);
    }

}