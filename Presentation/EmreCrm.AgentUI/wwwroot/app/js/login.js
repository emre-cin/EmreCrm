jQuery(document).ready(function () {

    $("#login-form").submit(function (e) {

        e.preventDefault();

        if (!$('#login-form').valid()) {
            return;
        }

        $.ajax({
            type: "POST",
            url: '/Home/Login',
            data: $('#login-form').serialize(),
            success: function (d) {
                $.App.ajaxReturn(d);
            },
            error: function (d) {
                $.App.ajaxReturn(d);
            }
        });

    });

});