using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;

namespace Exam3.Business.Helpers
{
    public static class SaveImage
    {
        public static string SaveAndProvideNameAsync(this IFormFile file, IWebHostEnvironment env)
        {
            string filePath = Path.Combine("images", "cards", file.FileName);
            using (FileStream fs = System.IO.File.Create(Path.Combine(env.WebRootPath, filePath)))
            {
                file.CopyTo(fs);
            }
            return filePath;
        }
    }
}
