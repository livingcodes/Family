namespace Family.Data;
public static class DbExt
{
   public static void upd(
      this Db db, Item item
   ) {
      db.exe(@"
         update treeItem set
            x = @x,
            y = @y
         where id = @id
      ", item.x, item.y, item.id);
   }
}
public class Item {
   // [FromBody] requires properties
   public int id { get; set; }
   public int x { get; set; }
   public int y { get; set; }
}