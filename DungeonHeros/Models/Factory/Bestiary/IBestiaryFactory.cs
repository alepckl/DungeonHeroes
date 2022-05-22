namespace DungeonHeros.Models.Factory.Bestiary
{
    public interface IBestiaryFactory
    {
        Monster UpdateMonster(Monster newest, Monster old);
    }

    public class BestiaryFactory : IBestiaryFactory
    {
        public Monster UpdateMonster(Monster newest, Monster old)
        {
            // On va update notre monstre valeur par valeur.
            old.MonsterName = newest.MonsterName;
            old.Stamina = newest.Stamina;
            old.Strength = newest.Strength;
            old.RaceId = newest.RaceId;
            if (!string.IsNullOrEmpty(newest.ImagePath)) old.ImagePath = newest.ImagePath;

            return old;
        }
    }
}