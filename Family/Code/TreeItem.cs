namespace Family;
public class TreeItem {
  public int id;
  // properties (instead of field) required for api [FromBody]
  public int treeId { get; set; }
  public int mbrId { get; set; }
  public int x { get; set; }
  public int y { get; set; }
  public dte crt;
  public dte? upd;
}