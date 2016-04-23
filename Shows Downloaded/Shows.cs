using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shows_Downloaded
{
    public class Shows
    {
        public string ShowName { get; set; }
        public int ID { get; set; }
        public string ShowDay { get; set; }
        public string ShowTime { get; set; }
        public bool Downloaded { get; set; }
        public bool SkipWeek { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime SeasonEnd { get; set; }
        public bool OnHiatus { get; set; }
        public bool ShowCancelled { get; set; }
        public bool ShowDeleted { get; set; }
        public bool ShowMissedLastWeek { get; set; }
        public int DatabaseRow { get; set; }
        public int DayIndex { get; set; }
        public double TimeIndex { get; set; }
        public bool MultipleShowTimes { get; set; }

        public string[] MultiDays;
        public string[] MultiTimes;
        public int MultipleShowID { get; set; }

        public bool Equals(Shows other)
        {
            if (!this.ShowName.Equals(other.ShowName)) return false;
            if (!this.ShowDay.Equals(other.ShowDay)) return false;
            if (this.ShowTime != other.ShowTime) return false;
            if (this.Downloaded != other.Downloaded) return false;
            if (this.SkipWeek != other.SkipWeek) return false;
            if (this.OnHiatus != other.OnHiatus) return false;
            if (!this.ShowTime.Equals(other.ShowTime)) return false;
            if (this.ShowCancelled != other.ShowCancelled) return false;
            if (this.ShowDeleted != other.ShowDeleted) return false;

            return true;
        }

    }
}
