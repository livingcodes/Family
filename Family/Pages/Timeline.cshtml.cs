namespace Family.Pages;
public class TimelineModel : BasePage
{
   public List<Member> Members;
   public void OnGet() {
      Members = db.Select<Member>()
         .OrderByDescending(x => x.Dob)
         .ToList();

      if (Members.Count == 0)
         return;
      var year = new {
         max = Members.Max(x => x.Dob?.Year).Value,
         min = Members.Min(x => x.Dob?.Year).Value,
         range = Members.Max(x => x.Dob?.Year).Value - Members.Min(x => x.Dob?.Year).Value
      };
      var pixel = new { range = 350 };
      foreach (var member in Members) {
         if (member.Dob == null || !member.Dob.HasValue) {
            member.Id = 0;
            continue;
         }
         var yr = member.Dob.Value.Year;
         var top = ((yr - year.min) / (double)year.range) * (pixel.range);
         member.Id = (int)top;
      }
   }
}