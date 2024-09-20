var builder = WebApplication.CreateBuilder(args);
    builder.AddCorsBuilder4();
    builder.AddConfiguration();
    builder.AddSwaggerGenBuilder3();
    builder.AddConnectionDB();
    builder.AddServicesBuilder();
    builder.AddAuthenticationBuilder1();
    builder.AddIdentityDBBuilder2();

var app = builder.Build();
    app.UseApp();
