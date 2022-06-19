using Microsoft.AspNetCore.Mvc.RazorPages;
using Family.Data;

namespace Family.Pages;
public class IndexModel : PageModel {
   private readonly ILogger<IndexModel> _logger;

   public IndexModel(ILogger<IndexModel> logger) {
      _logger = logger;
   }

   public List<Member> Members = new();

   public void OnGet() {
      var db = new Db();
      Members = db.Select<Member>("ORDER BY LastName, FirstName");
   }
}