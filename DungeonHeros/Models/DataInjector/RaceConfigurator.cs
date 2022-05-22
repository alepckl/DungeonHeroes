using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DungeonHeros.Models.DataInjector
{
    
    public class RaceConfigurator : IEntityTypeConfiguration<Race>
    {

        public void Configure(EntityTypeBuilder<Race> builder)
        {
            var human = new Race {RaceId = 1, IsForUser = 1, Name = "Human"};
            var dwarf = new Race {RaceId = 2, IsForUser = 1, Name = "Dwarf"};
            var elf = new Race {RaceId = 3, IsForUser = 1,  Name = "Elf"};
            var orc = new Race {RaceId = 4, IsForUser = 1, Name = "Orc"};
            var dragon = new Race {RaceId = 5, IsForUser = 0, Name = "Dragon"};
            var animal = new Race {RaceId = 6, IsForUser = 0, Name = "Animal"};
            var monster = new Race {RaceId = 7, IsForUser = 0,  Name = "Monster"};
            var demon = new Race {RaceId = 8, IsForUser = 0, Name = "Demon"};
                
            builder.HasData(human);
            builder.HasData(dwarf);
            builder.HasData(elf);
            builder.HasData(orc);
            builder.HasData(dragon);
            builder.HasData(animal);
            builder.HasData(monster);
            builder.HasData(demon);
        }
    }
}