namespace Family.Pages;
public class TreeModel : BasePage
{
   public List<Member> Members = new();
   public void OnGet() {
      Members = db.Select<Member>("ORDER BY Dob");
   }
}