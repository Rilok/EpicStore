namespace EpicStore.Factory._5HardDrive
{
    public abstract class HardDrive
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"Dysk twardy:\nProducent: {Manufacturer}\nModel: " +
                   $"{Model}\nTyp: {Type}\nPojemność: {Capacity} GB\nCena: " +
                   $"{Price} zł";
        }
    }
}