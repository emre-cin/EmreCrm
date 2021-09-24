$.Advertisement = {
    add: function () {

        if (!$('#add-advertisement-form').valid()) {
            return;
        }

        var formData = new FormData($('#add-advertisement-form')[0]);

        $.ajax({
            type: "POST",
            url: '/Home/AddAdvertisement',
            dataType: 'json',
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
    },
    edit: function () {

        if (!$('#edit-advertisement-form').valid()) {
            return;
        }

        var formData = new FormData($('#edit-advertisement-form')[0]);

        $.ajax({
            type: "POST",
            url: '/Home/EditAdvertisement',
            dataType: 'json',
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

    },
    search: function () {

        var formdata = $("#search-form").serializeArray();
        var data = {};
        $(formdata).each(function (index, obj) {
            data[obj.name] = obj.value;
        });

        data['filter'] = true;

        var result = decodeURI($.param(data));
        result = result.replace(/[\[\]']+/g, '');

        var grid = new MvcGrid(document.querySelector('#AdvertisementList'),
            {
                reloadStarted: AjaxStart(),
                reloadEnded: AjaxStop()
            });

        grid.sourceUrl = grid.sourceUrl + "?" + result + "&";
        grid.reload();
    },
    resetFilter: function () {
        $('#search-form')[0].reset();
        $.Advertisement.gridReload();
    },
    gridReload: function () {
        new MvcGrid(document.querySelector('#AdvertisementList'),
            {
                reloadStarted: AjaxStart(),
                reloadEnded: AjaxStop()

            }).reload();
    }
};

jQuery(document).ready(function () {

    $('#advertisement-photos').fileinput({
        theme: 'tr',
        language: 'tr',
        allowedFileExtensions: ['jpg', 'png', 'gif'],
        initialPreviewAsData: true,
        dropZoneTitle: "İlan fotoğraflarını seçiniz ya da sürükleyip buraya bırakınız",
        maxFilesNum: 5,
        browseLabel: "Fotoğraf Seçiniz",
        showUpload: false,
        previewFileType: 'any'
    });
});
