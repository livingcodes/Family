namespace Family.Pages;
public class TreeItemModel : BasePage
{
   public TreeItem TreeItem { get; set; }
   public void OnGet() {
      var id = GetQueryString("id").ToInt();
      TreeItem = db.SelectById<TreeItem>(id);
   }
   public void OnPost() {
      TreeItem = Request.GetForm<TreeItem>();
      if (TreeItem.Id == 0) {
         TreeItem.DateCreated = DateTime.Now;
         db.Insert(TreeItem);
      } else {
         TreeItem.DateModified = DateTime.Now;
         db.Update(TreeItem);
      }
   }
}
public static class RequestExtensions
{
   public static T GetForm<T>(this HttpRequest req) {
      var instance = Activator.CreateInstance<T>();
      var formKeys = req.Form.Keys;
      var typeFields = typeof(T).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
      foreach (var typeField in typeFields) {
         var field = $"{nameof(TreeItem)}.{typeField.Name}";
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
         typeField.SetValue(instance, val);
      }
      return instance;
   }
}