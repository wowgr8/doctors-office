using System.Collections.Generic;

namespace DoctorsOffice.Models
{
  public class Doctor
  {
    public Doctor()
    {
      this.JoinDoctorPatient = new HashSet<DoctorPatient>();
      this.JoinDoctorSpecialty = new HashSet<DoctorSpecialty>();
    }

    public int DoctorId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<DoctorPatient> JoinDoctorPatient { get; set; }
    public virtual ICollection<DoctorSpecialty> JoinDoctorSpecialty { get; set; }
  }
}