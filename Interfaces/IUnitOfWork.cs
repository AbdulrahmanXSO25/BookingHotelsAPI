namespace BookingHotelsAPI.Interfaces
{
    public interface IUnitOfWork
    {
        IHotelRepository HotelRepository { get; }
        IBookingRepository BookingRepository { get; }
        void SaveChanges();
    }
}
