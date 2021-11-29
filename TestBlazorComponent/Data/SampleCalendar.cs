using RazerComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBlazorComponent.Data
{
    public interface ISampleCalendarDataService {
        public List<CalendarItem> GetAll();
        public List<CalendarItem> Get(DateTime startDate, DateTime finishDate);
    }

    public class SampleCalendarDataService : ISampleCalendarDataService
    {
        private List<CalendarItem> listData = null;

        public List<CalendarItem> GetAll()
        {
            if (listData == null)
            {
                Random rnd = new Random();
                listData = new List<CalendarItem>();
                int Id = 0;
                for (int year = -1; year <= 1; year++)
                {
                    for (int month = 1; month <= 12; month++)
                    {
                        for (int i = 0; i <= rnd.Next(0, 8); i++)
                        {
                            Id++;
                            DateTime t1 = new DateTime(DateTime.Today.Year + year, month, rnd.Next(1, 12));
                            if(t1.DayOfWeek == DayOfWeek.Sunday)
                            {
                                listData.Add(new CalendarItem(Id, t1, $"Test day {Id.ToString("000")}", "bg-danger"));
                            }
                            else
                            {
                                listData.Add(new CalendarItem(Id, t1, $"Test day {Id.ToString("000")}"));
                            }
                            
                        }
                    }
                }
                
            }
            return listData;
        }

        public List<CalendarItem> Get(DateTime startDate, DateTime finishDate)
        {
            return (from x in GetAll()
                    where x.Date >= startDate
                    && x.Date <= finishDate
                    select x).ToList();
        }
    }
}
