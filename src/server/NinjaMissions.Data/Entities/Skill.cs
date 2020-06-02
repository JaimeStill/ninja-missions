using System.Collections.Generic;

namespace NinjaMissions.Data.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<NinjaSkill> Ninjas { get; set; }
    }
}