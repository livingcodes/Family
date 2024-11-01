namespace Family.Common;
public static class Ext
{
   public static str str(this obj val, str ifNull) =>
      val == null
         ? ifNull
         : val.ToString();

   public static int @int(this str text, int @default = 0) =>
      int.TryParse(text, out int result)
         ? result
         : @default;

   public static bln IsSet(this str text) =>
      text != null && text != "";

   public static bln NotSet(this str text) => !text.IsSet();
}