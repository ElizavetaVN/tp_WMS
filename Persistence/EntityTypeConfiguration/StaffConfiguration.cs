using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace Persistence.EntityTypeConfiguration
{
    class StaffConfiguration: IEntityTypeConfiguration<Staff>//правила для таблички БД Staff (конфигурации для типа сущности)
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(note => note.Id);
            builder.HasIndex(note => note.Id).IsUnique();
            //builder.Property(note => note.Surname).HasMaxLength(250);
        }

    }
}
