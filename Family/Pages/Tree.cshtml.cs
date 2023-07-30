namespace Family.Pages;
public class TreeModel : BasePage
{
  public List<Member> mbrs = new();
  public Tree tree = new();
  public List<Item> itms = new();
  public str jsn;
  public Vdn vdn = new();

  public void OnGet() {
    mbrs = db.sel<Member>("ORDER BY Dob");
    var treeId = qry("id").@int(1);
    tree = db.selId<Tree>(treeId);
    if (tree == null) {
      vdn.err("Tree not found");
      return;
    }
    itms = db.sel<Item>(sql, treeId);
    jsn = json(itms);
  }

  str json(List<Item> itms) {
    str j = "[";
    foreach (var itm in itms) {
      j += "{";
      j += $@"""{nameof(itm.ItmId)}"": {itm.ItmId}, ";
      j += $@"""{nameof(itm.X)}"": {itm.X}, ";
      j += $@"""{nameof(itm.Y)}"": {itm.Y}, ";
      j += $@"""{nameof(itm.Title)}"": ""{itm.Title}"", ";
      j += $@"""{nameof(itm.MbrId)}"": ""{itm.MbrId}""";
      j += "},";
    }
    j = j.Substring(0, j.Length - 1); // todo: test no items
    j += "]";
    return j;
  }

  str sql = @"
SELECT ti.Id ItmId, ti.X, ti.Y, m.dn Title, ti.MemberId MbrId
FROM Tree t
JOIN TreeItem ti ON ti.TreeId = t.Id
JOIN Member m ON m.id = ti.MemberId
WHERE t.id = @id
";
  public class Item {
    public int ItmId, X, Y, MbrId;
    public str Title;
  }
}