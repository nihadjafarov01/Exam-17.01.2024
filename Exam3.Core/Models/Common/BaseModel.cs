namespace Exam3.Core.Models.Common
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
