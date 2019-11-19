namespace SO.DataAccess.Entities.ManyToMany
{
    public class UserApartment
    {
        public int UserId { get; set; }

        public int ApartmentId { get; set; }

        public User User { get; set; }

        public Apartment Apartment { get; set; }
    }
}