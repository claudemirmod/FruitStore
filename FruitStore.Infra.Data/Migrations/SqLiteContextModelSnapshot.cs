// <auto-generated />
using FruitStore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FruitStore.Infra.Data.Migrations
{
    [DbContext(typeof(SqLiteContext))]
    partial class SqLiteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("FruitStore.Domain.Entities.Fruta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(400)")
                        .HasColumnName("Descricao");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasColumnName("Foto");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("Quantidade");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.ToTable("Fruta");
                });

            modelBuilder.Entity("FruitStore.Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric")
                        .HasColumnName("Total");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("FruitStore.Domain.Entities.PedidoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdFruta")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdPedido")
                        .HasColumnType("int")
                        .HasColumnName("IdPedido");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("Quantidade");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.HasIndex("IdFruta");

                    b.ToTable("PedidoItem");
                });

            modelBuilder.Entity("FruitStore.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Senha");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("FruitStore.Domain.Entities.Pedido", b =>
                {
                    b.HasOne("FruitStore.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FruitStore.Domain.Entities.PedidoItem", b =>
                {
                    b.HasOne("FruitStore.Domain.Entities.Fruta", "Fruta")
                        .WithMany()
                        .HasForeignKey("IdFruta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FruitStore.Domain.Entities.Pedido", "Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("IdFruta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fruta");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("FruitStore.Domain.Entities.Pedido", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
