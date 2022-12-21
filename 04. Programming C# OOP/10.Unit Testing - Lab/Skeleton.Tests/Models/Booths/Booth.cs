using System;
using System.Collections.Generic;
using System.Text;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int capacity;
        private readonly IRepository<IDelicacy> delicacies;
        private readonly IRepository<ICocktail> cocktails;
        public int BoothId { get; }

        private Booth()
        {
            delicacies = new DelicacyRepository();
            cocktails = new CocktailRepository();
        }
        public Booth(int boothId, int capacity) : this()
        {
            BoothId = boothId;
            Capacity = capacity;
            CurrentBill = 0;
            Turnover = 0;
        }
        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                capacity = value;
            }
        }
        public IRepository<IDelicacy> DelicacyMenu  => delicacies;
        public IRepository<ICocktail> CocktailMenu => cocktails;

        public double CurrentBill { get; private set; }

        public double Turnover { get; private set; }
        public bool IsReserved { get; private set; }
        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;
        }

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void ChangeStatus()
        {
            if(IsReserved) 
                IsReserved = false;
            else
                IsReserved = true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:f2} lv");
            sb.AppendLine($"-Cocktail menu:");
            foreach (var cocktail in cocktails.Models)
                sb.AppendLine($"--{cocktail}");
            sb.AppendLine("-Delicacy menu:");
            foreach (var item in delicacies.Models)
                sb.AppendLine($"--{item}");
            return sb.ToString().Trim();
        }
    }
}
