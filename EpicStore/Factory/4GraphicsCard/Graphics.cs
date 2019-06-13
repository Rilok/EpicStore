namespace EpicStore.Factory._4GraphicsCard
{
    public abstract class Graphics
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int VideoMemorySize { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"Karta graficzna:\nProducent: {Manufacturer}\nModel: " +
                   $"{Model}\nRozmiar pamięci video: {VideoMemorySize} GB\nCena: " +
                   $"{Price} zł";
        }
    }
}