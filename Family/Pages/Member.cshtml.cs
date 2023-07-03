namespace Family.Pages;
using Microsoft.AspNetCore.Mvc;
public class MemberModel : BasePage
{
   [BindProperty]
   public Member Member { get; set; } = new();
   public List<Relationship> Relationships = new();

   public void OnGet() {
      var id = qry("id").@int();
      if (id <= 0)
         return;
      Member = db.SelectById<Member>(id);
      if (Member == null) {
         Member = new Member();
         return;
      }
      Relationships = db.Select<Relationship>(@"
         SELECT (m1.FirstName + ' ' + m1.LastName) Name1,
            (m2.FirstName + ' ' + m2.LastName) Name2,
            r.[Type]
         FROM [Relationship] r
         JOIN Member m1 ON m1.Id = r.MemberId
         JOIN Member m2 ON m2.Id = r.RelationshipId
         WHERE m1.Id = @Id OR m2.Id = @Id
         ", id);
   }
   public class Relationship {
      public string Name1, Name2, Type;
   }

   public void OnPost() {
      var member = db.SelectById<Member>(Member.Id);
      if (member == null) {
         Member.DateCreated = DateTime.Now;
         Member.DateModified = Member.DateCreated;
         (Member.Id, _) = db.Insert(Member);
      } else {
         Member.DateModified = DateTime.Now;
         db.Update(Member);
      }
      Response.Redirect("/");
   }
}