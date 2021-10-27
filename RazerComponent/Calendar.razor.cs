using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazerComponent
{
    /// <summary>
    /// Source from : https://github.com/modulardev2/Calendar
    /// </summary>
    public partial class Calendar : ComponentBase
    {
        [Parameter] public List<CalendarItem> CalendarItems { get; set; }
        [Parameter] public EventCallback<CalendarItem> ItemClick { get; set; }
        [Parameter] public EventCallback<DateRange> DateRangeChange { get; set; }


        private string monthName = "";
        private DateTime monthEnd;
        private int monthsAway = 0;
        private int numDummyColumn = 0;
        private int year = 0;
        private int month = 0;
        

        protected override void OnInitialized()
        {
            CalendarItems = CalendarItems ?? new List<CalendarItem>();
            CreateMonth();
        }

        private void CreateMonth()
        {
            var tempDate = DateTime.Now.AddMonths(monthsAway);
            month = tempDate.Month;
            year = tempDate.Year;

            DateTime monthStart = new DateTime(year, month, 1);
            monthEnd = monthStart.AddMonths(1).AddDays(-1);
            monthName = monthStart.Month switch
            {
                1 => "January",
                2 => "February",
                3 => "March",
                4 => "April",
                5 => "May",
                6 => "June",
                7 => "July",
                8 => "August",
                9 => "September",
                10 => "October",
                11 => "November",
                12 => "December",
                _ => ""
            };

            numDummyColumn = (int)monthStart.DayOfWeek;

            if (DateRangeChange.HasDelegate)
            {
                DateRangeChange.InvokeAsync(new DateRange(monthStart, monthEnd));
            }

        }
    }
}
