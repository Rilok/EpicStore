namespace EpicStore.Factory._5HardDrive
{
    public interface IHardDriveFactory
    {
        HardDrive TakeHardDrive(string type, int choice);
    }
}