
namespace Cars
{
    using System;
    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Start() => "Engine start";
        public string Stop()=> "Breaaak!";

        public override string ToString()
            => $"{Color} Seat {Model}";
    }
}
