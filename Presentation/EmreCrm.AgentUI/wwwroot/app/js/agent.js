$.Agent = {
    edit: function () {

        if (!$('#edit-agent-form').valid()) {
            return;
        }

        var formData = new FormData($('#edit-agent-form')[0]);

        if ($('#company-logo')[0])
            formData.append('companyLogo', $('#company-logo')[0].files[0]);

        $.ajax({
            type: "POST",
            url: '/Home/Profile',
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

jQuery(document).ready(function () {

    $('#company-logo').fileinput({
        theme: 'tr',
        language: 'tr',
        allowedFileExtensions: ['jpg', 'png', 'gif'],
        initialPreviewAsData: true,
        dropZoneTitle: "Firma logosunu seçiniz ya da sürükleyip buraya bırakınız",
        maxFilesNum: 1,
        browseLabel: "Fotoğraf Seçiniz",
        showUpload: false,
        previewFileType: 'any'
    });
});
