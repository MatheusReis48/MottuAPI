# MottuAPI - Sistema de Mapeamento Inteligente de Pátio

## Descrição do Projeto

O MottuAPI é uma API RESTful desenvolvida em ASP.NET Core 8.0 para o sistema de Mapeamento Inteligente do Pátio e Gestão das Motos da Mottu. Este sistema visa solucionar o problema de controle manual da localização de motos em mais de 100 pátios, automatizando a identificação, localização e monitoramento das motos através de tecnologia de visão computacional e IoT.

### O Problema

A Mottu gerencia uma grande frota de motos em mais de 100 pátios, mas o controle da localização de cada moto é feito manualmente. Isso gera imprecisões, lentidão e impacta a eficiência operacional.

### A Solução

O sistema de Mapeamento Inteligente do Pátio e Gestão das Motos utiliza tecnologia para automatizar a identificação, localização e monitoramento das motos nos pátios, fornecendo uma visão em tempo real da disposição da frota através de uma interface intuitiva.

## Arquitetura

O projeto segue uma arquitetura em camadas, com separação clara de responsabilidades:

- **MottuAPI.Domain**: Contém as entidades de domínio e regras de negócio
- **MottuAPI.Application**: Contém DTOs, interfaces de serviço e implementações
- **MottuAPI.Infrastructure**: Contém a configuração do banco de dados e repositórios
- **MottuAPI.API**: Contém os controllers e configuração da API

## Tecnologias Utilizadas

- **ASP.NET Core 8.0**: Framework para desenvolvimento da API
- **Entity Framework Core**: ORM para acesso ao banco de dados
- **Oracle Database**: Banco de dados relacional
- **Swagger/OpenAPI**: Documentação da API
- **AutoMapper**: Mapeamento entre entidades e DTOs

## Instalação

### Pré-requisitos

- .NET SDK 8.0 ou superior
- Oracle Database
- Visual Studio 

### Passos para Instalação

1. Clone o repositório:
   ```
   git clone https://github.com/MatheusReis48/MottuAPI
   ```

2. Navegue até a pasta do projeto:
   ```
   cd MottuAPI_Novo
   ```

3. Restaure os pacotes NuGet:
   ```
   dotnet restore
   ```

4. Configure a string de conexão com o banco de dados Oracle no arquivo `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "User Id=seu_usuario;Password=sua_senha;Data Source=seu_servidor:1521/seu_servico;"
   }
   ```

5. Execute as migrations para criar o banco de dados:
   ```
   dotnet ef database update --project MottuAPI.Infrastructure --startup-project MottuAPI.API
   ```

6. Execute o projeto:
   ```
   dotnet run --project MottuAPI.API
   ```

7. Acesse a documentação Swagger em:
   ```
   https://localhost:5038/swagger
   
   ```

## Rotas Disponíveis

A API oferece endpoints para gerenciar motos, pátios, áreas de pátio, vagas e usuários. Abaixo estão as principais rotas disponíveis:

### Motos

- **GET /api/Motos**: Retorna todas as motos cadastradas
- **GET /api/Motos/{id}**: Retorna uma moto específica pelo ID
- **GET /api/Motos/filial/{idFilial}**: Retorna motos de uma filial específica
- **GET /api/Motos/status/{idStatus}**: Retorna motos com um status específico
- **GET /api/Motos/patio/{idPatio}**: Retorna motos de um pátio específico
- **POST /api/Motos**: Cadastra uma nova moto
- **PUT /api/Motos/{id}**: Atualiza uma moto existente
- **DELETE /api/Motos/{id}**: Remove uma moto

### Pátios

- **GET /api/Patios**: Retorna todos os pátios cadastrados
- **GET /api/Patios/{id}**: Retorna um pátio específico pelo ID
- **GET /api/Patios/filial/{idFilial}**: Retorna pátios de uma filial específica
- **POST /api/Patios**: Cadastra um novo pátio
- **PUT /api/Patios/{id}**: Atualiza um pátio existente
- **DELETE /api/Patios/{id}**: Remove um pátio

### Usuários

- **GET /api/Usuarios**: Retorna todos os usuários cadastrados
- **GET /api/Usuarios/{id}**: Retorna um usuário específico pelo ID
- **GET /api/Usuarios/login/{login}**: Retorna um usuário pelo login
- **GET /api/Usuarios/tipo/{idTipoUsuario}**: Retorna usuários de um tipo específico
- **GET /api/Usuarios/filial/{idFilial}**: Retorna usuários de uma filial específica
- **POST /api/Usuarios**: Cadastra um novo usuário
- **PUT /api/Usuarios/{id}**: Atualiza um usuário existente
- **PUT /api/Usuarios/{id}/senha**: Atualiza a senha de um usuário
- **DELETE /api/Usuarios/{id}**: Remove um usuário

## Exemplos de Uso

### Cadastrar uma nova moto

**Requisição:**
```http
POST /api/Motos
Content-Type: application/json

{
  "placa": "ABC1234",
  "chassi": "9BWZZZ377VT004251",
  "idTipoMoto": 1,
  "idFilial": 1,
  "idPatio": 2,
  "idVaga": 15,
  "idStatusMoto": 1,
  "observacoes": "Moto nova em excelente estado"
}
```

**Resposta:**
```json
{
  "idMoto": 1,
  "placa": "ABC1234",
  "chassi": "9BWZZZ377VT004251",
  "idTipoMoto": 1,
  "tipoMoto": {
    "idTipoMoto": 1,
    "modeloMoto": "CG 160",
    "marcaMoto": "Honda"
  },
  "idFilial": 1,
  "filial": {
    "idFilial": 1,
    "nomeFilial": "São Paulo - Centro"
  },
  "idPatio": 2,
  "patio": {
    "idPatio": 2,
    "nomePatio": "Pátio Central"
  },
  "idVaga": 15,
  "vaga": {
    "idVaga": 15,
    "codigoVaga": "A15"
  },
  "idStatusMoto": 1,
  "statusMoto": {
    "idStatusMoto": 1,
    "descricaoStatus": "Disponível"
  },
  "observacoes": "Moto nova em excelente estado",
  "dataCadastro": "2025-05-21T00:56:21.123456Z",
  "dataUltimaAtualizacao": "2025-05-21T00:56:21.123456Z"
}
```

### Obter todas as motos de um pátio

**Requisição:**
```http
GET /api/Motos/patio/2
```

**Resposta:**
```json
[
  {
    "idMoto": 1,
    "placa": "ABC1234",
    "chassi": "9BWZZZ377VT004251",
    "idTipoMoto": 1,
    "tipoMoto": {
      "idTipoMoto": 1,
      "modeloMoto": "CG 160",
      "marcaMoto": "Honda"
    },
    "idFilial": 1,
    "idPatio": 2,
    "idVaga": 15,
    "idStatusMoto": 1,
    "observacoes": "Moto nova em excelente estado"
  },
  {
    "idMoto": 2,
    "placa": "DEF5678",
    "chassi": "9BWZZZ377VT004252",
    "idTipoMoto": 2,
    "tipoMoto": {
      "idTipoMoto": 2,
      "modeloMoto": "Factor 150",
      "marcaMoto": "Yamaha"
    },
    "idFilial": 1,
    "idPatio": 2,
    "idVaga": 16,
    "idStatusMoto": 1,
    "observacoes": "Moto com revisão em dia"
  }
]
```

## Considerações Finais

Este projeto foi desenvolvido como parte do curso de Advanced Business Development with .NET, atendendo aos requisitos de implementação de uma API RESTful com ASP.NET Core, integração com banco de dados Oracle via EF Core e documentação OpenAPI.

Para mais detalhes sobre a implementação e uso da API, consulte a documentação Swagger disponível na raiz da aplicação quando em execução.