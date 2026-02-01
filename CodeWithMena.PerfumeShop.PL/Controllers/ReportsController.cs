using CodeWithMena.PerfumeShop.BLL.Contracts;
using CodeWithMena.PerfumeShop.PL.ViewModels.Reports;
using Microsoft.AspNetCore.Mvc;

namespace CodeWithMena.PerfumeShop.PL.Controllers
{
    public class ReportsController(IReportService reportService) : Controller
    {
        [HttpGet]
        public IActionResult Daily() => View();

        [HttpGet]
        public async Task<IActionResult> DailyResult([FromQuery] DateOnly? date)
        {
            var d = date ?? DateOnly.FromDateTime(DateTime.Today);
            var summary = await reportService.GetDailySummaryAsync(d);
            var invoices = await reportService.GetInvoicesForDayAsync(d);
            var model = new DailyReportVm
            {
                Summary = summary == null
                    ? new DailySummaryVm
                    {
                        Date = d,
                        TotalSales = 0,
                        TotalDiscount = 0,
                        NetIncome = 0,
                        InvoiceCount = 0
                    }
                    : new DailySummaryVm
                    {
                        Date = summary.Date,
                        TotalSales = summary.TotalSales,
                        TotalDiscount = summary.TotalDiscount,
                        NetIncome = summary.NetIncome,
                        InvoiceCount = summary.InvoiceCount
                    },
                Invoices = invoices.Select(s => new InvoiceRowVm
                {
                    Id = s.Id,
                    InvoiceNumber = s.InvoiceNumber,
                    SaleDateTime = s.SaleDateTime,
                    Subtotal = s.Subtotal,
                    DiscountPercent = s.DiscountPercent,
                    DiscountAmount = s.DiscountAmount,
                    TotalAfterDiscount = s.TotalAfterDiscount,
                    PaymentMethod = s.PaymentMethod,
                    ItemCount = s.SaleItems?.Count ?? 0
                }).ToList()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Range() => View();

        [HttpGet]
        public async Task<IActionResult> RangeResult([FromQuery] DateOnly? from, [FromQuery] DateOnly? to)
        {
            var fromDate = from ?? DateOnly.FromDateTime(DateTime.Today).AddMonths(-1);
            var toDate = to ?? DateOnly.FromDateTime(DateTime.Today);
            if (fromDate > toDate) (fromDate, toDate) = (toDate, fromDate);

            var summaries = await reportService.GetRangeSummaryAsync(fromDate, toDate);
            var model = summaries.Select(s => new DailySummaryVm
            {
                Date = s.Date,
                TotalSales = s.TotalSales,
                TotalDiscount = s.TotalDiscount,
                NetIncome = s.NetIncome,
                InvoiceCount = s.InvoiceCount
            }).ToList();
            ViewBag.From = fromDate;
            ViewBag.To = toDate;
            return View(model);
        }
    }
}
