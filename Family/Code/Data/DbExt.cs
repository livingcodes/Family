namespace Family.Data;
public static class DbExt
{
  public static void updʹ(
    this Db db, Item item
  ) {
    db.exe(@"
      update TreeItem set
        x = @x,
        y = @y
      where id = @id
    ", item.x, item.y, item.id);
  }
}