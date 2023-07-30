namespace Family.Pages;
public class TimelineModel : BasePage
{
  public List<Member> mbrs;
  public void OnGet() {
    mbrs = db.sel<Member>()
      .OrderByDescending(x => x.dob)
      .ToList();

    if (mbrs.Count == 0)
      return;
    var year = new {
      max = mbrs.Max(x => x.dob?.Year).Value,
      min = mbrs.Min(x => x.dob?.Year).Value,
      range = mbrs.Max(x => x.dob?.Year).Value - mbrs.Min(x => x.dob?.Year).Value
    };
    var pixel = new { range = 350 };
    foreach (var mbr in mbrs) {
      if (mbr.dob == null || !mbr.dob.HasValue) {
        mbr.id = 0;
        continue;
      }
      var yr = mbr.dob.Value.Year;
      var top = ((yr - year.min) / (double)year.range) * (pixel.range);
      mbr.id = (int)top;
    }
  }
}