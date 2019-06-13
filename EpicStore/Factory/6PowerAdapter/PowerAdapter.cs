namespace EpicStore.Factory._6PowerAdapter
{
    public abstract class PowerAdapter
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Power { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"Zasilacz:\nProducent: {Manufacturer}\nModel: " +
                   $"{Model}\nMoc: {Power} W\nCena: {Price} zł";
        }
    }
}