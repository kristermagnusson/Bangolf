namespace BangolfModels
{
#nullable disable
    public class Competition
    {
        public int Id { get; set; }
        public int Score { get; set; }
        
        
        public int Playerid { get; set; }
        public int Arenaid { get; set; }
       
        
        public Player Player { get; set; }
        public Arena Arena { get; set; }
    }



}