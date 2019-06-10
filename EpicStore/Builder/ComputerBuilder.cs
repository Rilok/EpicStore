namespace EpicStore.Builder
{
    abstract class ComputerBuilder
    {
        protected Computer _computerUnit;

        public Computer Computer => _computerUnit;

        public abstract Computer Build();
        public abstract ComputerBuilder InstallMotherboard();
        public abstract ComputerBuilder InstallProcessor();
        public abstract ComputerBuilder InstallRam();
        public abstract ComputerBuilder InstallGraphicsCard();
        public abstract ComputerBuilder InstallHardDrive();
        public abstract ComputerBuilder InstallPowerAdapter();
        public abstract ComputerBuilder SetPrice();

        public static implicit operator Computer(ComputerBuilder epicBuilder)
        {
            return epicBuilder.InstallMotherboard()
                .InstallProcessor()
                .InstallRam()
                .InstallGraphicsCard()
                .InstallHardDrive()
                .InstallPowerAdapter()
                .SetPrice()
                .Computer;
        }
    }
}
