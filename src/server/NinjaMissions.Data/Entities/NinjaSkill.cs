namespace NinjaMissions.Data.Entities
{
    public class NinjaSkill
    {
        public int Id { get; set; }
        public int NinjaId { get; set; }
        public int SkillId { get; set; }
        public int Strength { get; set; }

        public Ninja Ninja { get; set; }
        public Skill Skill { get; set; }
    }
}