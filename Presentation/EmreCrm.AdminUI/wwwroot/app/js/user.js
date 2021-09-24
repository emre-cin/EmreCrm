$.User = {
    add: function () {
        if (!$('#add-user-form').valid()) {
            return;
        }

        $.ajax({
            type: "POST",
            url: '/Home/Add',
            data: $('#add-user-form').serialize(),
            success: function (d) {
                $.App.ajaxReturn(d);
            },
            error: function (d) {
                $.App.ajaxReturn(d);
            }
        });
    },
    edit: function () {

        if (!$('#edit-user-form').valid()) {
            return;
        }

        var formData = new FormData($('#edit-user-form')[0]);

        $.ajax({
            type: "POST",
            url: '/Home/Edit',
            data: formData,
            processData: false,
            contentType: false,
            success: function (d) {
                $.App.ajaxReturn(d);
            },
            error: function (d) {
                $.App.ajaxReturn(d);
            }
        });
    }
};
