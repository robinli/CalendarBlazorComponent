# Calendar Blazor Component
## Development
- Visual Studio 2019
- Blazor Server Project
- .NET 5

## Reference

- Creating a Calendar in Blazor - Full Tutorial! https://youtu.be/33klf8M5JAA
- Bootstrap Calendar Design https://bootsnipp.com/snippets/M3jmA

## Use Calendar Component

### install nuget package
Package Manager Console https://www.nuget.org/packages/RazerComponent/
```
Install-Package RazerComponent -Version 1.0.0
```

### Blazer Page
```
<Calendar @ref="CalendarCtrl_1" CalendarItems="Items" OnClick="CalendarItem_Click"></Calendar>
@code{ 
    private Calendar CalendarCtrl_1;
    private List<CalendarItem> Items;
    private string CalendarName;

    protected override void OnInitialized()
    {
        Items = new List<CalendarItem>();
        Items.Add(new CalendarItem(1, new DateTime(2021, 10, 5), "Test day 01"));
        Items.Add(new CalendarItem(2, new DateTime(2021, 10, 5), "Test day 02"));
        Items.Add(new CalendarItem(3, new DateTime(2021, 11, 1), "Test day 03"));
        Items.Add(new CalendarItem(4, new DateTime(2021, 12, 25), "Merry Christmas"));
        Items.Add(new CalendarItem(5, new DateTime(2022, 1, 1), "Happy New Years"));
    }

    private async Task CalendarItem_Click(CalendarItem item)
    {
        await Task.Delay(0);
        CalendarName = item.Name;
    }
}
```


## Calendar Component Layout
![Calendar Component Layout](https://i.imgur.com/b02q48A.png)

