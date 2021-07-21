using AutoMapper;
using FruitStore.Application.Models.Fruta;
using FruitStore.Application.Models.Pedido;
using FruitStore.Application.Models.Usuario;
using FruitStore.Domain.Entities;
using FruitStore.Domain.Interfaces;
using FruitStore.Infra.Data.Repository;
using FruitStore.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FruitStore.IoC.Injectors
{
    public static class FruitInjector
    {
        public static void AddFruitStoreInjectorServices(this IServiceCollection services)
        {
            //Usuário
            services.AddScoped<IBaseRepository<Usuario>, BaseRepository<Usuario>>();
            services.AddScoped<IBaseService<Usuario>, BaseService<Usuario>>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            //Frutas
            services.AddScoped<IBaseRepository<Fruta>, BaseRepository<Fruta>>();
            services.AddScoped<IBaseService<Fruta>, BaseService<Fruta>>();

            //Pedido
            services.AddScoped<IBaseRepository<Pedido>, BaseRepository<Pedido>>();
            services.AddScoped<IBaseService<Pedido>, BaseService<Pedido>>();
            services.AddScoped<IPedidoService, PedidoService>();

            //PedidoItem
            services.AddScoped<IBaseRepository<PedidoItem>, BaseRepository<PedidoItem>>();
            services.AddScoped<IBaseService<PedidoItem>, BaseService<PedidoItem>>();

            services.AddSingleton(new MapperConfiguration(config =>
            {
                //Usuário
                config.CreateMap<CreateUsuarioModel, Usuario>();
                config.CreateMap<UpdateUsuarioModel, Usuario>();
                config.CreateMap<Usuario, UsuarioModel>();

                //Frutas
                config.CreateMap<CreateFrutaModel, Fruta>();
                config.CreateMap<UpdateFrutaModel, Fruta>();
                config.CreateMap<Fruta, FrutaModel>();

                //Pedidos
                config.CreateMap<CreatePedidoModel, Pedido>();
                config.CreateMap<UpdatePedidoModel, Pedido>();
                config.CreateMap<Pedido, PedidoModel>();

                //PedidoItem
                config.CreateMap<PedidoItem, PedidoItemModel>();
                config.CreateMap<PedidoItemModel, PedidoItem>();


            }).CreateMapper());

        }
    }
}
