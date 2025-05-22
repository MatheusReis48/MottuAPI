using System;

namespace MottuAPI.Domain.Entities
{
    public class Filial
    {
        public int IdFilial { get; set; }
        public string NomeFilial { get; set; }
        public string CnpjFilial { get; set; }
        public string EnderecoFilial { get; set; }
        public string CidadeFilial { get; set; }
        public string EstadoFilial { get; set; }
        public string CepFilial { get; set; }
        public string TelefoneFilial { get; set; }
        public string EmailFilial { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataUltimaAtualizacao { get; set; }
        
        // Relacionamentos
        public ICollection<Patio> Patios { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
        public ICollection<Moto> Motos { get; set; }
    }
}
