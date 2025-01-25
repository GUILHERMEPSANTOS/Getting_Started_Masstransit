using Booking.Api.Contracts;
using Booking.Api.Extensions;
using Booking.Application.Accommodation.BookAccommodation;
using Booking.Application.Accommodation.CreateAccommodation;
using Booking.Infrastructure;
using Booking.Common.Infrastructure;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration["ConnectionStrings:Mongo"]!);
builder.Services.AddCommonInfrastructure(null);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("accommodation/booking", async (BookAccommodationRequest request, IMediator mediator) =>
    {
        var bookAccommoationCommand = new BookAccommodationCommand()
        {
            AccommodationId = request.AccommodationId,
            CheckIn = request.CheckIn,
            CheckOut = request.CheckOut,
            GuestId = request.GuestId,
            HostId = request.HostId,
            NumberOfAdults = request.NumberOfAdults,
            NumberOfChildren = request.NumberOfChildren,
            NumberOfInfants = request.NumberOfInfants,
            NumberOfPets = request.NumberOfPets,
        };

        await mediator.Send(bookAccommoationCommand);
    })
    .WithName("BookAccommodation")
    .WithOpenApi();


app.MapPost("accommodation", async (CreateAccommodationRequest request, IMediator mediator) =>
    {
        var createAccommoationCommand = new CreateAccommodationCommand
        {
            HostId = request.HostId,
            ZipCode = request.ZipCode,
            City = request.City, Complement = request.Complement,
            Country = request.Country,
            Name = request.Name,    
            Neighborhood = request.Neighborhood,
            Number = request.Number,
            State = request.State,
            Street = request.Street,
        };

        await mediator.Send(createAccommoationCommand);
    })
    .WithName("CreateAccommodation")
    .WithOpenApi();

app.Run();