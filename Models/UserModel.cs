namespace PruebaNivelacion.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Nick { get; set; }

       public UserModel(string nick, int id) { 
            //var rand = new Random();
            //this.Id = rand.Next(1, 1000000);

            this.Nick = nick;
            this.Id = id;

        }
    }
}
