# Prova Grupo LTM - Vinícius Alexandre Saraiva Silva

Este projeto foi desenvolvido em uma arquitetura focada em DDD, tentei fazer um básico para mostrar o conhecimento.

## Development server

Coloque o projeto LTM.Barramento como start project, o cadastro de produtos vai ser populado automaticamente no MongoDB(lembre-se de deixar o servidor do mongodb ligado).

Um Usuário vai ser criado automaticamente no seed do contexto do SQL Server.

Deixei está arquitetura hibrida em banco de dados somente para mostrar um pouco do conhecimento.

## Documentação API Swagger

http://localhost:49468/swagger/ui/index

Aqui você encontra os serviços desenvolvidos, bem básico.




## O que foi desenvolvido

1 - Criado uma Api rest
2 - Implemente o padrão oauth para geração e validação de token de acesso, bem básico sem refresh token, somente para atender a solicitação.
3- Criado uma rota de listagem de produtos, que só deve retorna a lista de produtos se
receber um token válido.
4-  Criar um seed para criação de um usuário no SQL Server e criação dos produtos no MONGODB.

Injeção de Dependência com SimpleInjector.
AutoMapper na Conversão de Entidade X Model.
Web API como serviço
S.O.L.I.D.



##Ajuda adicional

Importante, inicie o projeto de backend antes de iniciar o front.

