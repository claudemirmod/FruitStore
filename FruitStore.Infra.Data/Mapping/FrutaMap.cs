using FruitStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FruitStore.Infra.Data.Mapping
{
    public class FrutaMap : IEntityTypeConfiguration<Fruta>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Fruta> builder)
        {
            builder.ToTable("Fruta");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Nome)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Descricao)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnName("Descricao")
               .HasColumnType("varchar(400)");

            builder.Property(prop => prop.Foto)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Foto")
                .HasColumnType("varchar(300)");

            builder.Property(prop => prop.Quantidade)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("Quantidade")
                .HasColumnType("int");

            builder.Property(prop => prop.Valor)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("Valor")
                .HasColumnType("numeric");
        }
    }
}
