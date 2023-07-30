namespace Family;
public class TreeItem {
  public int Id;
  public int TreeId { get; set; }
  public int MemberId { get; set; }
  public int X { get; set; }
  public int Y { get; set; }
  public dte DateCreated;
  public dte? DateModified;
}