﻿using System;
using System.Collections.Generic;
using System.Text;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private List<IDelicacy> models;

        public DelicacyRepository()
        {
            models = new List<IDelicacy>();
        }
        public IReadOnlyCollection<IDelicacy> Models => models.AsReadOnly();
        public void AddModel(IDelicacy model)
        {
            models.Add(model);
        }
    }
}
