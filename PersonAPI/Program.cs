
using Microsoft.OpenApi.Models;
using PersonAPI.Models;
using PersonAPI.Repositories;

namespace PersonAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(swaggerGenOptions =>
            {
                swaggerGenOptions.SwaggerDoc(name: "v1", info: new OpenApiInfo { Title = "Persons and their interests", Version = "v1" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSwaggerUI(swaggerUiOptions =>
            {
                swaggerUiOptions.DocumentTitle = "Learning minimal API";
                swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", name: "Api that gives you a possibility to learn.");
                swaggerUiOptions.RoutePrefix = string.Empty;

            });

            app.UseHttpsRedirection();

            app.UseAuthorization();
            // Person endpoint
            app.MapGet(pattern: "/get-all-person", async () => await PersonRepositories.GetPeopleAsync())
            .WithTags("Person Endpoint");

            app.MapGet(pattern: "/get-person-by-id/{personId}", handler: async (int personId) =>
            {
                Person person = await PersonRepositories.GetPeopleByIdAsync(personId);
                if (person != null)
                {
                    return Results.Ok(person);
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Person Endpoint");


            app.MapPost(pattern: "/create-person", handler: async (Person personToCreate) =>
            {
                bool createSuccess = await PersonRepositories.CreatePeopleAsync(personToCreate);
                if (createSuccess)
                {
                    return Results.Ok("Person created successfully");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Person Endpoint");

            app.MapPut(pattern: "/update-person", handler: async (Person personToUpdate) =>
            {
                bool updateSuccessful = await PersonRepositories.UpdatePeopleAsync(personToUpdate);
                if (updateSuccessful)
                {
                    return Results.Ok(value: "Updating an person was successful");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Person Endpoint");

            app.MapDelete(pattern: "/delete-person-by-id/{personId}", handler: async (int personId) =>
            {
                bool deleteSuccessful = await PersonRepositories.DeletePeopleAsync(personId);
                if (deleteSuccessful)
                {
                    return Results.Ok(value: "Deleting an person was successful");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Person Endpoint");

            //Interest endpoint
            app.MapGet("/get-all-interest", async () => await InterestRepositories.GetInterestAsync())
            .WithTags("Interest Endpoint");

            app.MapGet("/get-interest-by-id/{interestId}", handler: async (int interestId) =>
            {
                Interest interest = await InterestRepositories.GetInterestByIdAsync(interestId);
                if (interest != null)
                {
                    return Results.Ok(interest);
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Interest Endpoint");

            app.MapPost("/create-interest", handler: async (Interest interestToCreate) =>
            {
                bool createSuccess = await InterestRepositories.CreateInterestAsync(interestToCreate);
                if (createSuccess)
                {
                    return Results.Ok("Interest created successfully");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Interest Endpoint");

            app.MapPut(pattern: "/update-interest", handler: async (Interest interestToUpdate) =>
            {
                bool updateSuccessful = await InterestRepositories.UpdateInterestAsync(interestToUpdate);
                if (updateSuccessful)
                {
                    return Results.Ok(value: "Updating an interest was successful");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Interest Endpoint");

            app.MapDelete(pattern: "/delete-interest-by-id/{interestId}", handler: async (int interestId) =>
            {
                bool deleteSuccessful = await InterestRepositories.DeleteInterestAsync(interestId);
                if (deleteSuccessful)
                {
                    return Results.Ok(value: "Deleting an interest was successful");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Interest Endpoint");

            //Link start
            app.MapPost(pattern: "/create-link", handler: async (Link linkToCreate) =>
            {
                bool createSuccess = await LinkRepositories.CreateLinkAsync(linkToCreate);
                if (createSuccess)
                {
                    return Results.Ok("Link created successfully");
                }
                else
                {
                    return Results.BadRequest();
                }
            }).WithTags("Link Endpoint");

            app.Run();
        }
    }
}