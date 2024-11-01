namespace Family.Data;  
using Microsoft.Extensions.Caching.Memory;
public class Db : Basketcase.Db {
   public Db(Basketcase.ICache cache = null)
   : base(
         new SqlConnectionFactory(),
         new Basketcase.Reader(),
         // todo: switch default to serialized cache
         cache ?? new InMemoryCache(new MemoryCache(new MemoryCacheOptions()))
   ) { }
   
   int hr = 60 * 60;

   public Basketcase.IDb Cache(string key) => Cache(key, 1 * hr);

   public int exe(str sql, params obj[] prms) =>
      Exe(sql, prms);

   public List<t> sel<t>(str sql = null, params obj[] prms) =>
      Sel<t>(sql, prms);

   public t sel1<t>(str sql = null, params obj[] prms) =>
      Sel1<t>(sql, prms);

   public t selId<t>(int id) =>
      SelById<t>(id);

   public (int id,int rows) ins<t>(t val) =>
      Ins(val);

   public int upd<t>(t val) =>
      Upd(val);

   public int del<t>(int id) =>
     Del<t>(id);
}