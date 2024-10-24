namespace ScrumBackEnd.Dto
{
    public class CreateCampaign
    {
        public string Name { get; set; }
        public string University { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}
