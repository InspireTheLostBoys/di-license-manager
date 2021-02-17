namespace Models.System.DTO
{
    public class SiteDTO
    {
        public int ID { get; set; }

        public string SiteName { get; set; }

        public int CustomerID { get; set; }

        public CustomerDTO Customer { get; set; }

    }
}
