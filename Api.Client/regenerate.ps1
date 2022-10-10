dotnet openapi remove Api.json

dotnet openapi add url http://localhost:5209/swagger/v1/swagger.json --output-file Api.json -c NSwagCSharp

