﻿using System;
using System.Collections.Generic;
using System.Text;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private List<ICocktail> models;

        public CocktailRepository()
        {
            models = new List<ICocktail>();
        }
        public IReadOnlyCollection<ICocktail> Models => models.AsReadOnly();
        public void AddModel(ICocktail model)
        {
            models.Add(model);
        }
    }
}
