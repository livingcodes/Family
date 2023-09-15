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
public static class ReqExt
{
  public static T GetForm<T>(this HttpRequest req, str boundVarName) {
    var inst = Activator.CreateInstance<T>();
    var formKeys = req.Form.Keys;
    var typeFields = typeof(T).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
    foreach (var typeField in typeFields) {
      var field = $"{boundVarName}.{typeField.Name}";
      if (!formKeys.Contains(field))
        continue;
      var str = req.Form[field].FirstOrDefault();
      var typ = Nullable.GetUnderlyingType(typeField.FieldType);
      var isNullable = typ != null;
      object val = null;
      if (isNullable && str.NotSet()) {
        // null
      } else {
        val = Convert.ChangeType(str, typeField.FieldType);
      }
      typeField.SetValue(inst, val);
    }
    return inst;
  }
}