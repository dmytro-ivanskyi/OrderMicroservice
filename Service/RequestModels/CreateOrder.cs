using Data.Models;

namespace Service.RequestModels
{
    public class CreateOrder
    {
        public JobType JobType { get; set; }

        public string Notes { get; set; }
    }
}
