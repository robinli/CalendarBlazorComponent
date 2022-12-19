using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazerComponent
{
    public partial class WeekView : CalendarViewBase
    {
        //[Parameter] public DateTime? Today { get; set; }
        //[Parameter] public List<CalendarItem> CalendarItems { get; set; }
        //[Parameter] public EventCallback<CalendarItem> ItemClick { get; set; }
        //[Parameter] public EventCallback<DateRange> DateRangeChange { get; set; }
        //[Parameter] public bool IsShow { get; set; } = true;

        //[Inject] public IJSRuntime jsRunTime { get; set; }
        //[Inject] public IStringLocalizer<Calendar> Localizer { get; set; }

        private DateTime WeekFrom { get; set; }
        private DateTime WeekEnd { get; set; }
        private int daysAway = 0;

        protected override void OnInitialized()
        {
            CalendarItems = CalendarItems ?? new List<CalendarItem>();
            CreateMonth(false);
        }

        private void CreateMonth(bool notifyEvent = true)
        {
            Today = (Today.HasValue ? Today.Value : DateTime.Today);

            DateTime tempDate = Today.Value.AddDays(daysAway);
            int days = (int)tempDate.DayOfWeek;

            WeekFrom = tempDate.AddDays((-1) * days);
            WeekEnd = WeekFrom.AddDays(6);

            if (notifyEvent && DateRangeChange.HasDelegate)
            {
                DateRangeChange.InvokeAsync(new DateRange(WeekFrom, WeekEnd));
            }
        }

        internal override string GetTitle()
        {
            return WeekFrom.ToString("Y");
        }
        internal override void PreviousClick()
        {
            daysAway = daysAway - 7;
            CreateMonth();
        }
        internal override void NextClick()
        {
            daysAway = daysAway + 7;
            CreateMonth();
        }
        internal override void TodayClick()
        {
            daysAway = 0;
            CreateMonth();
        }
        //private async Task OnPreviousClick()
        //{
        //    await Task.Delay(0);
        //    Today = WeekFrom.AddDays(-7);
        //    CreateMonth();
        //}
        //private async Task OnNextClick()
        //{
        //    await Task.Delay(0);
        //    Today = WeekFrom.AddDays(7);
        //    CreateMonth();
        //}
        //private async Task OnTodayClick()
        //{
        //    await Task.Delay(0);
        //    Today = DateTime.Today;
        //    CreateMonth();
        //}

        //private string selectedCulture = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
        //public string GetDayName(DateTime day)
        //{
        //    var culture = new System.Globalization.CultureInfo(selectedCulture);
        //    return culture.DateTimeFormat.GetDayName(day.DayOfWeek);
        //}

        #region Set Event position Row and Column
        private int[] positions = new int[] { 0, 0, 0, 0, 0, 0, 0 };
        
        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            positions = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            return base.OnAfterRenderAsync(firstRender);
        }
        
        private string GetStyleSheet(CalendarItem item)
        {
            DateTime date = item.Date;
            try
            {
                int col = (int)date.Subtract(WeekFrom).TotalDays;

                positions[col] += 1;

                return $"grid-column: {col + 1};grid-row: {positions[col]}/span 1;";
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return "";
        }
        #endregion

        private string GetBgColor(CalendarItem item)
        {
            if(item.CssBgColor==null)
            {
                return "btn-outline-secondary";
            }

            return item.CssBgColor.Replace("bg-", "btn-outline-");
        }

    }
}
