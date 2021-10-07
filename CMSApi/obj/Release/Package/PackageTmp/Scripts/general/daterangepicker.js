/*
 * 
 * For API usage, may visit http://www.daterangepicker.com/
 * 
 */
function initializeDateRangePicker(id, format) {
    $('#' + id).daterangepicker(
        {
            alwaysShowCalendars: true,
            autoUpdateInput: false,
            locale: {
                format: format
            },
            ranges: {
                'Today': [moment(), moment()],
                'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                'Last 14 Days': [moment().subtract(13, 'days'), moment()],
                'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                'This Month': [moment().startOf('month'), moment().endOf('month')],
                'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
            }
        }
    );

    $('#' + id).on('apply.daterangepicker', function (ev, picker) {
        $(this).val(picker.startDate.format(format) + ' - ' + picker.endDate.format(format));
    });

    $('#' + id).on('cancel.daterangepicker', function (ev, picker) {
        $(this).val('');
    });
}