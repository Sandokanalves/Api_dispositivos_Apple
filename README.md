# Documentação da API RESTful em .NET

Essa API foi requisitada pela empresa Overmind para avaliação Tecnica.
Foi estipulado um Tempo de 1H para completar o desafio e criar API.

## Visão Geral
Esta API RESTful foi desenvolvida em .NET e tem como objetivo consumir dados de uma API externa (<https://api.restful-api.dev/objects>), filtrando apenas os dispositivos da marca Apple e extraindo os campos `Name` e `Price`. Os dados extraídos são salvos em um arquivo CSS, cujo nome e caminho são definidos pelo usuário ao fazer a requisição para o endpoint da API.

## Tecnologias Utilizadas
- .NET Core 7.0
- C#
- HTTP Client para consumo da API externa

## Endpoints Disponíveis

### 1. Criar Arquivo CSS com os Dados dos Dispositivos Apple


 Filtra os dispositivos Apple, extrai os campos `Name` e `Price`, e gera um arquivo CSS no caminho especificado.
 Obs: no DispositivoController.cs Alterar no construtor o caminho onde será salvo no diretorio o arquivo CSV. 


## Considerações
- O usuário deve garantir que o caminho passado possui permissão de escrita.
- O nome do arquivo deve incluir a extensão `.css`.
- O consumo da API externa pode falhar caso ela esteja fora do ar ou tenha mudanças na estrutura de resposta.

Essa documentação cobre toda a funcionalidade da API e explica como modificar o caminho e nome do arquivo CSS na requisição.

