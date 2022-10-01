namespace BangolfModels
{
    public class Player
    {
        private Player() 
        { 
            Name = null!;
            Club = null!;
        
        }
        public string Name { get; set; }
        public string Club { get; set; }
        public int Id { get; set; }

        public Player(string name, string club)
        {
            Name = name;
            Club = club;
        }

        public ICollection<Competition> Competitions { get; set; } = new List<Competition>();
        public ICollection<Arena> Arenas { get; set; } = new List<Arena>();
    }
}