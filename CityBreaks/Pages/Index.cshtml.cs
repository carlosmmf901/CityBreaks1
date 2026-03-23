using Microsoft.AspNetCore.Mvc.RazorPages;
using CityBreaks.Web.Models;

public class IndexModel : PageModel
{
    private readonly ICityService _cityService;

    public List<City> Cities { get; set; }

    public IndexModel(ICityService cityService)
    {
        _cityService = cityService;
    }

    public async Task OnGetAsync()
    {
        Cities = await _cityService.GetAllAsync();
    }
}