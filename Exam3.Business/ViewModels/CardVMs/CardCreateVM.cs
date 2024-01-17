using Microsoft.AspNetCore.Http;

namespace Exam3.Business.ViewModels.CardVMs
{
    public class CardCreateVM
    {
        public string Title { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Description { get; set; }
    }
}
