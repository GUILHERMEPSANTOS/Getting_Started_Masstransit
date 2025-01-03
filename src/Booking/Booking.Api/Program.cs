using Booking.Api.Contracts;
using Booking.Application.Accommodation.BookAccommodation;
using Booking.Infrastructure;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssemblies(Booking.Application.AssemblyReference.Assembly);
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration["ConnectionStrings:Mongo"]!);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/accommodation/booking", async (BookAccommodationRequest request, IMediator mediator) =>
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

app.Run();