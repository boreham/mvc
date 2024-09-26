using ExportXls.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ExportXls.Controllers;
public class HomeController : Controller
{
    private readonly DataContext _dataContext;

    public HomeController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public IActionResult Index()
    {
        return View(this._dataContext.Customers.Take(10).ToList());
    }

    [HttpPost]
    public FileResult ExportXls(string GridHtml)
    {
        return File(Encoding.ASCII.GetBytes(GridHtml), "application/vnd.ms-excel", "Grid.xls");
    }
}
