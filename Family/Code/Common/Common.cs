namespace Family.Common;
  using System.Text.Json;
public static class Common
{
  public static str Slz<T>(T obj) =>
    JsonSerializer.Serialize<T>(obj, 
      new JsonSerializerOptions(){IncludeFields=true});

  public static T Dslz<T>(str jsn) =>
    JsonSerializer.Deserialize<T>(jsn, 
      new JsonSerializerOptions(){IncludeFields=true});
}