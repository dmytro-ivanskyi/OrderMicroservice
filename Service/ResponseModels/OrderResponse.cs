using Data.Models;

namespace Service.ResponseModels
{
    public class OrderResponse
    {
        public int Id { get; set; }

        public JobType JobType { get; set; }

        public string Notes { get; set; }
    }
}
