using Exam3.Business.ViewModels.CardVMs;

namespace Exam3.Business.Services.Interfaces
{
    public interface ICardService
    {
        public IEnumerable<CardListItemVM> GetAll();
        public void Create(CardCreateVM vm);
        public void Update(int id, CardUpdateVM vm);
        public CardUpdateVM Update(int id);
        public void Delete(int id);

    }
}
