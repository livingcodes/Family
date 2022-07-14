namespace Family.Pages;
public class IndexModel : BasePage {
   public List<Member> Members = new();
   public void OnGet() {
      Members = db.Select<Member>("ORDER BY Dob");
   }
}