namespace Family.Pages;
public class IndexModel : BasePage {
   public List<Member> mbrs = new();
   public void OnGet() {
      mbrs = db.sel<Member>("ORDER BY Dob");
   }
}