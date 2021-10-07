/**
 * 
 * For API usage, may refer to https://eonasdan.github.io/bootstrap-datetimepicker/
 *
 */

// provide only date format here for date picker
function initializeDatePicker(id, format) {
    $('#' + id).datetimepicker({
        showTodayButton: true,
        format: format
    });
}

// provide datetime format here for datetime picker
function initializeDateTimePicker(id, format) {
    $('#' + id).datetimepicker({
        showTodayButton: true,
        format: format,
        sideBySide: true
    });
}

//use this to control end date never earlier than start date
function setEventForStartDateChange(startDateCtrlID, endDateCtrlID) {
    //https://stackoverflow.com/a/36128656
    $("#" + startDateCtrlID).on("dp.change", function (e) {
        if (e.date === false)
            $('#' + endDateCtrlID).data("DateTimePicker").date(null);
        else
            $('#' + endDateCtrlID).data("DateTimePicker").minDate(e.date); //https://stackoverflow.com/a/35713961
    });
}