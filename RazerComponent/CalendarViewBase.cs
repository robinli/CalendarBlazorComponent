using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazerComponent
{
    public class CalendarViewBase : ComponentBase
    {
        [Parameter] public DateTime? Today { get; set; }
        [Parameter] public EventCallback<DateTime?> TodayChanged { get; set; }

        [Parameter] public List<CalendarItem> CalendarItems { get; set; }
        [Parameter] public EventCallback<CalendarItem> ItemClick { get; set; }
        [Parameter] public EventCallback<DateRange> DateRangeChange { get; set; }
        [Parameter] public bool IsShow { get; set; } = true;
        [Parameter] public bool CanEditData { get; set; } = true;

        //[Inject] public IJSRuntime jsRunTime { get; set; }
        [Inject] public IStringLocalizer<Calendar> Localizer { get; set; }


        #region Get Name of Weekday
        private string selectedCulture = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
        protected string GetDayName(int day)
        {
            var culture = new System.Globalization.CultureInfo(selectedCulture);
            return culture.DateTimeFormat.GetDayName((DayOfWeek)day);
        }
        protected string GetDayName(DateTime day)
        {
            var culture = new System.Globalization.CultureInfo(selectedCulture);
            return culture.DateTimeFormat.GetDayName(day.DayOfWeek);
        }
        #endregion


        internal virtual string GetTitle() { return Today.Value.ToString("Y"); }
        internal virtual void PreviousClick() { return; }
        internal virtual void NextClick() { return; }
        internal virtual void TodayClick() { return; }

        //#region Print Page
        //public async Task Print()
        //{
        //    await jsRunTime.InvokeVoidAsync("CalendarPrint");
        //}
        //public async Task Print_Before()
        //{
        //    await jsRunTime.InvokeVoidAsync("CalendarPrint_Before");
        //}
        //public async Task Print_After()
        //{
        //    await jsRunTime.InvokeVoidAsync("CalendarPrint_After");
        //}
        //#endregion
    }
}
