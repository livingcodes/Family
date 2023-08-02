namespace Family.Pages;
using Microsoft.AspNetCore.Mvc;
public class MemberModel : BasePage
{
  [BindProperty]
  public Member mbr { get; set; } = new();
  public List<Relationship> Relationships = new();

  public void OnGet() {
    var id = qry("id").@int();
    if (id <= 0)
      return;
    mbr = db.selId<Member>(id);
    if (mbr == null) {
      mbr = new Member();
      return;
    }
    Relationships = db.sel<Relationship>(@"
      SELECT (m1.fn + ' ' + m1.ln) Name1,
        (m2.fn + ' ' + m2.ln) Name2,
        r.[Type]
      FROM [Relationship] r
      JOIN Member m1 ON m1.id = r.MemberId
      JOIN Member m2 ON m2.id = r.RelationshipId
      WHERE m1.id = @id OR m2.id = @id
      ", id);
  }
  public class Relationship {
    public string Name1, Name2, Type;
  }

  public void OnPost() {
    var m = db.selId<Member>(mbr.id);
    if (m == null) {
      mbr.crt = dte.Now;
      mbr.upd = mbr.crt;
      (mbr.id,_) = db.ins(mbr);
    } else {
      mbr.upd = dte.Now;
      db.upd(mbr);
    }
    red("/");
  }
}