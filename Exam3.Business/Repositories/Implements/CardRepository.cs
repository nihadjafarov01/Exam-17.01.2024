using Exam3.Business.Profiles;
using Exam3.Business.Repositories.Interfaces;
using Exam3.Business.ViewModels.CardVMs;
using Exam3.Core.Models;
using Exam3.DAL.Contexts;

namespace Exam3.Business.Repositories.Implements
{
    public class CardRepository : GenericRepository<Card>, ICardRepository
    {
        public CardRepository(Exam3DbContext context) : base(context)
        {
        }
    }
}
