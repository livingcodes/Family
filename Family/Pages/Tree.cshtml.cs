namespace Family.Pages;
public class TreeModel : BasePage
{
   public List<Member> Members = new();
   public Tree Tree = new();
   public List<Item> Items = new();
   public str Json;
   public Vdn vdn = new();

   public void OnGet() {
      Members = db.Select<Member>("ORDER BY Dob");
      var treeId = qry("id").@int(1);
      Tree = db.SelectById<Tree>(treeId);
      if (Tree == null) {
         vdn.err("Tree not found");
         return;
      }
      Items = db.Select<Item>(sql, treeId);
      Json = json(Items);
   }

   str json(List<Item> items) {
      str j = "[";
      foreach (var item in items) {
         j += "{";
         j += $@"""{nameof(item.Id)}"": {item.Id}, ";
         j += $@"""{nameof(item.X)}"": {item.X}, ";
         j += $@"""{nameof(item.Y)}"": {item.Y}, ";
         j += $@"""{nameof(item.Title)}"": ""{item.Title}""";
         j += "},";
      }
      j = j.Substring(0, j.Length - 1);
      j += "]";
      return j;
   }

   str sql = @"
SELECT ti.Id, ti.X, ti.Y, m.DisplayName Title
FROM Tree t
JOIN TreeItem ti ON ti.TreeId = t.Id
JOIN Member m ON m.Id = ti.MemberId
WHERE t.Id = @Id
";
   public class Item {
      public int Id, X, Y;
      public str Title;
   }
}