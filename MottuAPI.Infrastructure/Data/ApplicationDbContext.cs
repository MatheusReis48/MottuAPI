using System;
using Microsoft.EntityFrameworkCore;
using MottuAPI.Domain.Entities;

namespace MottuAPI.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Filial> Filiais { get; set; }
        public DbSet<TipoMoto> TiposMotos { get; set; }
        public DbSet<StatusMotoCatalogo> StatusMotoCatalogos { get; set; }
        public DbSet<TipoUsuario> TiposUsuarios { get; set; }
        public DbSet<ConfiguracaoSistema> ConfiguracoesSistema { get; set; }
        public DbSet<Patio> Patios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<AreaPatio> AreasPatios { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<Moto> Motos { get; set; }
        public DbSet<PermissaoTipoUsuario> PermissoesTipoUsuario { get; set; }
        public DbSet<DadoEventoVisaoComputacional> DadosEventoVisaoComputacional { get; set; }
        public DbSet<HistoricoLocalizacaoMoto> HistoricoLocalizacaoMotos { get; set; }
        public DbSet<HistoricoStatusMoto> HistoricoStatusMotos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações das entidades
            ConfigureFilial(modelBuilder);
            ConfigureTipoMoto(modelBuilder);
            ConfigureStatusMotoCatalogo(modelBuilder);
            ConfigureTipoUsuario(modelBuilder);
            ConfigureConfiguracaoSistema(modelBuilder);
            ConfigurePatio(modelBuilder);
            ConfigureUsuario(modelBuilder);
            ConfigureAreaPatio(modelBuilder);
            ConfigureVaga(modelBuilder);
            ConfigureMoto(modelBuilder);
            ConfigurePermissaoTipoUsuario(modelBuilder);
            ConfigureDadoEventoVisaoComputacional(modelBuilder);
            ConfigureHistoricoLocalizacaoMoto(modelBuilder);
            ConfigureHistoricoStatusMoto(modelBuilder);
        }

        private void ConfigureFilial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filial>(entity =>
            {
                entity.ToTable("FILIAIS");
                entity.HasKey(e => e.IdFilial);
                entity.Property(e => e.IdFilial).HasColumnName("ID_FILIAL").ValueGeneratedOnAdd();
                entity.Property(e => e.NomeFilial).HasColumnName("NOME_FILIAL").IsRequired().HasMaxLength(150);
                entity.Property(e => e.CnpjFilial).HasColumnName("CNPJ_FILIAL").HasMaxLength(18);
                entity.Property(e => e.EnderecoFilial).HasColumnName("ENDERECO_FILIAL").HasMaxLength(255);
                entity.Property(e => e.CidadeFilial).HasColumnName("CIDADE_FILIAL").HasMaxLength(100);
                entity.Property(e => e.EstadoFilial).HasColumnName("ESTADO_FILIAL").HasMaxLength(2);
                entity.Property(e => e.CepFilial).HasColumnName("CEP_FILIAL").HasMaxLength(9);
                entity.Property(e => e.TelefoneFilial).HasColumnName("TELEFONE_FILIAL").HasMaxLength(20);
                entity.Property(e => e.EmailFilial).HasColumnName("EMAIL_FILIAL").HasMaxLength(100);
                entity.Property(e => e.DataCadastro).HasColumnName("DATA_CADASTRO").HasDefaultValueSql("SYSTIMESTAMP");
                entity.Property(e => e.DataUltimaAtualizacao).HasColumnName("DATA_ULTIMA_ATUALIZACAO");

                entity.HasIndex(e => e.NomeFilial).IsUnique();
                entity.HasIndex(e => e.CnpjFilial).IsUnique();
            });
        }

        private void ConfigureTipoMoto(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoMoto>(entity =>
            {
                entity.ToTable("TIPOS_MOTO");
                entity.HasKey(e => e.IdTipoMoto);
                entity.Property(e => e.IdTipoMoto).HasColumnName("ID_TIPO_MOTO").ValueGeneratedOnAdd();
                entity.Property(e => e.ModeloMoto).HasColumnName("MODELO_MOTO").IsRequired().HasMaxLength(100);
                entity.Property(e => e.MarcaMoto).HasColumnName("MARCA_MOTO").HasMaxLength(50);
                entity.Property(e => e.AnoFabricacaoModelo).HasColumnName("ANO_FABRICACAO_MODELO");
                entity.Property(e => e.DescricaoTipoMoto).HasColumnName("DESCRICAO_TIPO_MOTO").HasMaxLength(500);
                entity.Property(e => e.UrlImagemModelo).HasColumnName("URL_IMAGEM_MODELO").HasMaxLength(500);

                entity.HasIndex(e => e.ModeloMoto).IsUnique();
            });
        }

        private void ConfigureStatusMotoCatalogo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusMotoCatalogo>(entity =>
            {
                entity.ToTable("STATUS_MOTO_CATALOGO");
                entity.HasKey(e => e.IdStatusMoto);
                entity.Property(e => e.IdStatusMoto).HasColumnName("ID_STATUS_MOTO").ValueGeneratedOnAdd();
                entity.Property(e => e.DescricaoStatus).HasColumnName("DESCRICAO_STATUS").IsRequired().HasMaxLength(50);
                entity.Property(e => e.CorIndicativaStatus).HasColumnName("COR_INDICATIVA_STATUS").HasMaxLength(7);

                entity.HasIndex(e => e.DescricaoStatus).IsUnique();
            });
        }

        private void ConfigureTipoUsuario(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.ToTable("TIPOS_USUARIO");
                entity.HasKey(e => e.IdTipoUsuario);
                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO").ValueGeneratedOnAdd();
                entity.Property(e => e.NomeTipoUsuario).HasColumnName("NOME_TIPO_USUARIO").IsRequired().HasMaxLength(50);
                entity.Property(e => e.DescricaoTipoUsuario).HasColumnName("DESCRICAO_TIPO_USUARIO").HasMaxLength(255);

                entity.HasIndex(e => e.NomeTipoUsuario).IsUnique();
            });
        }

        private void ConfigureConfiguracaoSistema(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfiguracaoSistema>(entity =>
            {
                entity.ToTable("CONFIGURACOES_SISTEMA");
                entity.HasKey(e => e.ChaveConfig);
                entity.Property(e => e.ChaveConfig).HasColumnName("CHAVE_CONFIG").HasMaxLength(100);
                entity.Property(e => e.ValorConfig).HasColumnName("VALOR_CONFIG").IsRequired().HasMaxLength(500);
                entity.Property(e => e.DescricaoConfig).HasColumnName("DESCRICAO_CONFIG").HasMaxLength(255);
                entity.Property(e => e.TipoDadoConfig).HasColumnName("TIPO_DADO_CONFIG").HasMaxLength(20).HasDefaultValue("TEXTO");
                entity.Property(e => e.DataUltimaAtualizacao).HasColumnName("DATA_ULTIMA_ATUALIZACAO");
            });
        }

        private void ConfigurePatio(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patio>(entity =>
            {
                entity.ToTable("PATIOS");
                entity.HasKey(e => e.IdPatio);
                entity.Property(e => e.IdPatio).HasColumnName("ID_PATIO").ValueGeneratedOnAdd();
                entity.Property(e => e.IdFilial).HasColumnName("ID_FILIAL");
                entity.Property(e => e.NomePatio).HasColumnName("NOME_PATIO").IsRequired().HasMaxLength(100);
                entity.Property(e => e.DescricaoPatio).HasColumnName("DESCRICAO_PATIO").HasMaxLength(500);
                entity.Property(e => e.CapacidadeTotalMotos).HasColumnName("CAPACIDADE_TOTAL_MOTOS");
                entity.Property(e => e.DimensoesPatioMetrosQuadrados).HasColumnName("DIMENSOES_PATIO_METROS_QUADRADOS");
                entity.Property(e => e.LayoutPatioImgUrl).HasColumnName("LAYOUT_PATIO_IMG_URL").HasMaxLength(500);
                entity.Property(e => e.DataCadastro).HasColumnName("DATA_CADASTRO").HasDefaultValueSql("SYSTIMESTAMP");

                entity.HasOne(e => e.Filial)
                    .WithMany(f => f.Patios)
                    .HasForeignKey(e => e.IdFilial)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PATIOS_FILIAL");
            });
        }

        private void ConfigureUsuario(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIOS");
                entity.HasKey(e => e.IdUsuario);
                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO").ValueGeneratedOnAdd();
                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");
                entity.Property(e => e.IdFilialAssociada).HasColumnName("ID_FILIAL_ASSOCIADA");
                entity.Property(e => e.NomeCompletoUsuario).HasColumnName("NOME_COMPLETO_USUARIO").IsRequired().HasMaxLength(150);
                entity.Property(e => e.LoginUsuario).HasColumnName("LOGIN_USUARIO").IsRequired().HasMaxLength(50);
                entity.Property(e => e.SenhaHashUsuario).HasColumnName("SENHA_HASH_USUARIO").IsRequired().HasMaxLength(255);
                entity.Property(e => e.EmailUsuario).HasColumnName("EMAIL_USUARIO").IsRequired().HasMaxLength(100);
                entity.Property(e => e.TelefoneUsuario).HasColumnName("TELEFONE_USUARIO").HasMaxLength(20);
                entity.Property(e => e.StatusUsuario).HasColumnName("STATUS_USUARIO").HasMaxLength(10).HasDefaultValue("ATIVO");
                entity.Property(e => e.DataCadastroUsuario).HasColumnName("DATA_CADASTRO_USUARIO").HasDefaultValueSql("SYSTIMESTAMP");
                entity.Property(e => e.DataUltimoLogin).HasColumnName("DATA_ULTIMO_LOGIN");

                entity.HasIndex(e => e.LoginUsuario).IsUnique();
                entity.HasIndex(e => e.EmailUsuario).IsUnique();

                entity.HasOne(e => e.TipoUsuario)
                    .WithMany(t => t.Usuarios)
                    .HasForeignKey(e => e.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_USUARIOS_TIPO");

                entity.HasOne(e => e.FilialAssociada)
                    .WithMany(f => f.Usuarios)
                    .HasForeignKey(e => e.IdFilialAssociada)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_USUARIOS_FILIAL");
            });
        }

        private void ConfigureAreaPatio(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AreaPatio>(entity =>
            {
                entity.ToTable("AREAS_PATIO");
                entity.HasKey(e => e.IdAreaPatio);
                entity.Property(e => e.IdAreaPatio).HasColumnName("ID_AREA_PATIO").ValueGeneratedOnAdd();
                entity.Property(e => e.IdPatio).HasColumnName("ID_PATIO");
                entity.Property(e => e.NomeArea).HasColumnName("NOME_AREA").IsRequired().HasMaxLength(100);
                entity.Property(e => e.DescricaoArea).HasColumnName("DESCRICAO_AREA").HasMaxLength(255);
                entity.Property(e => e.TipoArea).HasColumnName("TIPO_AREA").HasMaxLength(50);

                entity.HasOne(e => e.Patio)
                    .WithMany(p => p.AreasPatio)
                    .HasForeignKey(e => e.IdPatio)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AREAS_PATIO_PATIO");
            });
        }

        private void ConfigureVaga(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vaga>(entity =>
            {
                entity.ToTable("VAGAS");
                entity.HasKey(e => e.IdVaga);
                entity.Property(e => e.IdVaga).HasColumnName("ID_VAGA").ValueGeneratedOnAdd();
                entity.Property(e => e.IdAreaPatio).HasColumnName("ID_AREA_PATIO");
                entity.Property(e => e.CodigoVaga).HasColumnName("CODIGO_VAGA").IsRequired().HasMaxLength(20);
                entity.Property(e => e.TipoVaga).HasColumnName("TIPO_VAGA").HasMaxLength(50).HasDefaultValue("NORMAL");
                entity.Property(e => e.CoordenadaXPatio).HasColumnName("COORDENADA_X_PATIO");
                entity.Property(e => e.CoordenadaYPatio).HasColumnName("COORDENADA_Y_PATIO");
                entity.Property(e => e.CoordenadaZPatio).HasColumnName("COORDENADA_Z_PATIO");
                entity.Property(e => e.PoligonoVagaGeoJson).HasColumnName("POLIGONO_VAGA_GEOJSON");
                entity.Property(e => e.StatusVaga).HasColumnName("STATUS_VAGA").HasMaxLength(20).HasDefaultValue("LIVRE");

                entity.HasIndex(e => new { e.IdAreaPatio, e.CodigoVaga }).IsUnique();

                entity.HasOne(e => e.AreaPatio)
                    .WithMany(a => a.Vagas)
                    .HasForeignKey(e => e.IdAreaPatio)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_VAGAS_AREA_PATIO");
            });
        }

        private void ConfigureMoto(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Moto>(entity =>
            {
                entity.ToTable("MOTOS");
                entity.HasKey(e => e.IdMoto);
                entity.Property(e => e.IdMoto).HasColumnName("ID_MOTO").ValueGeneratedOnAdd();
                entity.Property(e => e.IdTipoMoto).HasColumnName("ID_TIPO_MOTO");
                entity.Property(e => e.PlacaMoto).HasColumnName("PLACA_MOTO").IsRequired().HasMaxLength(8);
                entity.Property(e => e.ChassiMoto).HasColumnName("CHASSI_MOTO").HasMaxLength(17);
                entity.Property(e => e.RenavamMoto).HasColumnName("RENAVAM_MOTO").HasMaxLength(11);
                entity.Property(e => e.AnoFabricacaoMoto).HasColumnName("ANO_FABRICACAO_MOTO");
                entity.Property(e => e.AnoModeloMoto).HasColumnName("ANO_MODELO_MOTO");
                entity.Property(e => e.CorMoto).HasColumnName("COR_MOTO").HasMaxLength(30);
                entity.Property(e => e.IdFilialBase).HasColumnName("ID_FILIAL_BASE");
                entity.Property(e => e.IdStatusMotoAtual).HasColumnName("ID_STATUS_MOTO_ATUAL");
                entity.Property(e => e.IdVagaAtual).HasColumnName("ID_VAGA_ATUAL");
                entity.Property(e => e.UltimaLocalizacaoLatitude).HasColumnName("ULTIMA_LOCALIZACAO_LATITUDE").HasPrecision(10, 7);
                entity.Property(e => e.UltimaLocalizacaoLongitude).HasColumnName("ULTIMA_LOCALIZACAO_LONGITUDE").HasPrecision(10, 7);
                entity.Property(e => e.TimestampUltimaLocalizacao).HasColumnName("TIMESTAMP_ULTIMA_LOCALIZACAO");
                entity.Property(e => e.ObservacoesMoto).HasColumnName("OBSERVACOES_MOTO").HasMaxLength(1000);
                entity.Property(e => e.DataCadastroMoto).HasColumnName("DATA_CADASTRO_MOTO").HasDefaultValueSql("SYSTIMESTAMP");
                entity.Property(e => e.DataUltimaAtualizacaoMoto).HasColumnName("DATA_ULTIMA_ATUALIZACAO_MOTO");

                entity.HasIndex(e => e.PlacaMoto).IsUnique();
                entity.HasIndex(e => e.ChassiMoto).IsUnique();
                entity.HasIndex(e => e.RenavamMoto).IsUnique();
                entity.HasIndex(e => e.IdVagaAtual).IsUnique();

                entity.HasOne(e => e.TipoMoto)
                    .WithMany(t => t.Motos)
                    .HasForeignKey(e => e.IdTipoMoto)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MOTOS_TIPO");

                entity.HasOne(e => e.FilialBase)
                    .WithMany(f => f.Motos)
                    .HasForeignKey(e => e.IdFilialBase)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MOTOS_FILIAL_BASE");

                entity.HasOne(e => e.StatusMotoAtual)
                    .WithMany(s => s.Motos)
                    .HasForeignKey(e => e.IdStatusMotoAtual)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MOTOS_STATUS_ATUAL");

                entity.HasOne(e => e.VagaAtual)
                    .WithOne(v => v.Moto)
                    .HasForeignKey<Moto>(e => e.IdVagaAtual)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MOTOS_VAGA_ATUAL");
            });
        }

        private void ConfigurePermissaoTipoUsuario(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissaoTipoUsuario>(entity =>
            {
                entity.ToTable("PERMISSOES_TIPO_USUARIO");
                entity.HasKey(e => e.IdPermissaoTipoUsuario);
                entity.Property(e => e.IdPermissaoTipoUsuario).HasColumnName("ID_PERMISSAO_TIPO_USUARIO").ValueGeneratedOnAdd();
                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");
                entity.Property(e => e.NomePermissao).HasColumnName("NOME_PERMISSAO").IsRequired().HasMaxLength(100);
                entity.Property(e => e.Permitido).HasColumnName("PERMITIDO").HasDefaultValue(1);

                entity.HasIndex(e => new { e.IdTipoUsuario, e.NomePermissao }).IsUnique();

                entity.HasOne(e => e.TipoUsuario)
                    .WithMany(t => t.PermissoesTipoUsuario)
                    .HasForeignKey(e => e.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PERM_TIPO_USUARIO_TIPO");
            });
        }

        private void ConfigureDadoEventoVisaoComputacional(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DadoEventoVisaoComputacional>(entity =>
            {
                entity.ToTable("DADOS_EVENTO_VISAO_COMPUTACIONAL");
                entity.HasKey(e => e.IdEventoVC);
                entity.Property(e => e.IdEventoVC).HasColumnName("ID_EVENTO_VC").ValueGeneratedOnAdd();
                entity.Property(e => e.IdPatio).HasColumnName("ID_PATIO");
                entity.Property(e => e.IdCamera).HasColumnName("ID_CAMERA").HasMaxLength(50);
                entity.Property(e => e.TimestampEvento).HasColumnName("TIMESTAMP_EVENTO").IsRequired();
                entity.Property(e => e.PlacaDetectada).HasColumnName("PLACA_DETECTADA").HasMaxLength(10);
                entity.Property(e => e.ModeloDetectado).HasColumnName("MODELO_DETECTADO").HasMaxLength(100);
                entity.Property(e => e.CoordenadasDeteccaoImg).HasColumnName("COORDENADAS_DETECCAO_IMG").HasMaxLength(100);
                entity.Property(e => e.UrlSnapshotImg).HasColumnName("URL_SNAPSHOT_IMG").HasMaxLength(500);
                entity.Property(e => e.ConfiancaDeteccao).HasColumnName("CONFIANCA_DETECCAO").HasPrecision(5, 2);
                entity.Property(e => e.StatusProcessamento).HasColumnName("STATUS_PROCESSAMENTO").HasMaxLength(20).HasDefaultValue("PENDENTE");
                entity.Property(e => e.IdMotoAssociada).HasColumnName("ID_MOTO_ASSOCIADA");
                entity.Property(e => e.IdVagaAssociada).HasColumnName("ID_VAGA_ASSOCIADA");

                entity.HasOne(e => e.Patio)
                    .WithMany(p => p.DadosEventoVisaoComputacional)
                    .HasForeignKey(e => e.IdPatio)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_EVENTO_VC_PATIO");

                entity.HasOne(e => e.MotoAssociada)
                    .WithMany(m => m.DadosEventoVisaoComputacional)
                    .HasForeignKey(e => e.IdMotoAssociada)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_EVENTO_VC_MOTO");

                entity.HasOne(e => e.VagaAssociada)
                    .WithMany(v => v.DadosEventoVisaoComputacional)
                    .HasForeignKey(e => e.IdVagaAssociada)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_EVENTO_VC_VAGA");
            });
        }

        private void ConfigureHistoricoLocalizacaoMoto(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistoricoLocalizacaoMoto>(entity =>
            {
                entity.ToTable("HISTORICO_LOCALIZACAO_MOTO");
                entity.HasKey(e => e.IdHistoricoLoc);
                entity.Property(e => e.IdHistoricoLoc).HasColumnName("ID_HISTORICO_LOC").ValueGeneratedOnAdd();
                entity.Property(e => e.IdMoto).HasColumnName("ID_MOTO");
                entity.Property(e => e.IdVagaAnterior).HasColumnName("ID_VAGA_ANTERIOR");
                entity.Property(e => e.IdVagaNova).HasColumnName("ID_VAGA_NOVA");
                entity.Property(e => e.LatitudeRegistro).HasColumnName("LATITUDE_REGISTRO").HasPrecision(10, 7);
                entity.Property(e => e.LongitudeRegistro).HasColumnName("LONGITUDE_REGISTRO").HasPrecision(10, 7);
                entity.Property(e => e.TimestampRegistro).HasColumnName("TIMESTAMP_REGISTRO").IsRequired().HasDefaultValueSql("SYSTIMESTAMP");
                entity.Property(e => e.FonteDadoLocalizacao).HasColumnName("FONTE_DADO_LOCALIZACAO").IsRequired().HasMaxLength(50);
                entity.Property(e => e.IdUsuarioRegistro).HasColumnName("ID_USUARIO_REGISTRO");

                entity.HasOne(e => e.Moto)
                    .WithMany(m => m.HistoricoLocalizacaoMotos)
                    .HasForeignKey(e => e.IdMoto)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_HIST_LOC_MOTO");

                entity.HasOne(e => e.VagaAnterior)
                    .WithMany(v => v.HistoricoLocalizacaoMotosAnteriores)
                    .HasForeignKey(e => e.IdVagaAnterior)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_HIST_LOC_VAGA_ANT");

                entity.HasOne(e => e.VagaNova)
                    .WithMany(v => v.HistoricoLocalizacaoMotosNovas)
                    .HasForeignKey(e => e.IdVagaNova)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_HIST_LOC_VAGA_NOVA");

                entity.HasOne(e => e.UsuarioRegistro)
                    .WithMany(u => u.HistoricoLocalizacaoMotos)
                    .HasForeignKey(e => e.IdUsuarioRegistro)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_HIST_LOC_USUARIO");
            });
        }

        private void ConfigureHistoricoStatusMoto(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistoricoStatusMoto>(entity =>
            {
                entity.ToTable("HISTORICO_STATUS_MOTO");
                entity.HasKey(e => e.IdHistoricoStatus);
                entity.Property(e => e.IdHistoricoStatus).HasColumnName("ID_HISTORICO_STATUS").ValueGeneratedOnAdd();
                entity.Property(e => e.IdMoto).HasColumnName("ID_MOTO");
                entity.Property(e => e.IdStatusAnterior).HasColumnName("ID_STATUS_ANTERIOR");
                entity.Property(e => e.IdStatusNovo).HasColumnName("ID_STATUS_NOVO");
                entity.Property(e => e.TimestampMudancaStatus).HasColumnName("TIMESTAMP_MUDANCA_STATUS").IsRequired().HasDefaultValueSql("SYSTIMESTAMP");
                entity.Property(e => e.IdUsuarioResponsavel).HasColumnName("ID_USUARIO_RESPONSAVEL");
                entity.Property(e => e.MotivoMudanca).HasColumnName("MOTIVO_MUDANCA").HasMaxLength(500);

                entity.HasOne(e => e.Moto)
                    .WithMany(m => m.HistoricoStatusMotos)
                    .HasForeignKey(e => e.IdMoto)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_HIST_STATUS_MOTO");

                entity.HasOne(e => e.StatusAnterior)
                    .WithMany(s => s.HistoricoStatusMotosAnteriores)
                    .HasForeignKey(e => e.IdStatusAnterior)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_HIST_STATUS_ANT");

                entity.HasOne(e => e.StatusNovo)
                    .WithMany(s => s.HistoricoStatusMotosNovos)
                    .HasForeignKey(e => e.IdStatusNovo)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_HIST_STATUS_NOVO");

                entity.HasOne(e => e.UsuarioResponsavel)
                    .WithMany(u => u.HistoricoStatusMotos)
                    .HasForeignKey(e => e.IdUsuarioResponsavel)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_HIST_STATUS_USUARIO");
            });
        }
    }
}
