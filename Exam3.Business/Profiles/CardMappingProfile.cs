using AutoMapper;
using Exam3.Business.ViewModels.CardVMs;
using Exam3.Core.Models;

namespace Exam3.Business.Profiles
{
    public class CardMappingProfile : Profile
    {
        public CardMappingProfile()
        {
            CreateMap<Card, CardListItemVM>().ReverseMap();
            CreateMap<Card, CardUpdateVM>().ReverseMap();
            CreateMap<Card, CardCreateVM>().ReverseMap();
            CreateMap<CardUpdateVM, Card>().ReverseMap();
        }
    }
}
