using System.Collections.Generic;

namespace DoctorsOffice.Models
{
  public class Specialty
  {
    public Specialty()
    {
      this.JoinDoctorSpecialty = new HashSet<DoctorSpecialty>();
    }

    public int SpecialtyId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<DoctorSpecialty> JoinDoctorSpecialty { get; set; }
  }
}