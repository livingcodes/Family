namespace Family.Pages;
public class PrivacyModel : BasePage {
  public List<Member> mbrs;
  public void OnGet() {
    log.Debug("Privacy test log");
    mbrs = db.sel<Member>("ORDER BY DisplayName");
  }
}