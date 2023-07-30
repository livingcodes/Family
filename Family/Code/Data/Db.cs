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
      Execute(sql, prms);

   public List<t> sel<t>(str sql = null, params obj[] prms) =>
      Select<t>(sql, prms);

   public t sel1<t>(str sql = null, params obj[] prms) =>
      SelectOne<t>(sql, prms);

   public t selId<t>(int id) =>
      SelectById<t>(id);

   public (int id,int rows) ins<t>(t val) =>
      Insert(val);

   public int upd<t>(t val) =>
      Update(val);
}