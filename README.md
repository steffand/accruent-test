# Projeto Accruent Test

Este projeto consiste em um sistema para cadastro de movimentações, utilizando tecnologias como Angular para o frontend, .NET para o backend e SQL Server como banco de dados. A infraestrutura é gerenciada com Docker, utilizando `docker-compose` para orquestrar os containers.

## Tecnologias Utilizadas

- **Frontend**: Angular
- **Backend**: .NET (ASP.NET Core)
- **Banco de Dados**: SQL Server
- **Testes E2E**: Cypress
- **Docker**: Para orquestração de containers

## Requisitos

Certifique-se de ter as seguintes ferramentas instaladas:

- [Docker](https://www.docker.com/products/docker-desktop)
- [Node.js](https://nodejs.org/en/) (Versão 18 ou superior)
- [Angular CLI](https://angular.io/cli)
- [Cypress](https://www.cypress.io/)

## Como Rodar o Projeto

### 1. Clonando o repositório

Clone este repositório em sua máquina local:

```bash
git clone https://github.com/seu-usuario/accruent-test.git
cd accruent-test
```

## Docker

Este projeto utiliza o Docker para orquestrar os containers do backend, frontend e banco de dados SQL Server. Para rodar a aplicação em containers, siga os passos abaixo.

### 1. Construindo os containers com `docker-compose`

Navegue até a pasta do projeto e execute o seguinte comando para subir os containers:

```bash
docker-compose up -d
```

### Acessando a aplicação

Após os containers estarem rodando, você pode acessar os seguintes serviços:

- **Frontend**: 
  Acesse a aplicação frontend através do seguinte link:
  - [http://localhost:4200](http://localhost:4200)

- **Backend (Swagger)**: 
  O backend está configurado para exibir a interface Swagger na seguinte URL:
  - [http://localhost:7283/swagger/index.html](http://localhost:7283/swagger/index.html)

Estas URLs permitem que você interaja com a aplicação frontend e backend diretamente no seu navegador.

### Rodando os Testes com o Cypress

Para realizar os testes automatizados utilizando o Cypress, siga os seguintes passos:

1. **Instalar Dependências do Cypress**:
   
   Caso ainda não tenha instalado o Cypress no seu projeto, instale-o com o comando:

   ```bash
   npm install cypress --save-dev
   ```
 2. **Abrir o Cypress**:

   Após a instalação, abra o Cypress com o comando `npx cypress open`. Isso abrirá a interface gráfica do Cypress onde você pode visualizar e rodar os testes.

3. **Rodar os Testes**:

   Caso queira rodar os testes diretamente no terminal, use o comando `npx cypress run`. Isso executará os testes no modo headless, ou seja, sem abrir a interface gráfica do Cypress.

4. **Verificar Resultados**:

   Os resultados dos testes serão exibidos no terminal ou na interface gráfica, dependendo do modo que você escolher rodar os testes.

Com isso, você pode testar a aplicação de forma automatizada, garantindo que os fluxos estejam funcionando corretamente.
