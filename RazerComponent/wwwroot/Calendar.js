function CalendarPrint() {
    CalendarPrint_Before();
    window.print();
    CalendarPrint_After();
}

function CalendarPrint_Before() {
    $(".justify-content-end").hide();
    $(".close").hide();

    $('div.fc-day-header').css('font-size', '24px');
    $('div.fc-day-header').css('color', '#000');

    $('div.fc-day-number').css('font-size', '24px');
    $('div.fc-day-number').css('color', '#000');

    $('.fc-event-title').css('font-size', '24px');
    $('.fc-event-title').css('color', '#000');
}

function CalendarPrint_After() {
    $(".justify-content-end").show();
    $(".close").show();

    $('div.fc-day-header').css('font-size', '14px');
    $('div.fc-day-header').css('color', '#FFF');

    $('div.fc-day-number').css('font-size', '');
    $('div.fc-day-number').css('color', '');

    $('.fc-event-title').css('font-size', '');
    $('.fc-event-title').css('color', '');
}