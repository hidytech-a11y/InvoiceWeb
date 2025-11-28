using InvoiceWeb.AppData;
using InvoiceWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceWeb.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly InvoiceContext context;

        public InvoicesController(InvoiceContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var invoices = context.Invoices.OrderByDescending(inv => inv.Id).ToList();
            return View(invoices);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(InvoiceDto invoiceDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            //Create a new Invoice
            var invoice = new Invoice
            {
                Number = invoiceDto.Number,
                Status = invoiceDto.Status,
                IssueDate = invoiceDto.IssueDate,
                DueDate = invoiceDto.DueDate,

                Service = invoiceDto.Service,
                UnitPrice = invoiceDto.UnitPrice,
                Quantity = invoiceDto.Quantity,

                ClientName = invoiceDto.ClientName,
                Email = invoiceDto.Email,
                Phone = invoiceDto.Phone,
                Address = invoiceDto.Address ?? ""
            };
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var invoice = context.Invoices.Find(id);
            if (invoice == null)
            {
                return NotFound();
            }
            var invoiceDto = new InvoiceDto
            {
                Number = invoice.Number,
                Status = invoice.Status,
                IssueDate = invoice.IssueDate,
                DueDate = invoice.DueDate,

                Service = invoice.Service,
                UnitPrice = invoice.UnitPrice,
                Quantity = invoice.Quantity,

                ClientName = invoice.ClientName,
                Email = invoice.Email,
                Phone = invoice.Phone,
                Address = invoice.Address
            };

            ViewBag.InvoiceId = invoice.Id;

            return View(invoiceDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, InvoiceDto invoiceDto)
        {
            var invoice = context.Invoices.Find(id);
            if (invoice == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.InvoiceId = id;
                return View();
            }


            //Edit the invoice
            invoice.Number = invoiceDto.Number;
            invoice.Status = invoiceDto.Status;
            invoice.IssueDate = invoiceDto.IssueDate;
            invoice.DueDate = invoiceDto.DueDate;

            invoice.Service = invoiceDto.Service;
            invoice.UnitPrice = invoiceDto.UnitPrice;
            invoice.Quantity = invoiceDto.Quantity;

            invoice.ClientName = invoiceDto.ClientName;
            invoice.Email = invoiceDto.Email;
            invoice.Phone = invoiceDto.Phone;
            invoice.Address = invoiceDto.Address ?? "";

            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var invoice = context.Invoices.Find(id);
            if (invoice != null)
            {
                context.Invoices.Remove(invoice);
                context.SaveChanges();
            }
           
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var invoice = context.Invoices.Find(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return View(invoice);
        }
    }
}
