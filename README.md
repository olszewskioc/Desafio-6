# Sistema de Farmácia - Windows Forms

## IMPORTANTE: ALTERAR PASSWORD NO APPSETTINGS.JSON

## Tipos de Commits

### `feat` - Nova funcionalidade
```bash
git commit -m "feat: adicionar botão de cadastro"
```

### `fix` - Correção de bug
```bash
git commit -m "fix: corrigir erro ao salvar usuário sem email"
```

### `refactor` - Refatoração de código
```bash
git commit -m "refactor: melhorar organização da classe"
```

### `style` - Alteração de estilo
```bash
git commit -m "style: remover espaços em branco"
```

## Descrição

O **Sistema de Farmácia** é uma aplicação desktop desenvolvida utilizando o **Windows Forms** com **.NET 8.0**. O sistema permite a gestão de estoque de medicamentos, controle de vendas e cadastros de clientes e fornecedores. A aplicação é baseada no padrão **MVC (Model-View-Controller)** e utiliza o **Entity Framework** para comunicação com um banco de dados **PostgreSQL**.

## Funcionalidades

- **Controle de Estoque**: Gerenciamento de medicamentos e quantidades disponíveis.
- **Vendas**: Realização de vendas, com registro de produtos vendidos e controle de estoque.
- **Cadastro de Clientes e Fornecedores**: Gerenciamento de informações de clientes e fornecedores.
- **Relatórios**: Geração de relatórios de vendas, estoque e outros dados relevantes.

## Tecnologias

- **Frontend**: Windows Forms (.NET 8.0)
- **Backend**: .NET 8.0 com Entity Framework
- **Banco de Dados**: PostgreSQL
- **ORM**: Entity Framework Core
- **Padrão de Arquitetura**: MVC (Model-View-Controller)

## Pré-requisitos

- [**.NET 8.0 SDK**](https://dotnet.microsoft.com/download/dotnet/8.0)
- [**PostgreSQL**](https://www.postgresql.org/download/)

## Instalação

### 1. Configuração do Banco de Dados

Crie um banco de dados no PostgreSQL e configure a string de conexão no arquivo appsettings.json:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=nome_do_banco;Username=usuario;Password=senha"
  }
}
```

### 2. Instalar as dependências

No terminal, dentro da pasta do projeto, execute:

```bash
dotnet restore
```

### 3. Criar o banco de dados

A partir do terminal, execute os comandos para criar e migrar o banco de dados:

```bash
dotnet ef database update
```

### Execução

Para rodar o sistema, utilize o comando:

```bash
dotnet run
```

A aplicação será iniciada e estará disponível como uma aplicação de desktop utilizando o Windows Forms.

### Estrutura do Projeto
A estrutura do projeto é organizada conforme o padrão MVC:

* **Models**: Contém as entidades do banco de dados, como Medicamento, Venda, Cliente, etc.
* **Views**: Contém as telas do sistema, como a interface de cadastro de medicamentos, vendas e relatórios.
* **Controllers**: Contém a lógica de controle das funcionalidades, como a manipulação de dados, validações e interações com o banco de dados.

### Contribuições
Se você deseja contribuir para o projeto, siga os passos abaixo:

1. Faça o fork do repositório.
2. Crie uma branch para a sua feature (git checkout -b feature/nome-da-feature).
3. Commit suas alterações (git commit -am 'Adicionando nova feature').
4. Envie para a branch principal (git push origin feature/nome-da-feature).
5. Crie um pull request para que possamos revisar suas alterações.

### Responsáveis

<div style="display: flex; gap: 10px;">
  <a href="https://github.com/Pedrozo0901">
    <img src="https://github.com/Pedrozo0901.png" alt="Felipe Pedrozo" style="border-radius: 50%; width: 60px; height: 60px; margin: 10%">
  </a>
  <a href="https://github.com/Holiveira090">
    <img src="https://github.com/Holiveira090.png" alt="Henrique Oliveira" style="border-radius: 50%; width: 60px; height: 60px; margin: 10%">
  </a>
  <a href="https://github.com/joselucas0">
    <img src="https://github.com/joselucas0.png" alt="José Lucas" style="border-radius: 50%; width: 60px; height: 60px; margin: 10%">
  </a>
  <a href="https://github.com/Leandro-Oli2">
    <img src="https://github.com/Leandro-Oli2.png" alt="Leandro Oliveira" style="border-radius: 50%; width: 60px; height: 60px; margin: 10%">
  </a>
  <a href="https://github.com/RhyanSKomm">
    <img src="https://github.com/RhyanSKomm.png" alt="Rhyan" style="border-radius: 50%; width: 60px; height: 60px; margin: 10%">
  </a>
  <a href="https://github.com/olszewskioc">
    <img src="https://github.com/olszewskioc.png" alt="Thiago Olszewski" style="border-radius: 50%; width: 60px; height: 60px; margin: 10%">
  </a>
  <a href="https://github.com/ValberOIiveira">
    <img src="https://github.com/ValberOIiveira.png" alt="Valber Oliveira" style="border-radius: 50%; width: 60px; height: 60px; margin: 10%">
  </a>
</div>
