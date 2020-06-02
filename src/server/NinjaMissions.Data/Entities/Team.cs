using System.Collections.Generic;

namespace NinjaMissions.Data.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TeamNinja> Ninjas { get; set; }
    }
}