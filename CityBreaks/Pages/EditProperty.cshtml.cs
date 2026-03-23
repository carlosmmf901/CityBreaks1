using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class EditPropertyModel : PageModel
{
    private readonly CityBreaksContext _context;

    public EditPropertyModel(CityBreaksContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Property Property { get; set; }

    public SelectList Cities { get; set; }

    
    public async Task<IActionResult> OnGetAsync(int id)
    {
        Property = await _context.Properties.FindAsync(id);

        if (Property == null)
            return NotFound();

        Cities = new SelectList(await _context.Cities.ToListAsync(), "Id", "Name");

        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync(int id)
    {
        var propertyToUpdate = await _context.Properties.FindAsync(id);

        if (propertyToUpdate == null)
            return NotFound();
        
        if (await TryUpdateModelAsync(
                propertyToUpdate,
                "Property",
                p => p.Name,
                p => p.PricePerNight,
                p => p.CityId))
        {
            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }

        Cities = new SelectList(await _context.Cities.ToListAsync(), "Id", "Name");
        return Page();
    }
}