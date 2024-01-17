using Exam3.Core.Models.Common;

namespace Exam3.Core.Models
{
    public class Card : BaseModel
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
