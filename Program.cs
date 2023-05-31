var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var config = builder.Configuration;

services.AddApplicationServices(config);
services.AddSwaggerDocumentation(config);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var scopedServices = scope.ServiceProvider;

    try
    {
        var dbContext = scopedServices.GetRequiredService<AppDbContext>();

        // Migrate the database
        await dbContext.Database.MigrateAsync();

        // Seed the database
        await dbContext.SeedDbContextAsync();
    }
    catch (Exception ex)
    {
        // Handle any exceptions during seeding
        Console.WriteLine("An error occurred while seeding the database.");
        Console.WriteLine(ex.Message);
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();