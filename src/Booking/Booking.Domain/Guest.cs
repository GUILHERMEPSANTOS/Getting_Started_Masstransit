namespace Booking.Domain;

public class Guest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool IsActive { get; set; }
}