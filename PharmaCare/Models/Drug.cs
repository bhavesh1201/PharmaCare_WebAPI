namespace PharmaCare.Models
{
    public class Drug
    {

        public int Id { get; set; } 
        public string DrugName { get; set; }

        public float price { get; set; }

        //public DateOnly ExpieryDate { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
