namespace MilkPlant.Shared
{
    public interface IConfiguration
    {
        string GetValue(string key);
    }
}