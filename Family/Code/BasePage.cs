namespace Family;
using Family.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
public class BasePage : PageModel {
   public BasePage() {
      var logFactory = new Microsoft.Extensions.Logging.LoggerFactory();
      var logger = logFactory.CreateLogger<BasePage>();
      log = new Log(logger);
   }

   Db _db;
   protected Db db { get {
      if (_db == null)
         _db = new Db();
      return _db;
   } }

   protected ILog log;

   protected str qry(str key) =>
      Request.Query[key].FirstOrDefault();
}