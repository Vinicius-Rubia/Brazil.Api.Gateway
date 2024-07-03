# 🌐 Brazil.Api.Gateway

Um gateway simples em C# para consumir a API da BrasilAPI.

Este projeto tem como objetivo facilitar o acesso e a integração com dados públicos do Brasil disponibilizados pela BrasilAPI, fornecendo um ponto de entrada simples e eficiente para consumir essas informações.

## 📌 Endpoints

O projeto disponibiliza os seguintes endpoints:

### 🔹 Endpoint 1: Recuperar informações de um CEP
Este endpoint permite recuperar informações detalhadas associadas a um CEP específico utilizando a BrasilAPI.

- **Método HTTP**: GET
- **URL**: `/api/v1/BrazilApi/cep/{cep}`

#### 📋 Comportamento:

1. **Parâmetros:**
   - `cep`: CEP (Código de Endereçamento Postal) válido a ser consultado.

2. **Respostas:**
   - **200 OK**: Retorna um objeto `CepModel` com detalhes do endereço correspondente ao CEP fornecido.
   - **400 Bad Request**: Se o CEP fornecido não for válido na base de dados da BrasilAPI.
   - **404 Not Found**: Se o CEP fornecido não for encontrado na base de dados da BrasilAPI.
   - **500 Internal Server Error**: Se ocorrer um erro ao comunicar com a BrasilAPI.

#### 📝 Exemplos de Uso:

- **Requisição:** GET /api/v1/BrazilApi/cep/12345678

- **Resposta (200 OK):**
```json
  {
    "cep": "12345678",
    "logradouro": "Rua Exemplo",
    "bairro": "Bairro Exemplo",
    "cidade": "Cidade Exemplo",
    "estado": "EX"
  }
```

### 🔹 Endpoint 2: Recuperar informações de todos os bancos
Este endpoint permite recuperar uma lista de todos os bancos disponíveis na BrasilAPI.

- **Método HTTP**: GET
- **URL**: `/api/v1/BrazilApi/banks`

#### 📋 Comportamento:

1. **Respostas:**
   - **200 OK**: Retorna uma lista de objetos `BankModel`, cada um representando um banco com suas informações detalhadas.
   - **500 Internal Server Error**: Se ocorrer um erro ao comunicar com a BrasilAPI.

#### 📝 Exemplos de Uso:

- **Requisição:** GET /api/v1/BrazilApi/banks

- **Resposta (200 OK):**
```json
  [
    {
      "bankCode": "001",
      "name": "Banco do Brasil S.A.",
      "fullName": "Banco do Brasil S.A.",
      "ispb": "00000000"
    },
    {
      "bankCode": "341",
      "name": "Itaú Unibanco S.A.",
      "fullName": "Itaú Unibanco Holding S.A.",
      "ispb": "60701190"
    }
    ...
  ]
```

### 🔹 Endpoint 3: Recuperar informações de um banco por código
Este endpoint permite recuperar informações detalhadas de um banco específico, utilizando o código do banco.

- **Método HTTP**: GET
- **URL**: `/api/v1/BrazilApi/banks/{bankCode}`

#### 📋 Parâmetros:

- `bankCode`: Código numérico único que identifica o banco a ser consultado.

#### 📋 Comportamento:

1. **Respostas:**
   - **200 OK**: Retorna um objeto `BankModel` com informações detalhadas do banco correspondente ao `bankCode` fornecido.
   - **404 Not Found**: Se o banco correspondente ao `bankCode` não for encontrado na base de dados da BrasilAPI.
   - **500 Internal Server Error**: Se ocorrer um erro ao comunicar com a BrasilAPI.

#### 📝 Exemplos de Uso:

- **Requisição:** GET /api/v1/BrazilApi/banks/001

- **Resposta (200 OK):**
```json
  {
    "bankCode": "001",
    "name": "Banco do Brasil S.A.",
    "fullName": "Banco do Brasil S.A.",
    "ispb": "00000000"
  }
```

## 🚀 Como usar

### ⚙️ Pré-requisitos

- .NET Core SDK (versão 6.0.0 ou superior)
- Editor de código (por exemplo, Visual Studio, Visual Studio Code)

### 🔧 Configuração

1. Clone este repositório:
```bash
git clone https://github.com/Vinicius-Rubia/Brazil.Api.Gateway.git
cd Brazil.Api.Gateway
```

2. Abra o projeto no seu editor de código.

### ▶️ Executando o projeto

1. No diretório raiz do projeto, execute:
```bash
dotnet run
```

2. Abra um navegador ou utilize uma ferramenta como Postman para acessar os endpoints descritos acima.
