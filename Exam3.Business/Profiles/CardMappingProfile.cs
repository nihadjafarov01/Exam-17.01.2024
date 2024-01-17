using AutoMapper;
using Exam3.Business.Helpers;
using Exam3.Business.ViewModels.CardVMs;
using Exam3.Core.Models;
using Microsoft.AspNetCore.Hosting;

namespace Exam3.Business.Profiles
{
    public class CardMappingProfile : Profile
    {
        public CardMappingProfile(IWebHostEnvironment env)
        {
            CreateMap<Card, CardListItemVM>();
            CreateMap<Card, CardUpdateVM>();
            CreateMap<Card, CardCreateVM>();

            CreateMap<CardCreateVM, Card>()
                .ForMember(c => c.ImageUrl, opt => opt.Ignore())
                .AfterMap(async (src, dest) =>
                {
                    if (src.ImageFile != null)
                        dest.ImageUrl = src.ImageFile.SaveAndProvideNameAsync(env);
                });
            CreateMap<CardUpdateVM, Card>()
                .ForMember(c => c.ImageUrl, opt => opt.Ignore())
                .AfterMap(async (src, dest) =>
                {
                    if (src.ImageFile != null)
                        dest.ImageUrl = src.ImageFile.SaveAndProvideNameAsync(env);
                });
        }
    }
}
