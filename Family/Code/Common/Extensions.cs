namespace Family.Common;
public static class Extensions {
   public static string ToStringOr(this object value, string ifNull) =>
         value == null
            ? ifNull
            : value.ToString();

   public static int ToInt(this string text, int @default = 0) =>
         int.TryParse(text, out int result)
            ? result
            : @default;

   public static bool IsSet(this string text) =>
      text != null && text != "";

   public static bool NotSet(this string text) => !text.IsSet();
}