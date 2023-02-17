using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazerComponent
{
    public partial class MonthView : CalendarViewBase
    {
        private DateTime monthEnd { get; set; }
        private int monthsAway { get; set; } = 0;
        private int numDummyColumn { get; set; } = 0;
        private int year { get; set; } = 0;
        private int month { get; set; } = 0;

        protected override void OnInitialized()
        {
            CalendarItems = CalendarItems ?? new List<CalendarItem>();
            CreateMonth(false);
        }

        private void CreateMonth(bool notifyEvent = true)
        {
            //Today = (Today.HasValue ? Today.Value : DateTime.Today);
            //var tempDate = Today.Value.AddMonths(monthsAway);
            month = Today.Value.Month;
            year = Today.Value.Year;
            DateTime monthStart = new DateTime(year, month, 1);
            monthEnd = monthStart.AddMonths(1).AddDays(-1);
            numDummyColumn = (int)monthStart.DayOfWeek;

            if (notifyEvent && DateRangeChange.HasDelegate)
            {
                DateRangeChange.InvokeAsync(new DateRange(monthStart, monthEnd));
            }
        }

        internal override string GetTitle() 
        { 
            return monthEnd.ToString("Y"); 
        }
        internal override void PreviousClick()
        {
            monthsAway--;
            Today = Today.Value.AddMonths(-1);
            TodayChanged.InvokeAsync(Today);
            CreateMonth();
        }
        internal override void NextClick()
        {
            monthsAway++;
            Today = Today.Value.AddMonths(1);
            TodayChanged.InvokeAsync(Today);
            CreateMonth();
        }
        internal override void TodayClick()
        {
            monthsAway = 0; 
            CreateMonth();
        }
    }
}
