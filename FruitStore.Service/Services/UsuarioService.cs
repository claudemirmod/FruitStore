using AutoMapper;
using FruitStore.Application.Models.Usuario;
using FruitStore.Domain.Entities;
using FruitStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitStore.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IBaseRepository<Usuario> _baseRepository;

        private readonly IMapper _mapper;

        public UsuarioService(IBaseRepository<Usuario> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public UsuarioModel Login(string email, string senha)
        {
            var usuario = _baseRepository.Obter(x => x.Email == email && x.Senha == senha).FirstOrDefault();

            var retorno = _mapper.Map<UsuarioModel>(usuario);

            return retorno;

        }
    }
}
