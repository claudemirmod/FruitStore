using FruitStore.Application.Models.Usuario;
using FruitStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitStore.Domain.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioModel Login(string email, string senha);
    }
}
