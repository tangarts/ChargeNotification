using ChargeNotification.Data;
using ChargeNotification.Models;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace ChargeNotification.Controllers;

[ApiController]
[Route("api/[controller]")]

public class InvoiceController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<HomeController> _logger;

    public InvoiceController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    /// <summary>
    /// View pdf generation as IActionResult
    /// </summary>
    /// <returns>IAction result of a pdf or html rendered View</returns>
    /// <param name="id">
    /// The customer Id.
    /// </param>
    /// <param name="date">
    /// The invoice date - defaults to today's date.
    /// </param>
    /// <param name="pdf">
    /// Whether to generate pdf or not - defaults to true
    /// </param>
    [HttpGet]
    [Route("{id:int}")]
    public IActionResult Invoice(int id, DateTime date = default, bool pdf = true)
    {
        DateOnly chargeDate = date != default ?
                DateOnly.FromDateTime(date) :
                DateOnly.FromDateTime(DateTime.Now);
        // Customer? customer = this._context.Customers.FirstOrDefault(i => i.Id == id);

        Customer? customer = this._context.Customers.Find(id);

        List<GameCharge>? charges = this._context.GameCharges
                        .Where(i => i.CustomerId == id &&
                               i.ChargeDate == chargeDate)
                        .ToList();

        if (customer == null || charges == null)
        {
            return NotFound();
        }
        Invoice invoice = new()
        {
            CustomerNumber = customer.Id,
            CustomerName = customer.Name,
            Charges = charges
        };
        if (pdf)
        {
            return new ViewAsPdf(invoice)
            {
                FileName = $"{invoice.CustomerName}-{chargeDate}.pdf"
            };
        }
        return View(invoice);

    }
}