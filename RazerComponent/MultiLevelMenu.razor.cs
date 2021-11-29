using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazerComponent
{
    public partial class MultiLevelMenu : ComponentBase
    {
        [Parameter] public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

        private bool collapseMultiLevelMenu = true;

        private string MultiLevelMenuCssClass => collapseMultiLevelMenu ? "collapse" : null;

        private void ToggleMultiLevelMenu()
        {
            collapseMultiLevelMenu = !collapseMultiLevelMenu;
        }

        
        private void ToggleSubMenu(MenuItem item)
        {
            item.IsExpandSubMenu = !item.IsExpandSubMenu;
        }
        private string GetCssName(MenuItem item)
        {
            return (item.IsExpandSubMenu ? "oi-chevron-top" : "oi-chevron-bottom");
        }
        //protected override void OnInitialized()
        //{
            //ListMenuItem.Add(new MenuItem() { Name = "First", Path = "First", Icon = "oi-home" });
            //ListMenuItem.Add(new MenuItem() { Name = "Second", Path = "Second", Icon = "oi-home" });

            //MenuItem mainMenu = new MenuItem()
            //{
            //    Name = "Calendar",
            //    Path = "",
            //    Icon = "oi-cog"
            //};
            //mainMenu.Children = new List<MenuItem>();
            //mainMenu.Children.Add(new MenuItem() { Name = "All data", Path = "Index", Icon = "oi-home" });
            //mainMenu.Children.Add(new MenuItem() { Name = "Partial data", Path = "PartialData", Icon = "oi-calendar" });
            //mainMenu.Children.Add(new MenuItem() { Name = "Print", Path = "PrintCalendar", Icon = "oi-print" });
            //mainMenu.Children.Add(new MenuItem() { Name = "Show/Hide", Path = "ShowHide", Icon = "oi-contrast" });
            //mainMenu.Children.Add(new MenuItem() { Name = "Show next month", Path = "SetToday", Icon = "oi-arrow-circle-right" });
            //ListMenuItem.Add(mainMenu);

            //ListMenuItem.Add(new MenuItem() { Name = "Final", Path = "Final", Icon = "oi-home" });
        //}
    }
}
