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
      j += $@"""{nameof(itm.itmId)}"": {itm.itmId}, ";
      j += $@"""{nameof(itm.x)}"": {itm.x}, ";
      j += $@"""{nameof(itm.y)}"": {itm.y}, ";
      j += $@"""{nameof(itm.title)}"": ""{itm.title}"", ";
      j += $@"""{nameof(itm.mbrId)}"": ""{itm.mbrId}""";
      j += "},";
    }
    j = j.Substring(0, j.Length - 1); // todo: test no items
    j += "]";
    return j;
  }

  str sql = @"
SELECT ti.Id itmId, ti.x, ti.y, m.dn title, ti.mbrId
FROM Tree t
JOIN TreeItem ti ON ti.treeId = t.Id
JOIN Member m ON m.id = ti.mbrId
WHERE t.id = @id
";
  public class Item {
    public int itmId, x, y, mbrId;
    public str title;
  }
}