using FruitStore.Application.Models.Pedido;
using FruitStore.Application.Models.Pedido;
using FruitStore.Domain.Entities;
using FruitStore.Domain.Interfaces;
using FruitStore.Service.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace FruitStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PedidoController : ControllerBase
    {
        private IBaseService<Pedido> _basePedidoService;
        private IPedidoService _pedidoService;

        public PedidoController(IBaseService<Pedido> basePedidoService, IPedidoService pedidoService)
        {
            _basePedidoService = basePedidoService;
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public IActionResult Get()
            => Execute(() => _basePedidoService.Obter<PedidoModel>());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _basePedidoService.ObterPorId<PedidoModel>(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePedidoModel pedido)
        {
            if (pedido == null)
                return NotFound();

            return Execute(() => _pedidoService.NovoPedido(pedido));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdatePedidoModel pedido)
        {
            if (pedido == null)
                return NotFound();

            return Execute(() => _basePedidoService.Atualizar<UpdatePedidoModel, PedidoModel, PedidoValidator>(pedido));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _pedidoService.Excluir(id);
                return true;
            });

            return new NoContentResult();
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(ex));
            }
        }
    }
}
