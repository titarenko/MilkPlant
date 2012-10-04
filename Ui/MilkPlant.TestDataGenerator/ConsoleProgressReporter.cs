using System;
using MilkPlant.Shared;

namespace MilkPlant.TestDataGenerator
{
    public class ConsoleProgressReporter : IProgressReporter
    {
        private const int STATISTICS_REFRESH_TIME_SECONDS = 2;

        private DateTime startTime;
        private string activityName;
        private double percentage;
        private double averageItemsPerSecond;
        private DateTime statisticsDisplayTime;

        public void Start(string activityName)
        {
            startTime = Clock.Now;
            this.activityName = activityName;
            Console.WriteLine("Started {0} at {1:HH:mm:ss}.", activityName, startTime);
        }

        public void Finish()
        {
            var finishTime = Clock.Now;
            Console.WriteLine(
                "Finished {0} at {1:HH:mm:ss}. Time taken: {2}.",
                activityName, finishTime, finishTime.Subtract(startTime));
        }

        public void Porgress(int index, int count)
        {
            if (Clock.Now.Subtract(statisticsDisplayTime).TotalSeconds > STATISTICS_REFRESH_TIME_SECONDS)
            {
                percentage = (index + 1)/(double) count;
                averageItemsPerSecond = (index + 1)/Clock.Now.Subtract(startTime).TotalSeconds;

                Console.Write(
                    "\rProcessed {0} of {1} items ({2:P}, {3:F4} items per second).",
                    index + 1, count, percentage, averageItemsPerSecond);

                statisticsDisplayTime = Clock.Now;
            }

            if (index == count - 1)
            {
                Console.Write("\rProcessed {0} items. Average performance: {1:F4} items per second.", count, averageItemsPerSecond);
                Console.WriteLine();
            }
        }
    }
}