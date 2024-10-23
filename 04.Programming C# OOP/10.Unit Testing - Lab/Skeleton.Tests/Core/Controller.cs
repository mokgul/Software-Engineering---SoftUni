using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository booths;

        public Controller()
        {
            booths = new BoothRepository();
        }
        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count + 1;
            booths.AddModel(new Booth(boothId, capacity));
            return string.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            string returnMessage = String.Empty;
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);
            IDelicacy delicacy =
                delicacyTypeName switch
                {
                    "Gingerbread" => new Gingerbread(delicacyName),
                    "Stolen" => new Stolen(delicacyName),
                    _ => null
                };
            if (delicacy == null)
            {
                returnMessage = returnMessage = string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
                return returnMessage;
            }
            if (booth.DelicacyMenu.Models.Any(d => d.GetType() == typeof(Delicacy)))
            {
                returnMessage = string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
                return returnMessage;
            }
            booth.DelicacyMenu.AddModel(delicacy);
            returnMessage = string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
            return returnMessage;

        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            string returnMessage = String.Empty;
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);
            if (size != "Small" && size != "Middle" && size != "Large")
            {
                returnMessage = string.Format(OutputMessages.InvalidCocktailSize, size);
                return returnMessage;
            }

            ICocktail cocktail =
                cocktailTypeName switch
                {
                    "Hibernation" => new Hibernation(cocktailName, size),
                    "MulledWine" => new MulledWine(cocktailName, size),
                    _ => null
                };
            if (cocktail == null)
            {
                returnMessage = string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
                return returnMessage;
            }

            if (booth.CocktailMenu.Models.Any(c => c.Size == size && c.Name == cocktailName))
            {
                returnMessage = string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
                return returnMessage;
            }
            booth.CocktailMenu.AddModel(cocktail);
            returnMessage = string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
            return returnMessage;
        }

        public string ReserveBooth(int countOfPeople)
        {
            
            var orderedBooths = booths.Models.Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity).ThenByDescending(b => b.BoothId);

            IBooth firstAvailable = orderedBooths.FirstOrDefault();
            if (firstAvailable == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }
            firstAvailable.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, firstAvailable.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] args = order.Split('/');
            string itemTypeName = args[0];
            if (itemTypeName != "Gingerbread" && itemTypeName != "Stolen"
                                              && itemTypeName != "Hibernation"
                                              && itemTypeName != "MulledWine")
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);

            string itemName = args[1];
            int count = int.Parse(args[2]);
            string size;
            ICocktail cocktail;
            IDelicacy delicacy;
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);
            if (args.Length == 4)
            {
                size = args[3];
                if (booth.CocktailMenu.Models.All(b => b.Name != itemName))
                    return string.Format(OutputMessages.CocktailStillNotAdded, itemTypeName, itemName);
                cocktail = booth.CocktailMenu.Models.First();
                if (booth.CocktailMenu.Models.All(b => b.Size != size))
                    return string.Format(OutputMessages.CocktailStillNotAdded, itemTypeName, itemName);
                booth.UpdateCurrentBill(cocktail.Price * count);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);
            }
            else
            {
                if (booth.DelicacyMenu.Models.All(b => b.Name != itemName))
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                delicacy = booth.DelicacyMenu.Models.First();
                booth.UpdateCurrentBill(delicacy.Price * count);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);
            }
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);
            double bill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();
            return $"Bill {bill:f2} lv" + Environment.NewLine + $"Booth {boothId} is now available!";
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);
            return booth.ToString().Trim();
        }
    }
}
