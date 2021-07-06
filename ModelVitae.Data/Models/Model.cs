using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelVitae.Data.Models
{
    public class Model : PersonalData
    {
        public int Id { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public double Waist { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
        
        public string ImageName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAdress { get; set; }

        public EyeColor EyeColor { get; set; }

        public string HairColor { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public enum EyeColor
    {
        Amber,
        Blue,
        Brown,
        Gray,
        Green,
        Hazel,
        Heterochromatic,
        Other
    }
}