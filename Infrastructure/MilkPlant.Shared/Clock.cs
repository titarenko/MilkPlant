using System;

namespace MilkPlant.Shared
{
    public static class Clock
    {
        public static DateTime? FreezedTime { get; set; }
        public static DateTime Now { get { return FreezedTime ?? DateTime.Now; } }
    }
}