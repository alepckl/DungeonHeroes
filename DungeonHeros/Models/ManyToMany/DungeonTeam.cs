namespace DungeonHeros.Models.ManyToMany
{
    public class  DungeonTeam
    {
        public int DungeonTeamId { set; get; }
        
        public int DungeonId { set; get; }
        public Dungeon Dungeon { set; get; }
        
        public bool HasWon { set; get; }
        
        public int TeamId { set; get; }
        public Team Team { set; get; }
    }
}