using FruitStore.Application.Models.Fruta;
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
    public class FrutaController : ControllerBase
    {
        private IBaseService<Fruta> _baseFrutaService;

        public FrutaController(IBaseService<Fruta> baseFrutaService)
        {
            _baseFrutaService = baseFrutaService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
            => Execute(() => _baseFrutaService.Obter<FrutaModel>());

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseFrutaService.ObterPorId<FrutaModel>(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateFrutaModel fruta)
        {
            if (fruta == null)
                return NotFound();

            return Execute(() => _baseFrutaService.Inserir<CreateFrutaModel, FrutaModel, FrutaValidator>(fruta));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateFrutaModel fruta)
        {
            if (fruta == null)
                return NotFound();

            return Execute(() => _baseFrutaService.Atualizar<UpdateFrutaModel, FrutaModel, FrutaValidator>(fruta));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseFrutaService.Excluir(id);
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
