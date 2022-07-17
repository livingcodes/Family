namespace Family.Pages;
using Microsoft.AspNetCore.Mvc;
public class MemberModel : BasePage
{
   [BindProperty]
   public Member Member { get; set; } = new();

   public void OnGet() {
      var id = GetQueryString("id").ToInt();
      if (id <= 0)
         return;
      Member = db.SelectById<Member>(id);
      if (Member == null)
         Member = new Member();
   }

   public void OnPost() {
      var member = db.SelectById<Member>(Member.Id);
      if (member == null)
         (Member.Id, _) = db.Insert(Member);
      else {
         Member.DateModified = DateTime.Now;
         db.Update(Member);
      }
      Response.Redirect("/");
   }
}