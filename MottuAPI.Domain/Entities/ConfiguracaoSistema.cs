using System;

namespace MottuAPI.Domain.Entities
{
    public class ConfiguracaoSistema
    {
        public string ChaveConfig { get; set; }
        public string ValorConfig { get; set; }
        public string DescricaoConfig { get; set; }
        public string TipoDadoConfig { get; set; }
        public DateTime? DataUltimaAtualizacao { get; set; }
    }
}
