using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages
{
    public class RecapDemoModel : PageModel
    {

        public string? FullName =>  HttpContext?.Session?.GetString("name") ?? "kimsesiz";

      
        public void OnGet()
        {
        }

        public void OnPost([FromForm] string name)
        {
            //FullName = name;
            HttpContext.Session.SetString("name",name);
            
        }
    }

}
