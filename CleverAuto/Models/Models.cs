namespace CleverAuto.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Car> Cars { get; set; } = new();
    }

    public class Car
    {
        public int Id { get; set; }
        public string VIN { get; set; } = string.Empty;
        public string Make { get; set; } =string.Empty;
        public string Model { get; set; } = string.Empty;
        public int YearOfFirstUse {  get; set; }
        public UseOfCarPerDay UseOfCarPerDay { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public int CurrentMileage { get; set; }
        public int CustomerId { get; set; }
        public List<Service> Services { get; set; } =new List<Service>();
    }

    public enum UseOfCarPerDay
    {
        NORMAL=100,
        MEDIUM=200,
        INTENCE=300
    }

    public class Service
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;// E.g., Oil Change, Maintenance, etc.
        public DateTime DateOfService { get; set; }
        public int MileageAtService { get; set; }
        public int EstimatedNextServiceMileage { get; set; }
        public int CarId { get; set; }
        public bool ReminderSent { get; set; } = false;

    }

    public class ServiceList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
        public TypeDeService TypeDeService { get; set; }
    }

    public enum  TypeDeService
    {
        Suspension,
        Lubrification,
        Filtration,
        Frein,
        Refroidissement,
        Distribution,
        Electrecite,


    }

}
