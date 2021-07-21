namespace FruitStore.Application.Models.Fruta
{
    public class CreateFrutaModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
