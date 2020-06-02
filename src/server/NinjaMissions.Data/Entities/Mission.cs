namespace NinjaMissions.Data.Entities
{
    public class Mission
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int Ranking { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Team Team { get; set; }
    }
}