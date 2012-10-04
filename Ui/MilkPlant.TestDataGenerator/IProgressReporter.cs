namespace MilkPlant.TestDataGenerator
{
    public interface IProgressReporter
    {
        void Start(string activityName);
        void Finish();

        void Porgress(int index, int count);
    }
}