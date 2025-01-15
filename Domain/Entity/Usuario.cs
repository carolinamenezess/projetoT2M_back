namespace Domain.Entity
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public DateTime DataCriacao { get; set; }

        public Usuario(int usuario_id, string nome, string email, string senha, DateTime data_criacao)
        {
            UsuarioId = usuario_id;
            Nome = nome;
            Email = email;
            DataCriacao = data_criacao;
            Senha = senha;
        }
    }
}
