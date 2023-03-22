﻿using DataAccess.IRepositotry;
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
        public void AddCard(Card card)
        {

        }
        public void UpdateCard(Card card)
        {

        }
        public void DeleteCard(int id)
        {

        }
    }
}