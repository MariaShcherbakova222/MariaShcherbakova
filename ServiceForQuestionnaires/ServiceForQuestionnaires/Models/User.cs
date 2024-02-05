using System;
using System.Collections.Generic;

namespace ServiceForQuestionnaires.Models
{
    public partial class User
    {
        public User()
        {
            Interviews = new HashSet<Interview>();
        }

        public int Id { get; set; }
        public string Namee { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Pasword { get; set; }

        public virtual ICollection<Interview> Interviews { get; set; }
    }
}
