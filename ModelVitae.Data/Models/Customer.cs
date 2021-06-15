namespace ModelVitae.Data.Models
{
    public class Customer
    {​​​​​​​
        public int Id {​​​​​​​ get; set; }​​​​​​​

        public PersonalData PersonalData {​​​​​​​ get; set; }​​​​​​​

        public byte[] Logo { get; set; }

        public string Kvk { get; set; }

        public string Btw { get; set; }
    }​​​​​​​
}
