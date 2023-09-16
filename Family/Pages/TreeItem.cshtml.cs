namespace Family.Pages;
public class TreeItemModel : BasePage
{
  public TreeItem itm { get; set; }

  public void OnGet() {
    var id = qry("id").@int();
    itm = db.selId<TreeItem>(id);
  }

  public void OnPost() {
    itm = Request.GetForm<TreeItem>(nameof(itm));

    if (frm("action") == "Delete") {
      if (itm.id <= 0)
        throw new Exception("Id is not set");
      db.del<TreeItem>(itm.id);
      red("/");
    }
    else if (itm.id == 0) {
      itm.crt = dte.Now;
      itm.upd = itm.crt;
      db.ins(itm);
    }
    else {
      itm.upd = dte.Now;
      db.upd(itm);
    }
  }
}