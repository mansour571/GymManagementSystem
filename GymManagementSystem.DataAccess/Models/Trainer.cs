using GymManagementSystem.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagementSystem.DataAccess.Models
{
    public class Trainer : User
    {
        public Speciality Speciality { get; set; }
        public DateTime HireDate { get; set; }

        public ICollection<Session> Sessions { get; set; } = [];

    }
}
