using Data.Models;

namespace Service.RequestModels
{
    public class UpdateOrder
    {
        public JobType JobType { get; set; }

        public string Notes { get; set; }
    }
}
