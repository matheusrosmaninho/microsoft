using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies;

public class IndexModel : PageModel
{
    private readonly Data.RazorPagesMovieContext _context;

    public IndexModel(Data.RazorPagesMovieContext context)
    {
        _context = context;
    }

    public IList<Movie> Movie { get;set; } = default!;

    public async Task OnGetAsync()
    {
        var movies = from m in _context.Movie
            select m;
        if (!string.IsNullOrEmpty(SearchString))
        {
            movies = movies.Where(s => s.Title != null && s.Title.Contains(SearchString));
        }

        Movie = await movies.ToListAsync();
    }

    [BindProperty(SupportsGet = true)]
    public string? SearchString {get; set;}

    public SelectList? Genres {get; set;}

    [BindProperty(SupportsGet = true)]
    public string? MovieGenre {get; set;}
}