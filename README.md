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
```bash

## Docker

Este projeto utiliza o Docker para orquestrar os containers do backend, frontend e banco de dados SQL Server. Para rodar a aplicação em containers, siga os passos abaixo.

### 1. Construindo os containers com `docker-compose`

Navegue até a pasta do projeto e execute o seguinte comando para subir os containers:

```bash
docker-compose up -d