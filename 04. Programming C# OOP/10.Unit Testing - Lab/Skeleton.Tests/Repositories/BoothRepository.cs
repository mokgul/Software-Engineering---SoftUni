using System;
using System.Collections.Generic;
using System.Text;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        private List<IBooth> models;

        public BoothRepository()
        {
            models = new List<IBooth>();
        }
        public IReadOnlyCollection<IBooth> Models => models;
        public void AddModel(IBooth model)
        {
            models.Add(model);
        }
    }
}
