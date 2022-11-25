using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
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
        [Parameter] public DateTime? Today { get; set; }
        [Parameter] public List<CalendarItem> CalendarItems { get; set; }
        [Parameter] public EventCallback<CalendarItem> ItemClick { get; set; }
        [Parameter] public EventCallback<DateRange> DateRangeChange { get; set; }
        [Parameter] public bool IsShow { get; set; } = true;

        [Inject] public IJSRuntime jsRunTime { get; set; }
        [Inject] public IStringLocalizer<Calendar> Localizer { get; set; }


        //private string monthName = "";
        private DateTime monthEnd;
        private int monthsAway = 0;
        private int numDummyColumn = 0;
        private int year = 0;
        private int month = 0;

        protected override void OnInitialized()
        {
            CalendarItems = CalendarItems ?? new List<CalendarItem>();
            CreateMonth(false);
        }

        private void CreateMonth(bool notifyEvent = true)
        {
            Today = (Today.HasValue ? Today.Value : DateTime.Today);
            var tempDate = Today.Value.AddMonths(monthsAway);
            month = tempDate.Month;
            year = tempDate.Year;

            DateTime monthStart = new DateTime(year, month, 1);
            monthEnd = monthStart.AddMonths(1).AddDays(-1);
            numDummyColumn = (int)monthStart.DayOfWeek;

            if (notifyEvent && DateRangeChange.HasDelegate)
            {
                DateRangeChange.InvokeAsync(new DateRange(monthStart, monthEnd));
            }
        }

        private string selectedCulture = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
        private string GetDayName(int day)
        {
            var culture = new System.Globalization.CultureInfo(selectedCulture);
            return culture.DateTimeFormat.GetDayName((DayOfWeek)day);
        }

        #region Print Page
        public async Task Print()
        {
            await jsRunTime.InvokeVoidAsync("CalendarPrint");
        }
        public async Task Print_Before()
        {
            await jsRunTime.InvokeVoidAsync("CalendarPrint_Before");
        }
        public async Task Print_After()
        {
            await jsRunTime.InvokeVoidAsync("CalendarPrint_After");
        }
        #endregion
    }
}
