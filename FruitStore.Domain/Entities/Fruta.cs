using System.Collections.Generic;

namespace FruitStore.Domain.Entities
{
    public class Fruta : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }


    }
}
