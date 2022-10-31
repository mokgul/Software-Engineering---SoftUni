using System;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Beverage beverage = new Beverage("beverage", 2.50m, 120);
            Cake cake = new Cake("cake");
            Coffee coffee = new Coffee("coffee", 90);
            ColdBeverage cold = new ColdBeverage("cold", 1.20m, 250);
            Dessert dessert = new Dessert("dessert", 4.50m, 125, 450);
            Fish fish = new Fish("fish", 12.30m);
            Food food = new Food("food", 3.30m, 220);
            HotBeverage hot = new HotBeverage("hot", 2.20m, 120);
            MainDish main = new MainDish("main", 5.50m, 190);
            Product product = new Product("product", 5.50m);
            Soup soup = new Soup("soup", 3.30m, 250);
            Starter starter = new Starter("starter", 2.50m, 120);
            Tea tea = new Tea("tea", 1.20m, 200);
        }
    }
}
