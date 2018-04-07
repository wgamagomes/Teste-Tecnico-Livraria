Teste Técnico (Livraria)
======================

Teste técnico realizado para HBSIS - https://hbsis.com.br/

### Esta solução contempla:
1. Solução desenvolvida na plataforma .NET
2. Web API
3. Domain-driven design (DDD)
4. ORM Entity Framework
5. Framework de frontend (JQuery e Bootstrap)
6. Injeção de dependência (Simple injector)
7. Inversão de controle (IoC) que abstrai as camadas com injeção de dependência 
8. Aplicação separada em camadas
9. Entidades de Domínio
10. Classes de Serviço
11. Contratos (Interfaces)
12. Repositório Genérico
13. Repositório Especializado
14. Contexto Entity Framework
15. Migrations
16. Configuração das convenções Entity Framework
17. Sobrescrita do método SaveChanges para persistência de dados

### Utilização

1. Faça o download ou o clone do projeto  
2. Faça a edição da conexão com banco no arquivo Web.config que encontra-se no projeto Livraria.Web.API
3. No Package Manager Console selecione projeto padrão Livraria.DataAccess e execute o comando Update-Database
4. Mantenha-se conectado a internet pois algumas referências não estão locais por exemplo:
src="https://cdn.datatables.net/1.10.16/js/jquery.dataTables.js"

### Scripts para consumo da Web API
1. Index.html localizado na raiz do projeto Livraria.Web.API
2. consulta.js, edicao.js, envio.js, notificacao.js, principal.js e relatorio.js localizados no subdiretótio js/aplicacao/
do projeto Livraria.Web.API
3. _formConsulta.html, _formEdicao.html e _formularioCadastro.html localizados no subdiretótio partial/
do projeto Livraria.Web.API



