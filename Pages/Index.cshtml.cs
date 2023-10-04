using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HtmxAmCharts.Pages;

public class IndexModel : PageModel
{
    public record Tab(ETabType Type)
    {
        public string Name => Type.ToString();
        public string Content => _contents[Type];
    }

    private static Dictionary<ETabType, string> _contents = new()
    {
        { ETabType.INTRO, "This is the introduction page" },
        { ETabType.GENDER, "This is the gender page" },
        { ETabType.AGE, "This is the age page" },
        { ETabType.ETHNIC, "This is the ethnicity page" },
        { ETabType.SEXUAL_ORIENTATION, "This is the SO page" },
        { ETabType.DISABILITY, "This is the Disability page" },
    };
    
    [BindProperty(Name = "tab", SupportsGet = true)]
    public ETabType? ActiveTabType { get; set; } = ETabType.INTRO;
    public Tab? ActiveTab => ActiveTabType.HasValue ? new Tab(ActiveTabType.Value) : null;

    [BindProperty(Name = "tabs", SupportsGet = true)]
    public List<Tab> AvailableTabs => Enum.GetValues<ETabType>().Select(tab => new Tab(tab)).ToList();


    public bool IsSelected(Tab tab) => tab.Equals(ActiveTab);

    public string? IsSelectedCss(Tab tab, string? cssClass) =>
        IsSelected(tab) ? cssClass : null;
    
    public IActionResult OnGet()
    {
        Console.WriteLine($"ActiveTab: {ActiveTab?.Type}");
        return Request.IsHtmx()
            ? Partial("_Tabs", this)
            : Page();
    }

    public enum ETabType
    {
        INTRO,
        GENDER,
        AGE,
        ETHNIC,
        SEXUAL_ORIENTATION,
        DISABILITY
    }
}