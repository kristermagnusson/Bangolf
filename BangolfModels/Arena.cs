namespace BangolfModels
{
    public class Arena
    {
        public string Name { get; set; }
        public int Par { get; set; }
        public int Id { get; set; }

        public Arena(string name,int par)
        {
            Name = name;
            Par = par;

        }

        public ICollection<Competition> Competitions { get; set; } =new List <Competition>();
        public ICollection<Player> Players { get; set; } =new List<Player>();

    }
}