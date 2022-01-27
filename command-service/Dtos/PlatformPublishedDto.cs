namespace CommandService.Dtos
{
    public class PlatformPublishedDto
    {
        public PlatformPublishedDto()
        {
            Name = "";
            Event = "";
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Event { get; set; }
    }
}