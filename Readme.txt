Desafio da Perlink

Inicio dos trabalhos 11/02/2020
Entrega 13/02/2020

A solução proposta está estruturada com a separação de camadas entre:
Web --> Servicos
Servicos --> Data

Iniciar o banco de dados:
- carregue a solução no Visual studio 2019 e aguarde até que os componentes sejam carregados
- na janela do "Package Manager Console" execute o comando "Update-Database"
para criar a base de dados (não esqueça de configurar a conexão no MySql workbench)
Usuario : "sa"
senha : "sa"

lembrando que é necessário levantar o sistema pelo menos uma vez para que o Seed pré Cadastre
alguns dados de exemplo.

Iniciando a solução:
navegue até a pasta "src\Perlink.Web\bin\Debug\netcoreapp2.2"
faça o comando : dotnet Perlink.Web.dll
ou simplesmente utilizar o arquivos batch "build.cmd"
em poucos segundos o servidor ficará disponivel podendo ser acessado em: localhost:5000

use o postman para enviar dados json para a Api como mostra o exemplo abaixo:
Endereço: http://localhost:5000/api/Main

{
    "NumeroDoProcesso": "001002003",
    "dataDeCriacaoDoProcesso": "2019-01-01",
    "valor": "55",
    "escritorioId": "2"
}

é possivel observar a atualização dos dados na aba de Relatórios.
pois a tela faz um refresh a cada 10 segundos.
