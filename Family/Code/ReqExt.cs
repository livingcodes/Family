namespace Family;
public static class ReqExt {
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
    var props = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
    foreach (var prop in props) {
      var frmName = $"{boundVarName}.{prop.Name}";
      if (!formKeys.Contains(frmName))
        continue;
      str str = req.Form[frmName].FirstOrDefault();
      var val = Convert.ChangeType(str, prop.PropertyType);
      prop.SetValue(inst, val);
    }
    return inst;
  }
}