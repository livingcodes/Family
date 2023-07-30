namespace Family.Pages;
public class TreeModel : BasePage
{
  public List<Member> Members = new();
  public Tree Tree = new();
  public List<Item> Items = new();
  public str Json;
  public Vdn vdn = new();

  public void OnGet() {
    Members = db.sel<Member>("ORDER BY Dob");
    var treeId = qry("id").@int(1);
    Tree = db.selId<Tree>(treeId);
    if (Tree == null) {
      vdn.err("Tree not found");
      return;
    }
    Items = db.sel<Item>(sql, treeId);
    Json = json(Items);
  }

  str json(List<Item> items) {
    str j = "[";
    foreach (var item in items) {
      j += "{";
      j += $@"""{nameof(item.ItmId)}"": {item.ItmId}, ";
      j += $@"""{nameof(item.X)}"": {item.X}, ";
      j += $@"""{nameof(item.Y)}"": {item.Y}, ";
      j += $@"""{nameof(item.Title)}"": ""{item.Title}"", ";
      j += $@"""{nameof(item.MbrId)}"": ""{item.MbrId}""";
      j += "},";
    }
    j = j.Substring(0, j.Length - 1); // todo: test no items
    j += "]";
    return j;
  }

  str sql = @"
SELECT ti.Id ItmId, ti.X, ti.Y, m.DisplayName Title, ti.MemberId MbrId
FROM Tree t
JOIN TreeItem ti ON ti.TreeId = t.Id
JOIN Member m ON m.Id = ti.MemberId
WHERE t.Id = @Id
";
  public class Item {
    public int ItmId, X, Y, MbrId;
    public str Title;
  }
}