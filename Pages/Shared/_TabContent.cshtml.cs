using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static HtmxAmCharts.Pages.IndexModel;

namespace HtmxAmCharts.Pages;

public class TabContent : PageModel
{
    [BindProperty]
    public Tab? TabInfo { get; set; }
}