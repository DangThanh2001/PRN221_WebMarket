using DataAccess.IRepositotry;
using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly DbContextBase _dbContext;
        public CardRepository(DbContextBase dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Card> GetAllCard()
        {
            return _dbContext.Cards.ToList();
        }
        public Card GetCardWithUserId(int id)
        {
            return _dbContext.Cards.Where(x => x.UserID == id).FirstOrDefault();
        }
        public string AddCard(Card card)
        {
            try
            {
                _dbContext.Cards.Add(card);
                _dbContext.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                return "False";
            }
        }
        public string UpdateCard(Card card)
        {
            try
            {
                _dbContext.Cards.Update(card);
                _dbContext.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                return "False";
            }
            
        }
        public void DeleteCard(int id)
        {

        }
    }
}
