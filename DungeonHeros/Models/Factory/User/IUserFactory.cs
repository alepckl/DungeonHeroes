namespace DungeonHeros.Models.Factory.User
{
    public interface IUserFactory
    {
        Models.User UpdateUser(Models.User current, string name, string imagePath);
    }

    public class UserFactory : IUserFactory
    {
        public Models.User UpdateUser(Models.User current, string name, string imagePath)
        {
            current.HeroName = name;
            current.Hero.HeroName = name;

            current.Hero.ImagePath = imagePath;
            return current;
        }
    }
}