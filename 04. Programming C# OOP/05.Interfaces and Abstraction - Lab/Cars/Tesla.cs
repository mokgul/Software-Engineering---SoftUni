
namespace Cars
{
    using System;
    public class Tesla : IElectricCar
    {
        public Tesla(string model,string color,int batteries)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = batteries;
        }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Start() => "Engine start";
        public string Stop()=> "Breaaak!";

        public int Battery { get; set; }

        public override string ToString()
            => $"{Color} Tesla {Model} with {Battery} Batteries";
    }
}
