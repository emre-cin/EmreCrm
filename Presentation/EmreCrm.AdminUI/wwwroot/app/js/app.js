$.App = {
    init: function () {

        // Input Validate control
        $.validator.setDefaults({
            highlight: function (element) {
                $(element).closest('.form-group').addClass('has-danger');
            },
            unhighlight: function (element) {
                $(element).closest('.form-group').removeClass('has-danger');
            },
            errorPlacement: function (error, element) {
                //return true;
            }
        });

        jQuery.extend(jQuery.validator.messages, {
            required: "Zorunlu alan.",
            remote: "Lütfen bu alanı düzeltin.",
            email: "Lütfen geçerli bir e-posta adresi giriniz.",
            url: "Lütfen geçerli bir web adresi (URL) giriniz.",
            date: "Lütfen geçerli bir tarih giriniz.",
            dateISO: "Lütfen geçerli bir tarih giriniz(ISO formatında)",
            number: "Lütfen geçerli bir sayı giriniz.",
            digits: "Lütfen sadece sayısal karakterler giriniz.",
            creditcard: "Lütfen geçerli bir kredi kartı giriniz.",
            equalTo: "Lütfen aynı değeri tekrar giriniz.",
            extension: "Lütfen geçerli uzantıya sahip bir değer giriniz.",
            maxlength: $.validator.format("Lütfen en fazla {0} karakter uzunluğunda bir değer giriniz."),
            minlength: $.validator.format("Lütfen en az {0} karakter uzunluğunda bir değer giriniz."),
            rangelength: $.validator.format("Lütfen en az {0} ve en fazla {1} uzunluğunda bir değer giriniz."),
            range: $.validator.format("Lütfen {0} ile {1} arasında bir değer giriniz."),
            max: $.validator.format("Lütfen {0} değerine eşit ya da daha küçük bir değer giriniz."),
            min: $.validator.format("Lütfen {0} değerine eşit ya da daha büyük bir değer giriniz."),
            require_from_group: $.validator.format("Lütfen bu alanların en az {0} tanesini doldurunuz.")
        });

        $.validator.methods.number = function (value, element) {
            return this.optional(element) || /-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
        }

    },
    initGrid: function (element) {
        var grids = document.querySelectorAll(element);

        for (var i = 0; i < grids.length; i++) {

            var grid = grids[i];

            new MvcGrid(grid,
                {
                    reloadStarted: AjaxStart(),
                    reloadEnded: AjaxStop()
                });
        }
    },
    // Sweetalert
    alert: function (title, text, confirmButtonText, cancelButtonText, postData, postUrl, redirect) {
        swal({
            title: title,
            text: text,
            type: 'error',
            showCancelButton: true,
            showConfirmButton: true,
            confirmButtonColor: '#fb434a',
            confirmButtonText: confirmButtonText,
            cancelButtonText: cancelButtonText
        }, function () {

            $.ajax({
                type: 'POST',
                dataType: 'json',
                data: postData,
                url: postUrl,
                success: function (d) {

                    if (d.IsSuccess) {
                        swal("Başarılı!", "İşleminiz başarıyla gerçekleştirilmiştir.", "success");

                    } else {
                        swal("Hata!", "Bir sorun oluştu.", "error");
                    }
                }
            });

        })
    },
    deleteRow: function (postData, postUrl, redirect) {
        var isSuccess = false;

        swal({
            title: 'Emin misiniz ?',
            text: "Seçilen veri kalıcı olarak silinecektir!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Evet, Sil!',
            cancelButtonText: 'Vazgeç',
            reverseButtons: true
        }).then(function (result) {
            if (result.value) {

                $.App.openLoader('body', 'Silme İşlemi Gerçekleştiriliyor <br /> <b>Lütfen Bekleyin</b>');

                $.ajax({
                    type: 'POST',
                    url: postUrl + '/' + postData,
                    success: function (d) {
                        if (d.IsSuccess) {
                            swal('Silindi!', 'Silmek istediğiniz veri başarı ile silindi', 'success');
                            window.location.href = redirect;
                        } else {
                            swal("Hata!", "Bir sorun oluştu.", "error");
                        }
                    }
                });

                $.App.closeLoader('body');

            } else if (result.dismiss === 'cancel') {
                swal('Vazgeçildi!', 'Silme işleminden vazgeçildi!', 'error')
            }
        });
    },
    cancel: function (redirect) {
        var isSuccess = false;

        swal({
            title: 'Emin misiniz ?',
            text: "Sayfadan ayrıldığınız zaman kaydedilmemiş veriler kaybolacaktır!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Evet, Vazgeç!',
            cancelButtonText: 'Hayır',
            reverseButtons: true
        }).then(function (result) {
            if (result.value) {
                $.App.openLoader($('body'), 'Yönlendiriliyorsunuz <br /> <b>Lütfen Bekleyin</b>');
                window.location.href = redirect;
            }
        });
    },
    openLoader: function (container, text) {
        mApp.block(container, {
            overlayColor: 'black',
            type: 'loader',
            state: 'primary',
            message: text
        });
    },
    closeLoader: function (container) {
        mApp.unblock(container);
    },
    notify: function (message, title, type) {

        toastr[type](message, title);

        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };
    },
    imgError: function (image) {
        image.onerror = "";
        image.src = "/uploads/image-not-found.png";
        return true;
    },
    redirect: function (url, msgContainer) {
        $.App.openLoader($(msgContainer), 'Yönlendiriliyorsunuz <br /> <b>Lütfen Bekleyin</b>');
        window.location.href = url;
    },
    ajaxReturn: function (data, fn, msgContainer) {

        if (data.IsSuccess) {
            if (fn && typeof fn == 'function')
                fn(data);

            $.App.notify(data.Message, 'İşlem Başarılı', 'success');
        }
        else if (data.IsSuccess == false && data.Message != null) {
            $.App.notify(data.Message, 'İşlem Başarısız', 'error');
        }

        if (data.Redirect != null) {

            $.App.openLoader($(msgContainer), 'Yönlendiriliyorsunuz <br /> <b>Lütfen Bekleyin</b>');

            setTimeout(function () {
                $.App.redirect(data.Redirect, msgContainer);
            }, 1000);
        }

    },
    calljx: function (typ, url, postData, cached, mask, done, fail, asn) {

        if (mask) {
            $.App.openLoader($(mask), 'İşlem Gerçekleştiriliyor <br /> <b>Lütfen Bekleyin</b>');
        }

        if (asn == undefined)
            asn = true;

        var requestOptions = {
            type: typ,
            url: url,
            data: postData,
            cache: cached,
            async: asn,
            dataType: 'json',
            contentType: false,
            processData: false,
            success: function (result) {
                if (mask) {
                    Ada.closeLoader(mask);
                }
                if (done && typeof done == 'function') {
                    done(result);
                }
            },
            error: function (xhr, status, error) {
                if (mask) {
                    Ada.closeLoader(mask);
                }
                if (fail && typeof fail == 'function') {
                    fail(xhr, status, error);
                }
            }
        };

        if (typ == 'POST')
            $.extend(requestOptions, { dataType: 'json' });

        return $.ajax(requestOptions);
    },
};


$(document).ajaxError(function (event, request, settings) {
    if (request.status == 401) {
        $.App.unauthorized();
    }
});

$(document).ajaxStart(function (event, request, settings) {
    AjaxStart();
});

$(document).ajaxStop(function (event, request, settings) {
    AjaxStop();
});

function AjaxStart() {
    if ($('#formWrapper').length > 0) {
        $.App.openLoader('#formWrapper', 'İşlem Gerçekleştiriliyor <br /> <b>Lütfen Bekleyin</b>');
    } else {
        $.App.openLoader('body', 'İşlem Gerçekleştiriliyor <br /> <b>Lütfen Bekleyin</b>');
    }
}
function AjaxStop() {
    if ($('#formWrapper').length > 0) {
        $.App.closeLoader('#formWrapper');
    } else {
        $.App.closeLoader('body');
    }
}
