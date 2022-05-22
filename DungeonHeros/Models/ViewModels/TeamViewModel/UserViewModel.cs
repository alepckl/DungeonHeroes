namespace DungeonHeros.Models.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(int id, string race, string imagePath, string name, int strength, int stamina, int level, string classe)
        {
            UserId = id;
            Race = race;
            Name = name;
            ImagePath = imagePath;
            Strength = strength;
            Stamina = stamina;
            Level = level;
            Classe = classe;
        }

        public string Classe { get; }

        public string ImagePath { get; }

        public int UserId { get; }
        
        public string Race { set; get; }
        
        public string Name { set; get; }
        
        public int Strength { set; get; }
        
        public int Stamina { set; get; }
        
        public int Level { set; get; }
    }
}