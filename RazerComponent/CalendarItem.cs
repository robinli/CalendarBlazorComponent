using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazerComponent
{
    public record CalendarItem(int Id, DateTime Date, string Name);

    public record DateRange(DateTime StartDate, DateTime FinishDate);
}
