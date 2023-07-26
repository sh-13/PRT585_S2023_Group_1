module SimpleController

public class SimpleController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(SimpleRequest request)
    {
        return View(request);
    }
}