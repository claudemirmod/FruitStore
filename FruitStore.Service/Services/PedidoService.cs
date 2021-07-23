using AutoMapper;
using FluentValidation;
using FruitStore.Application.Models.Pedido;
using FruitStore.Domain.Entities;
using FruitStore.Domain.Interfaces;
using FruitStore.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitStore.Service.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IBaseRepository<Pedido> _baseRepository;
        private readonly IBaseRepository<PedidoItem> _itensRepository;
        private readonly IBaseRepository<Fruta> _frutaRepository;

        private readonly IMapper _mapper;

        public PedidoService(IBaseRepository<Pedido> baseRepository, IBaseRepository<Fruta> frutaRepository, IBaseRepository<PedidoItem> itensRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _frutaRepository = frutaRepository;
            _itensRepository = itensRepository;
        }

        public void Excluir(int id)
        {
            Pedido pedido = _baseRepository.Obter(id);

            //Inclui novamente o saldo das frutas
            foreach (PedidoItem item in pedido.Itens)
            {
                var fruta = _frutaRepository.Obter(item.IdFruta);
                fruta.Quantidade += item.Quantidade;
                _frutaRepository.Atualizar(fruta);
            }

            _baseRepository.Excluir(id);
        }

        public PedidoModel NovoPedido(CreatePedidoModel pedido)
        {
            Pedido entity = _mapper.Map<Pedido>(pedido);

            Validate(entity, Activator.CreateInstance<PedidoValidator>());
            
            List<PedidoItem> itens = entity.Itens;

            entity.Itens = null;

            _baseRepository.Inserir(entity);

            //Faz a baixa na quantidade das frutas
            foreach (PedidoItem item in itens)
            {
                item.IdPedido = entity.Id;
                _itensRepository.Inserir(item);

                var fruta = _frutaRepository.Obter(item.IdFruta);
                fruta.Quantidade -= item.Quantidade;
                _frutaRepository.Atualizar(fruta);
            }


            PedidoModel retorno = _mapper.Map<PedidoModel>(entity);

            return retorno;
        }

        private void Validate(Pedido obj, AbstractValidator<Pedido> validator)
        {
            if (obj == null)
                throw new Exception("Registros não encontrados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
