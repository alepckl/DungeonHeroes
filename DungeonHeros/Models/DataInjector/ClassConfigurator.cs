using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DungeonHeros.Models.DataInjector
{
    
    public class ClassConfigurator : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            var magician = new Class {ClassId = 1, ClassName = "Magician"};
            var thief = new Class {ClassId = 2, ClassName = "Thief"};
            var warrior = new Class {ClassId = 3, ClassName = "Warrior"};
            var archer = new Class {ClassId = 4, ClassName = "Archer"};
            
            builder.HasData(magician);
            builder.HasData(thief);
            builder.HasData(warrior);
            builder.HasData(archer);
        }
    }
}