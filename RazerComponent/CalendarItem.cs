using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazerComponent
{
    public record DateRange(DateTime StartDate, DateTime FinishDate);


    public class CalendarItem 
    {
        public int Id { get; set; } 
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string CssBgColor { get; set; }
        
        public CalendarItem(int id, DateTime date, string name)
        {
            Id = id;
            Date = date;
            Name = name;
        }
        public CalendarItem(int id, DateTime date, string name, string cssBgColor)
        {
            Id = id;
            Date = date;
            Name = name;
            CssBgColor = cssBgColor;
        }
    };

}
