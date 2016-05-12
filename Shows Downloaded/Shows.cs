using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
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
        public bool DoNotSave { get; set; }
        public bool ChangesMade { get; set; }
		public bool MultipleShow { get; set; }

        public string[] MultiDays = new string[10];
        public string[] MultiTimes = new string[10];
        public int MultiShowCount { get; set; }
        public string MultipleShowID { get; set; }
		public bool SingleShowing { get; set; }
    }

	public class AppSettings
	{
		public bool ShowOnHiatus { get; set; }
		public bool ShowCancelled { get; set; }
		public string ListColumnSizes { get; set; }
        public string LogColumnSizes { get; set; }
		public bool ShowSkippedWeek { get; set; }
		public Color ColorDownloaded { get; set; }
		public Color ColorSkipped { get; set; }
		public Color ColorNotDownloaded { get; set; }
		public Color ColorMissedWeek { get; set; }
		public bool OnlyShowNotDownloaded { get; set; }
		public string DatabaseLocation { get; set; }
		public string LogFileLocation { get; set; }
		public bool KeepLog { get; set; }
		public bool LogToDatabase { get; set; }
		public int DatabaseID { get; set; }
	}

    public class Logs
    {
        public DateTime LogDate;
        public string Status;
    }
}
