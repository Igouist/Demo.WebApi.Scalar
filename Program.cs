using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    // 將註解的 XML 檔案加入 Swagger，記得先打開專案屬性的 XML 文件產生選項
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Demo.WebApi.Scalar.xml"));
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    // 記得先安裝 NuGet 套件 Scalar.AspNetCore
    // Scalar 頁面 => http://localhost:port/scalar/v1
    app.MapScalarApiReference(options =>
    {
        // 讓 Scalar 去抓 Swagger 產生的 JSON 檔，直接取得 API 資訊和註解
        options.OpenApiRoutePattern = "/swagger/v1/swagger.json";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();