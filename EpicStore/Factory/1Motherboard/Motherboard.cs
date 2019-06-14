namespace EpicStore.Factory._1Motherboard
{
    public abstract class Motherboard
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Chipset { get; set; }
        public string Socket { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"Płyta główna:\nProducent: {Manufacturer}\nModel: {Model}\nTyp: {Type}\n" +
                   $"Chipset: {Chipset}\nSocket: {Socket}\nCena: {Price} zł\n";
        }
    }
}