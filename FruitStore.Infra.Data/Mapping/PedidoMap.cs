using FruitStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitStore.Infra.Data.Mapping
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");

            builder.HasKey(prop => prop.Id);

            builder
                .HasOne(prop => prop.Usuario)
                .WithMany()
                .HasForeignKey(prop => prop.IdUsuario);

            builder
                .HasMany(prop => prop.Itens)
                .WithOne(prop => prop.Pedido);


            builder.Property(prop => prop.Total)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("Total")
                .HasColumnType("numeric");
        }
    }
}
