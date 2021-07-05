namespace ModelVitae.Data.Models
{
    public class Customer : PersonalData
    {
        public int Id { get; set; }

        public byte[] Logo { get; set; }

        public string Kvk { get; set; }

        public string Btw { get; set; }
    }
}