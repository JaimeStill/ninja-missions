using System.Collections.Generic;

namespace NinjaMissions.Data.Entities
{
    public class Ninja
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<NinjaSkill> Skills { get; set; }
        public virtual ICollection<TeamNinja> Teams { get; set; }
    }
}