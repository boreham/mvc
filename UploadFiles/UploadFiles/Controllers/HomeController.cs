using Microsoft.AspNetCore.Mvc;

namespace ExportXls.Controllers;
public class HomeController : Controller
{
    private IWebHostEnvironment Environment;

    public HomeController(IWebHostEnvironment _environment)
    {
        this.Environment = _environment;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(List<IFormFile> postedFiles)
    {
        string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        foreach (IFormFile postedFile in postedFiles)
        {
            string fileName = Path.GetFileName(postedFile.FileName);
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                postedFile.CopyTo(stream);
                ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
            }
        }
        return View();
    }
}
