namespace PruebaNivelacion.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Nick { get; set; }

       public UserModel(string name) { 
            var rand = new Random();
            this.Id = rand.Next(1, 1000000);

            this.Nick = name;
        }
    }
}
