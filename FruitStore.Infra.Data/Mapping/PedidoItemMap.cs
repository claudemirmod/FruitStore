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
    public class PedidoItemMap : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItem");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.IdPedido)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("IdPedido")
                .HasColumnType("int");

            builder
                .HasOne(prop => prop.Fruta)
                .WithMany()
                .HasForeignKey(prop => prop.IdFruta);

            builder
                .HasOne(prop => prop.Pedido)
                .WithMany(prop => prop.Itens)
                .HasForeignKey(prop => prop.IdFruta);

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
