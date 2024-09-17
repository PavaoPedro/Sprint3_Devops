# Sprint3_Devops



Exemplo de CRUD com um requisição JSON:

POST /empresas HTTP/1.1
Host:(https://mai-webapp.azurewebsites.net/Empresa)
Content-Type: application/json

{
  "CNPJ": "98765432109876",
  "Email": "novaempresa@MAI.com",
  "IdLogin": 5,
  "IdRegiao": 1,
  "LoginIdLogin": 5,
  "Nome": "MAI LTDA",
  "RegiaoIdRegiao": 1
}
