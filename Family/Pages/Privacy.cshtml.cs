namespace Family.Pages;
public class PrivacyModel : BasePage {
   public List<Member> Members;
   public void OnGet() {
      log.Debug("Privacy test log");
      Members = db.Select<Member>("ORDER BY DisplayName");
   }
}