
﻿using DataAccess;
using DataAccess.IRepositotry;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ObjectModel;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CategoryService
    {
        private ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public List<Category> GetAllCategory()
        {
            return _repository.GetAllCategory();
        }

        public Category GetCategoryWithId(int id)
        {
            return _repository.GetCategoryWithId(id);
        }

        public void AddCategory(Category category)
        {
            _repository.AddCategory(category);
        }

        public void UpdateCategory(Category category)
        {
            _repository.UpdateCategory(category);
        }

        public void DeleteCategory(int id)
        {
            _repository.DeleteCategory(id);
        }

    }
}
