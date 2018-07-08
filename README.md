# Transire Loja Virtual


## Aparência
![whatsapp image 2018-07-08 at 00 11 52](https://user-images.githubusercontent.com/11354780/42416681-d685cce0-8243-11e8-8d02-689334e852ae.jpeg)

## Informações do Projeto

 - Projeto desenvolvido para fins avaliativos.
 - O Banco de dados é gerado automaticamente pelo EF utilizando CodeFirst 
 - Os inserts, updates e deletes são feitos através de stored procedures geradas pelo EF Mapping
 - Para realização do teste foram criadas 2 classes Categoria/Produto onde o relacionamento respectivamente é de 1 para N

## Tecnologias Utilizadas

- IIS 10.0
- SqlServer 2016 Express
- .NET Framework v4.6.1
- Entity Framework v6.2
- Bootstrap v4.1.1
- Jquery v3.3.1

## Instalação 
### Requisitos 
- IIS Server v10.0 (.NET Framework 4.5 ou Posterior Ativos)
- Sql Server 2016 ou Posterior
### Procedimento
1. No destino da aplicação acesse o arquivo  C:\\..\transire\Transire\Web.config
2. Altere a tag connection string com as informações do seu servidor, **SOURCE, ID e PASSWORD**
3. Abra o **Gerenciador de Serviços de Informação da Internet (IIS)** Adicione um novo Site 
4. Preencha as informações de **Nome** e selecione o **Pool de Aplicativo** para a **versão 4.5** ou posterior
5. Selecione o caminho fisico (Diretorio do arquivo Web.config)  C:\\..\transire\Transire\
6. Defina o endereço e porta a ser utilizado ex: localhost:8080
7. Inicie o serviço
8. Acesse o endereço via navegador ex: http://localhost:8080
