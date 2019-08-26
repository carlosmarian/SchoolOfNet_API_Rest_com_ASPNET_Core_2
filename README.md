# SchoolOfNet_API_Rest_com_ASPNET_Core_2
Projeto usado no curso API Rest com ASP.NET Core - Parte 2

Este projeto é continuação do projeto do curso "Projeto usado no curso API Rest com ASP.NET Core - Parte 1".

Lembrando de:

    * subir o docker do banco:
        ` docker-compose up`
    * criar o database:
        `CREATE DATABASE apirest /*!40100 COLLATE 'latin1_general_cs' */;`
    * e executar as migra��es:
        `dotnet ef database update`


Documenta��o da API com SWAGGER.

No nuget.org pesquisar por `Swashbuckle.AspNetCore`, est� � a bliblioca que ser� usada no projeto para auxiliar na documenta��o com SWAGGER.

Comando:
``dotnet add package Swashbuckle.AspNetCore --version 5.0.0-rc2``


Ap�s efetuar a instala��o, deve ser configuurado o servi�o para o SWAGGER esteja dispon�vel/injetado em cada controller.

Para isso vamos alterar a classe Startup.cs no m�todo ConfigureServices:
```C#
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")) );
    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    //SWAGGER
    //Mapear os controllers.
    services.AddSwaggerGen(config => {
        //ATEN��O, o primeiro parametro temq ue ser com v min�sculo, sen�o dar erro.
        //config.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo {Title= "API de Produtos . ", Version= "V1"});
        config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {Title="API DE PRODUTOS",Version = "v1"});
    });
}
```

Tbm deve ser ajustado o m�todo Configure:
```C#
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    app.UseHttpsRedirection();

    app.UseMvc();

    //Informar ao AP.NEt que queremos usar o SWAGGER no projeto.
    app.UseSwagger(config =>{
        //Alterar o local onde o arquivo ser� gerado.
        //"documentName" representa a vers�o
        config.RouteTemplate = "documentacao/{documentName}/swagger.json";
    });/*Este metodo gera um arquivo JSON(swagger.json)*/
    //Cria a saida html
    app.UseSwaggerUI(config =>{
        //Vai gerar o HTML com base no json padr�o do SWagger
        config.SwaggerEndpoint("/documentacao/v1/swagger.json", "My API V1");
        //Para deixar o swagger na rota padr�o.
        config.RoutePrefix = string.Empty;
    });
}
```

O pr�ximo curso ser�:
https://www.schoolofnet.com/curso/aspnet/dotnet-core/api-rest-com-asp-net-core-hateoas/
