// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    var placeholderElement = $('#modal-placeholder');

    $('button[data-toggle="ajax-modal"]').click(function (event) {
        event.preventDefault();
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
    });

    placeholderElement.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();

        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var dataToSend = form.serialize();
        var method = form.attr('method');
        console.log(method);

        //var action;
        //if (method === "PUT") {
        //    action = $.put(actionUrl, dataToSend);
        //} else {
        //    action = $.post(actionUrl, dataToSend);
        //}

        return $.ajax({
            url: actionUrl,
            type: method,
            data: dataToSend,
            success: function (data) {
                var newBody = $('.modal-body', data);
                placeholderElement.find('.modal-body').replaceWith(newBody);

                // find IsValid input field and check it's value
                // if it's valid then hide modal window
                var isValid = newBody.find('[name="IsValid"]').val() === 'True';
                if (isValid) {
                    placeholderElement.find('.modal').modal('hide');

                    var myTable = $('#myDatatable').DataTable();
                    myTable.ajax.reload();
                } else {
                    alert('Error');
                }
            }
        });

        //action.done(function (data) {
        //    var newBody = $('.modal-body', data);
        //    placeholderElement.find('.modal-body').replaceWith(newBody);

        //    // find IsValid input field and check it's value
        //    // if it's valid then hide modal window
        //    var isValid = newBody.find('[name="IsValid"]').val() === 'True';
        //    if (isValid) {
        //        placeholderElement.find('.modal').modal('hide');

        //        var myTable = $('#myDatatable').DataTable();
        //        myTable.ajax.reload();
        //    } else {
        //        alert('Error');
        //    }
        //});
    });
});

function Edit(id, url) {
    var placeholderElement = $('#modal-placeholder');
    event.preventDefault();

    $.get(url, { id }).done(function (data) {
        placeholderElement.html(data);
        placeholderElement.find('.modal').modal('show');
    });
}

function displayBusyIndicator() {
    $('.loading').show();
}

$(window).on('beforeunload', function () {
    displayBusyIndicator();
});

$(document).on('submit', 'form', function () {
    displayBusyIndicator();
});