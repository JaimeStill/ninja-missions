namespace NinjaMissions.Data.Entities
{
    public class TeamNinja
    {
        public int Id { get; set; }
        public int NinjaId { get; set; }
        public int TeamId { get; set; }
        public bool IsLeader { get; set; }

        public Ninja Ninja { get; set; }
        public Team Team { get; set; }
    }
}