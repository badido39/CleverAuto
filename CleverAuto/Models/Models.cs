using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CleverAuto.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }=string.Empty;
        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
        [JsonPropertyName("cars")]
        public List<Car> Cars { get; set; } = new();
    }

    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("vin")]
        public string VIN { get; set; } = string.Empty;
        [JsonPropertyName("make")]
        public string Make { get; set; } =string.Empty;
        [JsonPropertyName("model")]
        public string Model { get; set; } = string.Empty;
        [JsonPropertyName("yearoffirstuse")]
        public int YearOfFirstUse {  get; set; }
        [JsonPropertyName("useofcarperday")]
        public UseOfCarPerDay UseOfCarPerDay { get; set; }
        [JsonPropertyName("platenumber")]
        public string PlateNumber { get; set; } = string.Empty;
        [JsonPropertyName("currentmileage")]
        public int CurrentMileage { get; set; }
        [JsonPropertyName("customerid")]
        public int CustomerId { get; set; }
        [JsonPropertyName("services")]
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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;// E.g., Oil Change, Maintenance, etc.
        [JsonPropertyName("dateofservice")]
        public DateTime DateOfService { get; set; }
        [JsonPropertyName("mileageatservice")]
        public int MileageAtService { get; set; }
        [JsonPropertyName("estimatednextservicemileage")]
        public int EstimatedNextServiceMileage { get; set; }
        [JsonPropertyName("carid")]
        public int CarId { get; set; }
        [JsonPropertyName("remindersent")]
        public bool ReminderSent { get; set; } = false;

    }

    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; } = string.Empty;

        [JsonPropertyName("costprice")]
        public decimal CostPrice { get; set; }= decimal.MaxValue;
        [JsonPropertyName("sellprice")]
        public decimal SellPrice { get; set; }=decimal.MaxValue;
    }
  
   

}
