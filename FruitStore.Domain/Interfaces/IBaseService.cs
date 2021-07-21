﻿using FluentValidation;
using FruitStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FruitStore.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        TOutputModel Inserir<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;

        void Excluir(int id);

        IEnumerable<TOutputModel> Obter<TOutputModel>() where TOutputModel : class;

        TOutputModel ObterPorId<TOutputModel>(int id) where TOutputModel : class;
        TOutputModel Atualizar<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;
    }
}
