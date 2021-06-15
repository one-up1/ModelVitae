namespace ModelVitae.Data.Models
{
    public class PersonalData
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
    }

    public enum Gender
    {​​​​​​​
        Male,
        Female,
        Other
    }​​​​​​​

    public enum EyeColor
    {​​​​​​​
        Amber,
        Blue,
        Brown,
        Gray,
        Green,
        Hazel,
        Heterochromatic,
        Other
    }​​​​​​​
}
