namespace _08_OOP_Generics_Practice.Sports
{
    public class Leagues<TSport>
    {
        private List<string> teams = new();
        //private List<string> teams = new();

        public string Team { get; set; }
        public TSport SportType { get; set; }

        public Leagues(string team, TSport sportType)
        {
            Team = team;
            SportType = sportType;
        }

        public void AddToLeague()
        {

        }

        public void PrintAllTeams()
        {

        }
    }
}
