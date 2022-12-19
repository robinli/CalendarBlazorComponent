using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RazerComponent
{
    /// <summary>
    /// Source from : https://github.com/modulardev2/Calendar
    /// </summary>
    public partial class Calendar : ComponentBase
    {
        [Inject] public IJSRuntime jsRunTime { get; set; }
        [Inject] public IStringLocalizer<Calendar> Localizer { get; set; }
        [Parameter] public CalendarKind ViewKind { get; set; } = CalendarKind.Month;
        [Parameter] public DateTime? Today { get; set; }
        [Parameter] public List<CalendarItem> CalendarItems { get; set; }
        [Parameter] public EventCallback<CalendarItem> ItemClick { get; set; }
        [Parameter] public EventCallback<DateRange> DateRangeChange { get; set; }
        [Parameter] public bool IsShow { get; set; } = true;
        [Parameter] public bool CanEditData { get; set; } = true;

        private MonthView MonthViewl { get; set; }
        private WeekView WeekViewl { get; set; }
        private string CalendarTitle { get; set; }

        private CalendarViewBase CurrentViewInstance;
        protected override void OnInitialized()
        {
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (ViewKind == CalendarKind.Month)
            {
                CurrentViewInstance = MonthViewl;
            }
            if (ViewKind == CalendarKind.Week)
            {
                CurrentViewInstance = WeekViewl;
            }
            CalendarTitle = CurrentViewInstance.GetTitle();
            StateHasChanged();
        }

        private void PreviousClick() { CurrentViewInstance.PreviousClick(); }
        private void NextClick() { CurrentViewInstance.NextClick(); }
        private void TodayClick() { CurrentViewInstance.TodayClick(); }
        private async Task OnViewKindChange(ChangeEventArgs e)
        {
            await Task.Delay(0);
            var val = e.Value.ToString();
            ViewKind = (CalendarKind)Enum.Parse(typeof(CalendarKind), val, true);
        }

        private async Task OnItemClick(CalendarItem data)
        {
            if (CanEditData)
            {
                await ItemClick.InvokeAsync(data);
            }
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
