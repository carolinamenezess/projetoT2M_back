namespace Domain.Entity
{
    public class Receita
    {
        public int ReceitaId { get; set; }
        public string Categoria { get; set; }
        public string Nome { get; set; }

        public double Valor { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioId { get; set; }

        public Receita(int receita_id, string categoria, string nome, double valor, int user_id, DateTime data_criacao)
        {
            ReceitaId = receita_id;
            Categoria = categoria;
            Nome = nome;

            Valor = valor;
            UsuarioId = user_id;
            DataCriacao = data_criacao;
        }
    }
}
