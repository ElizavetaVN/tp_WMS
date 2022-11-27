using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace Persistence.EntityTypeConfiguration
{
    class StaffConfiguration: IEntityTypeConfiguration<Staff>//правила для таблички БД Staff (конфигурации для типа сущности)
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(staff => staff.Id);
            builder.HasIndex(staff => staff.Id).IsUnique();
            //builder.Property(staff => staff.Surname).HasMaxLength(250);
        }

    }
}
