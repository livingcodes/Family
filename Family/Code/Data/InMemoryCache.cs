namespace Family.Data;
using Microsoft.Extensions.Caching.Memory;
using System;
/// <summary>Stores reference to cached object. If object changes outside cache, it changes in cache too.</summary>
public class InMemoryCache : Basketcase.ICache {
   public InMemoryCache(IMemoryCache c) {
      this.c = c;
   }
   IMemoryCache c;

   public T Get<T>(string key) =>
      c.Get<T>(key);

   public void Set(string key, object value, int seconds) {
      c.Set(key, value, new TimeSpan(0, 0, seconds));
   }
}