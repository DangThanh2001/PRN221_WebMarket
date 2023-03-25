using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepositotry
{
    public interface ICardRepository
    {
        public List<Card> GetAllCard();
        public Card GetCardWithUserId(int id);
        public string AddCard(Card card);
        public void UpdateCard(Card card);
        public void DeleteCard(int id);
    }

}
