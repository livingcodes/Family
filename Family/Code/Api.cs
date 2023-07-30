namespace Family;
using Family.Data;
using Microsoft.AspNetCore.Mvc;
public class Api : ControllerBase
{
  public Api(Db db) =>
    this.db = db;
  Db db;

  [HttpPost][Route("api/tree/ins")]
  public IActionResult ins([FromBody]TreeItem itm) {
    if (itm is null)
      return BadRequest(new{msg="item is null"});
    itm.DateCreated = dte.Now;
    (itm.Id,_) = db.ins(itm);
    return Ok(itm);
  }

  [HttpPost][Route("api/tree/upd")]
  public IActionResult upd([FromBody]Item itm) {
    if (itm is null)
      return BadRequest(new { msg = "item is null"});
    if (itm.id <= 0)
      return BadRequest(new { msg = "item id is invalid" });
    db.updʹ(itm);
    return Ok();
  }
}
public class Item {
  // [FromBody] requires properties
  public int id { get; set; }
  public int x { get; set; }
  public int y { get; set; }
}