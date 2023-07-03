namespace Family;
using Family.Data;
using Microsoft.AspNetCore.Mvc;
public class Api : ControllerBase
{
   public Api(Db db) =>
      this.db = db;
   Db db;

   [HttpPost] [Route("api/tree/upd")]
   public IActionResult upd([FromBody]Item item) {
      if (item is null)
         return BadRequest(new { msg = "item is null"});
      if (item.id <= 0)
         return BadRequest(new { msg = "item id is invalid" });
      db.upd(item);
      return Ok();
   }
}