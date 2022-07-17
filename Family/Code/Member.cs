namespace Family;
public class Member {
   public int Id { get; set; }
   public string FirstName { get; set; }
   public string MiddleName { get; set; }
   public string LastName { get; set; }
   public string DisplayName { get; set; }
   public DateTime? Dob { get; set; }
   public string Note { get; set; }
   public DateTime DateCreated { get; set; }
   public DateTime? DateModified { get; set; }
}