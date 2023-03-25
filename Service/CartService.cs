using DataAccess.IRepositotry;
using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CartService
    {
        private readonly ICardRepository _cardRepository;
        public CartService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public string AddToCart(Card card)
        {
           return _cardRepository.AddCard(card);
        }
        public string Update(Card card)
        {
            return _cardRepository.UpdateCard(card);
        }
        public Card GetCard(int id)
        {
            return _cardRepository.GetCardWithUserId(id);
        }
    }
}
