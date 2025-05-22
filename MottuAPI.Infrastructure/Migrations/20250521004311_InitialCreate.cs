using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MottuAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CONFIGURACOES_SISTEMA",
                columns: table => new
                {
                    CHAVE_CONFIG = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    VALOR_CONFIG = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    DESCRICAO_CONFIG = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    TIPO_DADO_CONFIG = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false, defaultValue: "TEXTO"),
                    DATA_ULTIMA_ATUALIZACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONFIGURACOES_SISTEMA", x => x.CHAVE_CONFIG);
                });

            migrationBuilder.CreateTable(
                name: "FILIAIS",
                columns: table => new
                {
                    ID_FILIAL = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME_FILIAL = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    CNPJ_FILIAL = table.Column<string>(type: "NVARCHAR2(18)", maxLength: 18, nullable: false),
                    ENDERECO_FILIAL = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    CIDADE_FILIAL = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ESTADO_FILIAL = table.Column<string>(type: "NVARCHAR2(2)", maxLength: 2, nullable: false),
                    CEP_FILIAL = table.Column<string>(type: "NVARCHAR2(9)", maxLength: 9, nullable: false),
                    TELEFONE_FILIAL = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    EMAIL_FILIAL = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false, defaultValueSql: "SYSTIMESTAMP"),
                    DATA_ULTIMA_ATUALIZACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FILIAIS", x => x.ID_FILIAL);
                });

            migrationBuilder.CreateTable(
                name: "STATUS_MOTO_CATALOGO",
                columns: table => new
                {
                    ID_STATUS_MOTO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DESCRICAO_STATUS = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    COR_INDICATIVA_STATUS = table.Column<string>(type: "NVARCHAR2(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATUS_MOTO_CATALOGO", x => x.ID_STATUS_MOTO);
                });

            migrationBuilder.CreateTable(
                name: "TIPOS_MOTO",
                columns: table => new
                {
                    ID_TIPO_MOTO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MODELO_MOTO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    MARCA_MOTO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ANO_FABRICACAO_MODELO = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    DESCRICAO_TIPO_MOTO = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    URL_IMAGEM_MODELO = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPOS_MOTO", x => x.ID_TIPO_MOTO);
                });

            migrationBuilder.CreateTable(
                name: "TIPOS_USUARIO",
                columns: table => new
                {
                    ID_TIPO_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME_TIPO_USUARIO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    DESCRICAO_TIPO_USUARIO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPOS_USUARIO", x => x.ID_TIPO_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "PATIOS",
                columns: table => new
                {
                    ID_PATIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_FILIAL = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NOME_PATIO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DESCRICAO_PATIO = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    CAPACIDADE_TOTAL_MOTOS = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    DIMENSOES_PATIO_METROS_QUADRADOS = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    LAYOUT_PATIO_IMG_URL = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false, defaultValueSql: "SYSTIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PATIOS", x => x.ID_PATIO);
                    table.ForeignKey(
                        name: "FK_PATIOS_FILIAL",
                        column: x => x.ID_FILIAL,
                        principalTable: "FILIAIS",
                        principalColumn: "ID_FILIAL",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERMISSOES_TIPO_USUARIO",
                columns: table => new
                {
                    ID_PERMISSAO_TIPO_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_TIPO_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NOME_PERMISSAO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    PERMITIDO = table.Column<bool>(type: "BOOLEAN", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISSOES_TIPO_USUARIO", x => x.ID_PERMISSAO_TIPO_USUARIO);
                    table.ForeignKey(
                        name: "FK_PERM_TIPO_USUARIO_TIPO",
                        column: x => x.ID_TIPO_USUARIO,
                        principalTable: "TIPOS_USUARIO",
                        principalColumn: "ID_TIPO_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_TIPO_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_FILIAL_ASSOCIADA = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    NOME_COMPLETO_USUARIO = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    LOGIN_USUARIO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    SENHA_HASH_USUARIO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    EMAIL_USUARIO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TELEFONE_USUARIO = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    STATUS_USUARIO = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false, defaultValue: "ATIVO"),
                    DATA_CADASTRO_USUARIO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false, defaultValueSql: "SYSTIMESTAMP"),
                    DATA_ULTIMO_LOGIN = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.ID_USUARIO);
                    table.ForeignKey(
                        name: "FK_USUARIOS_FILIAL",
                        column: x => x.ID_FILIAL_ASSOCIADA,
                        principalTable: "FILIAIS",
                        principalColumn: "ID_FILIAL",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USUARIOS_TIPO",
                        column: x => x.ID_TIPO_USUARIO,
                        principalTable: "TIPOS_USUARIO",
                        principalColumn: "ID_TIPO_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AREAS_PATIO",
                columns: table => new
                {
                    ID_AREA_PATIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_PATIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NOME_AREA = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DESCRICAO_AREA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    TIPO_AREA = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AREAS_PATIO", x => x.ID_AREA_PATIO);
                    table.ForeignKey(
                        name: "FK_AREAS_PATIO_PATIO",
                        column: x => x.ID_PATIO,
                        principalTable: "PATIOS",
                        principalColumn: "ID_PATIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VAGAS",
                columns: table => new
                {
                    ID_VAGA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_AREA_PATIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CODIGO_VAGA = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    TIPO_VAGA = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false, defaultValue: "NORMAL"),
                    COORDENADA_X_PATIO = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    COORDENADA_Y_PATIO = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    COORDENADA_Z_PATIO = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    POLIGONO_VAGA_GEOJSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    STATUS_VAGA = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false, defaultValue: "LIVRE")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VAGAS", x => x.ID_VAGA);
                    table.ForeignKey(
                        name: "FK_VAGAS_AREA_PATIO",
                        column: x => x.ID_AREA_PATIO,
                        principalTable: "AREAS_PATIO",
                        principalColumn: "ID_AREA_PATIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MOTOS",
                columns: table => new
                {
                    ID_MOTO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_TIPO_MOTO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PLACA_MOTO = table.Column<string>(type: "NVARCHAR2(8)", maxLength: 8, nullable: false),
                    CHASSI_MOTO = table.Column<string>(type: "NVARCHAR2(17)", maxLength: 17, nullable: false),
                    RENAVAM_MOTO = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    ANO_FABRICACAO_MOTO = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ANO_MODELO_MOTO = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    COR_MOTO = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    ID_FILIAL_BASE = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ID_STATUS_MOTO_ATUAL = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_VAGA_ATUAL = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ULTIMA_LOCALIZACAO_LATITUDE = table.Column<decimal>(type: "DECIMAL(10,7)", precision: 10, scale: 7, nullable: true),
                    ULTIMA_LOCALIZACAO_LONGITUDE = table.Column<decimal>(type: "DECIMAL(10,7)", precision: 10, scale: 7, nullable: true),
                    TIMESTAMP_ULTIMA_LOCALIZACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    OBSERVACOES_MOTO = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: false),
                    DATA_CADASTRO_MOTO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false, defaultValueSql: "SYSTIMESTAMP"),
                    DATA_ULTIMA_ATUALIZACAO_MOTO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOTOS", x => x.ID_MOTO);
                    table.ForeignKey(
                        name: "FK_MOTOS_FILIAL_BASE",
                        column: x => x.ID_FILIAL_BASE,
                        principalTable: "FILIAIS",
                        principalColumn: "ID_FILIAL",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MOTOS_STATUS_ATUAL",
                        column: x => x.ID_STATUS_MOTO_ATUAL,
                        principalTable: "STATUS_MOTO_CATALOGO",
                        principalColumn: "ID_STATUS_MOTO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MOTOS_TIPO",
                        column: x => x.ID_TIPO_MOTO,
                        principalTable: "TIPOS_MOTO",
                        principalColumn: "ID_TIPO_MOTO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MOTOS_VAGA_ATUAL",
                        column: x => x.ID_VAGA_ATUAL,
                        principalTable: "VAGAS",
                        principalColumn: "ID_VAGA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DADOS_EVENTO_VISAO_COMPUTACIONAL",
                columns: table => new
                {
                    ID_EVENTO_VC = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_PATIO = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ID_CAMERA = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    TIMESTAMP_EVENTO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PLACA_DETECTADA = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    MODELO_DETECTADO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    COORDENADAS_DETECCAO_IMG = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    URL_SNAPSHOT_IMG = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    CONFIANCA_DETECCAO = table.Column<decimal>(type: "DECIMAL(5,2)", precision: 5, scale: 2, nullable: true),
                    STATUS_PROCESSAMENTO = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false, defaultValue: "PENDENTE"),
                    ID_MOTO_ASSOCIADA = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ID_VAGA_ASSOCIADA = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DADOS_EVENTO_VISAO_COMPUTACIONAL", x => x.ID_EVENTO_VC);
                    table.ForeignKey(
                        name: "FK_EVENTO_VC_MOTO",
                        column: x => x.ID_MOTO_ASSOCIADA,
                        principalTable: "MOTOS",
                        principalColumn: "ID_MOTO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVENTO_VC_PATIO",
                        column: x => x.ID_PATIO,
                        principalTable: "PATIOS",
                        principalColumn: "ID_PATIO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EVENTO_VC_VAGA",
                        column: x => x.ID_VAGA_ASSOCIADA,
                        principalTable: "VAGAS",
                        principalColumn: "ID_VAGA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HISTORICO_LOCALIZACAO_MOTO",
                columns: table => new
                {
                    ID_HISTORICO_LOC = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_MOTO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_VAGA_ANTERIOR = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ID_VAGA_NOVA = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    LATITUDE_REGISTRO = table.Column<decimal>(type: "DECIMAL(10,7)", precision: 10, scale: 7, nullable: true),
                    LONGITUDE_REGISTRO = table.Column<decimal>(type: "DECIMAL(10,7)", precision: 10, scale: 7, nullable: true),
                    TIMESTAMP_REGISTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false, defaultValueSql: "SYSTIMESTAMP"),
                    FONTE_DADO_LOCALIZACAO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ID_USUARIO_REGISTRO = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISTORICO_LOCALIZACAO_MOTO", x => x.ID_HISTORICO_LOC);
                    table.ForeignKey(
                        name: "FK_HIST_LOC_MOTO",
                        column: x => x.ID_MOTO,
                        principalTable: "MOTOS",
                        principalColumn: "ID_MOTO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HIST_LOC_USUARIO",
                        column: x => x.ID_USUARIO_REGISTRO,
                        principalTable: "USUARIOS",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HIST_LOC_VAGA_ANT",
                        column: x => x.ID_VAGA_ANTERIOR,
                        principalTable: "VAGAS",
                        principalColumn: "ID_VAGA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HIST_LOC_VAGA_NOVA",
                        column: x => x.ID_VAGA_NOVA,
                        principalTable: "VAGAS",
                        principalColumn: "ID_VAGA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HISTORICO_STATUS_MOTO",
                columns: table => new
                {
                    ID_HISTORICO_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_MOTO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_STATUS_ANTERIOR = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ID_STATUS_NOVO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TIMESTAMP_MUDANCA_STATUS = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false, defaultValueSql: "SYSTIMESTAMP"),
                    ID_USUARIO_RESPONSAVEL = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    MOTIVO_MUDANCA = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISTORICO_STATUS_MOTO", x => x.ID_HISTORICO_STATUS);
                    table.ForeignKey(
                        name: "FK_HIST_STATUS_ANT",
                        column: x => x.ID_STATUS_ANTERIOR,
                        principalTable: "STATUS_MOTO_CATALOGO",
                        principalColumn: "ID_STATUS_MOTO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HIST_STATUS_MOTO",
                        column: x => x.ID_MOTO,
                        principalTable: "MOTOS",
                        principalColumn: "ID_MOTO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HIST_STATUS_NOVO",
                        column: x => x.ID_STATUS_NOVO,
                        principalTable: "STATUS_MOTO_CATALOGO",
                        principalColumn: "ID_STATUS_MOTO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HIST_STATUS_USUARIO",
                        column: x => x.ID_USUARIO_RESPONSAVEL,
                        principalTable: "USUARIOS",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AREAS_PATIO_ID_PATIO",
                table: "AREAS_PATIO",
                column: "ID_PATIO");

            migrationBuilder.CreateIndex(
                name: "IX_DADOS_EVENTO_VISAO_COMPUTACIONAL_ID_MOTO_ASSOCIADA",
                table: "DADOS_EVENTO_VISAO_COMPUTACIONAL",
                column: "ID_MOTO_ASSOCIADA");

            migrationBuilder.CreateIndex(
                name: "IX_DADOS_EVENTO_VISAO_COMPUTACIONAL_ID_PATIO",
                table: "DADOS_EVENTO_VISAO_COMPUTACIONAL",
                column: "ID_PATIO");

            migrationBuilder.CreateIndex(
                name: "IX_DADOS_EVENTO_VISAO_COMPUTACIONAL_ID_VAGA_ASSOCIADA",
                table: "DADOS_EVENTO_VISAO_COMPUTACIONAL",
                column: "ID_VAGA_ASSOCIADA");

            migrationBuilder.CreateIndex(
                name: "IX_FILIAIS_CNPJ_FILIAL",
                table: "FILIAIS",
                column: "CNPJ_FILIAL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FILIAIS_NOME_FILIAL",
                table: "FILIAIS",
                column: "NOME_FILIAL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICO_LOCALIZACAO_MOTO_ID_MOTO",
                table: "HISTORICO_LOCALIZACAO_MOTO",
                column: "ID_MOTO");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICO_LOCALIZACAO_MOTO_ID_USUARIO_REGISTRO",
                table: "HISTORICO_LOCALIZACAO_MOTO",
                column: "ID_USUARIO_REGISTRO");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICO_LOCALIZACAO_MOTO_ID_VAGA_ANTERIOR",
                table: "HISTORICO_LOCALIZACAO_MOTO",
                column: "ID_VAGA_ANTERIOR");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICO_LOCALIZACAO_MOTO_ID_VAGA_NOVA",
                table: "HISTORICO_LOCALIZACAO_MOTO",
                column: "ID_VAGA_NOVA");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICO_STATUS_MOTO_ID_MOTO",
                table: "HISTORICO_STATUS_MOTO",
                column: "ID_MOTO");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICO_STATUS_MOTO_ID_STATUS_ANTERIOR",
                table: "HISTORICO_STATUS_MOTO",
                column: "ID_STATUS_ANTERIOR");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICO_STATUS_MOTO_ID_STATUS_NOVO",
                table: "HISTORICO_STATUS_MOTO",
                column: "ID_STATUS_NOVO");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICO_STATUS_MOTO_ID_USUARIO_RESPONSAVEL",
                table: "HISTORICO_STATUS_MOTO",
                column: "ID_USUARIO_RESPONSAVEL");

            migrationBuilder.CreateIndex(
                name: "IX_MOTOS_CHASSI_MOTO",
                table: "MOTOS",
                column: "CHASSI_MOTO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MOTOS_ID_FILIAL_BASE",
                table: "MOTOS",
                column: "ID_FILIAL_BASE");

            migrationBuilder.CreateIndex(
                name: "IX_MOTOS_ID_STATUS_MOTO_ATUAL",
                table: "MOTOS",
                column: "ID_STATUS_MOTO_ATUAL");

            migrationBuilder.CreateIndex(
                name: "IX_MOTOS_ID_TIPO_MOTO",
                table: "MOTOS",
                column: "ID_TIPO_MOTO");

            migrationBuilder.CreateIndex(
                name: "IX_MOTOS_ID_VAGA_ATUAL",
                table: "MOTOS",
                column: "ID_VAGA_ATUAL",
                unique: true,
                filter: "\"ID_VAGA_ATUAL\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MOTOS_PLACA_MOTO",
                table: "MOTOS",
                column: "PLACA_MOTO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MOTOS_RENAVAM_MOTO",
                table: "MOTOS",
                column: "RENAVAM_MOTO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PATIOS_ID_FILIAL",
                table: "PATIOS",
                column: "ID_FILIAL");

            migrationBuilder.CreateIndex(
                name: "IX_PERMISSOES_TIPO_USUARIO_ID_TIPO_USUARIO_NOME_PERMISSAO",
                table: "PERMISSOES_TIPO_USUARIO",
                columns: new[] { "ID_TIPO_USUARIO", "NOME_PERMISSAO" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_STATUS_MOTO_CATALOGO_DESCRICAO_STATUS",
                table: "STATUS_MOTO_CATALOGO",
                column: "DESCRICAO_STATUS",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TIPOS_MOTO_MODELO_MOTO",
                table: "TIPOS_MOTO",
                column: "MODELO_MOTO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TIPOS_USUARIO_NOME_TIPO_USUARIO",
                table: "TIPOS_USUARIO",
                column: "NOME_TIPO_USUARIO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_EMAIL_USUARIO",
                table: "USUARIOS",
                column: "EMAIL_USUARIO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_ID_FILIAL_ASSOCIADA",
                table: "USUARIOS",
                column: "ID_FILIAL_ASSOCIADA");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_ID_TIPO_USUARIO",
                table: "USUARIOS",
                column: "ID_TIPO_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_LOGIN_USUARIO",
                table: "USUARIOS",
                column: "LOGIN_USUARIO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VAGAS_ID_AREA_PATIO_CODIGO_VAGA",
                table: "VAGAS",
                columns: new[] { "ID_AREA_PATIO", "CODIGO_VAGA" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONFIGURACOES_SISTEMA");

            migrationBuilder.DropTable(
                name: "DADOS_EVENTO_VISAO_COMPUTACIONAL");

            migrationBuilder.DropTable(
                name: "HISTORICO_LOCALIZACAO_MOTO");

            migrationBuilder.DropTable(
                name: "HISTORICO_STATUS_MOTO");

            migrationBuilder.DropTable(
                name: "PERMISSOES_TIPO_USUARIO");

            migrationBuilder.DropTable(
                name: "MOTOS");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "STATUS_MOTO_CATALOGO");

            migrationBuilder.DropTable(
                name: "TIPOS_MOTO");

            migrationBuilder.DropTable(
                name: "VAGAS");

            migrationBuilder.DropTable(
                name: "TIPOS_USUARIO");

            migrationBuilder.DropTable(
                name: "AREAS_PATIO");

            migrationBuilder.DropTable(
                name: "PATIOS");

            migrationBuilder.DropTable(
                name: "FILIAIS");
        }
    }
}
