using AutoMapper;
using FluentValidation;
using FruitStore.Domain.Entities;
using FruitStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FruitStore.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public TOutputModel Inserir<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel);

            Validate(entity, Activator.CreateInstance<TValidator>());
            _baseRepository.Inserir(entity);

            TOutputModel retorno = _mapper.Map<TOutputModel>(entity);

            return retorno;
        }
        public void Excluir(int id) => _baseRepository.Excluir(id);

        public IEnumerable<TOutputModel> Obter<TOutputModel>() where TOutputModel : class
        {
            var entities = _baseRepository.Obter();

            var retorno = entities.Select(s => _mapper.Map<TOutputModel>(s));

            return retorno;
        }

        public TOutputModel ObterPorId<TOutputModel>(int id) where TOutputModel : class
        {
            var entity = _baseRepository.Obter(id);

            var retorno = _mapper.Map<TOutputModel>(entity);

            return retorno;
        }

        public TOutputModel Atualizar<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel);

            Validate(entity, Activator.CreateInstance<TValidator>());
            _baseRepository.Atualizar(entity);

            TOutputModel retorno = _mapper.Map<TOutputModel>(entity);

            return retorno;
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não encontrados!");

            validator.ValidateAndThrow(obj);
        }

    }
}
