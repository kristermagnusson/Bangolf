using BangolfModels;

namespace BangolfWeb.Models
{
    public class PlayerDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Club { get; set; }
        public int NrOfCompetitions { get; set; }
       public IEnumerable<Arena>Arenas { get; set; }
    }
}
