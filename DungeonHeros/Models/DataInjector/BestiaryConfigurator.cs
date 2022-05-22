using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DungeonHeros.Models.DataInjector
{

    public class BestiaryConfigurator : IEntityTypeConfiguration<Monster>
    {
        public void Configure(EntityTypeBuilder<Monster> builder)
        {
            var spider = new Monster
                {MonsterId = 1, MonsterName = "Spider", RaceId = 6, Strength = 2, Stamina = 2};
            var ogre = new Monster
                {MonsterId = 2, MonsterName = "Ogre", RaceId = 7, Strength = 1, Stamina = 3};
            var grougaloragran = new Monster
                {MonsterId = 3, MonsterName = "Grougaloragran", RaceId = 5, Strength = 4, Stamina = 12};
            var serwaul = new Monster
                {MonsterId = 4, MonsterName = "Serwaul", RaceId = 8, Strength = 7, Stamina = 1};
            var bat = new Monster
                {MonsterId = 5, MonsterName = "Bat", RaceId = 6, Strength = 1, Stamina = 2};
            var giantWolf = new Monster
                {MonsterId = 6, MonsterName = "Giant Wolf", RaceId = 6, Strength = 4, Stamina = 3};
            var efrit = new Monster
                {MonsterId = 7, MonsterName = "Efrit", RaceId = 7, Strength = 4, Stamina = 4};
            var boneGolem = new Monster
                {MonsterId = 8, MonsterName = "Bone Golem", RaceId = 7, Strength = 5, Stamina = 3};
            var hydra = new Monster
                {MonsterId = 9, MonsterName = "Hydra", RaceId = 7, Strength = 5, Stamina = 11};

            var kobold = new Monster
                {MonsterId = 10, MonsterName = "Kobold", RaceId = 7, Strength = 2, Stamina = 4};
            var fafnir = new Monster
                {MonsterId = 11, MonsterName = "Fafnir", RaceId = 5, Strength = 9, Stamina = 7};
            var darkLord = new Monster
                {MonsterId = 12, MonsterName = "Dark Lord", RaceId = 8, Strength = 20, Stamina = 20};
            var vouivre = new Monster
                {MonsterId = 13, MonsterName = "Vouivre", RaceId = 5, Strength = 10, Stamina = 15};
            builder.HasData(spider);
            
            builder.HasData(ogre);
            
            builder.HasData(grougaloragran);
            
            builder.HasData(serwaul);
            builder.HasData(bat);
            builder.HasData(giantWolf);
            builder.HasData(efrit);
            builder.HasData(boneGolem);
            builder.HasData(hydra);
            builder.HasData(kobold);
            builder.HasData(fafnir);
            builder.HasData(darkLord);
            builder.HasData(vouivre);
        }
    }
}