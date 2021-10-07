function confirmBox(heading, question, okcallback, cancelcallback) {
    return confirmInfoBox(heading, question, okcallback, cancelcallback, false);
}

function confirmInfoBox(heading, question, okcallback, cancelcallback, displayAsInfo) {
    var border;
    var header;
    var footer = 'confirmbox-footer';

    if (displayAsInfo) {
        border = 'confirmbox-info-border';
        header = 'confirmbox-info-header';
    }
    else {
        border = 'confirmbox-border';
        header = 'confirmbox-header';
    }

    var confirmModal =
        $('<div class="modal fade" data-backdrop="static" data-keyboard="false">' +
            '<div class="modal-dialog">' +
            '<div class="modal-content ' + border + '">' +
            '<div class="modal-header ' + header + '">' +
            '<button type="button" data-toggle="tooltip" data-placement="left" class="close" style="padding-top: 10px;" ' +
            'data-dismiss="modal" aria-hidden="true" id="CloseButton" title="Close"><span class="glyphicon glyphicon-remove-circle"></span>' +
            '</button>' +
            '<h4>' + heading + '</h4>' +
            '</div>' +
            '<div class="modal-body">' +
            '<p>' + question + '</p>' +
            '</div>' +
            '<div class="modal-footer ' + footer + '">' +
            '<a href="#!" id="okButton" class="btn btn-primary modal-general-button">OK</a>' +
            '<a href="#!" id="cancelButtonText" class="btn btn-primary modal-general-button" data-dismiss="modal">Cancel</a>' +
            '</div>' +
            '</div>' +
            '</div>' +
            '</div>');

    confirmModal.modal('show');

    confirmModal.find('#okButton').click(function () {
        confirmModal.modal('hide');
        if (okcallback)
            okcallback();
    });

    confirmModal.find('#CloseButton').click(function () {
        confirmModal.modal('hide');
        if (cancelcallback)
            cancelcallback();
    });

    confirmModal.find('#cancelButtonText').click(function () {
        confirmModal.modal('hide');
        if (cancelcallback)
            cancelcallback();
    });
}

function alertBox(heading, remarks, displayAsError) {
    var headerClass;
    var borderClass;
    if (displayAsError) {
        headerClass = 'alertbox-error-header';
        borderClass = 'alertbox-error-border';
    }
    else {
        headerClass = 'alertbox-info-header';
        borderClass = 'alertbox-info-border';
    }
    var alertModal =
        $('<div class="modal fade" data-backdrop="static" data-keyboard="false">' +
            '<div class="modal-dialog">' +
            '<div class="modal-content ' + borderClass + '">' +
            '<div class="modal-header ' + headerClass + '">' +
            '<button type="button" data-toggle="tooltip" data-placement="left" class="close" style="padding-top: 10px;" ' +
            'data-dismiss="modal" aria-hidden="true" id="CloseButton" title="Close"><span class="glyphicon glyphicon-remove-circle"></span>' +
            '</button>' +
            '<h4>' + heading + '</h4>' +
            '</div>' +
            '<div class="modal-body">' +
            remarks +
            '</div>' +
            '<div class="modal-footer">' +
            '<a href="#!" id="okButton" class="btn btn-primary modal-general-button">OK</a>' +
            '</div>' +
            '</div>' +
            '</div>' +
            '</div>');

    alertModal.modal('show');

    alertModal.find('#okButton').click(function () {
        alertModal.modal('hide');
    });

    alertModal.find('#CloseButton').click(function () {
        alertModal.modal('hide');
    });
}

function processBox(text) {
    var processModal =
        $('<div class="modal fade" id="pleaseWaitDialog" data-backdrop="static" data-keyboard="false">' +
                '<div class="modal-dialog">' +
                    '<div class="modal-content">' +
                        '<div class="modal-body" style="padding:10px;">' +
                            '<h4s>' + text + '</h4>' +
                            '<div class="progress" style="margin-bottom:0">' +
                                '<div class="progress-bar progress-bar-success progress-bar-striped active" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 100%">' +
                                '</div>' +
                            '</div>' +
                        '</div>' +
                    '</div>' +
                '</div>' +
            '</div>');
    processModal.modal('show');
    return processModal;
}