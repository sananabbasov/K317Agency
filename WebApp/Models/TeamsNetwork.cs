using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class TeamsNetwork : Base
    {
        public string UserUrl { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int SocialNetworkId { get; set; }
        public SocialNetwork SocialNetwork { get; set; }
    }
}
