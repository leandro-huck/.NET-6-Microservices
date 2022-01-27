using System.ComponentModel.DataAnnotations;

namespace CommandService.Models
{
    public class Command
    {
        public Command()
        {
            HowTo = "";
            CommandLine = "";
            Platform = new Platform();
        }
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string CommandLine { get; set; }
        [Required]
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}