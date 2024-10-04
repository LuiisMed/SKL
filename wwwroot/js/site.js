//FusionCharts.options.license({
//    key: 'EE-13E5snlA22B9A8D4B2B2F1D4G4D2A1B4d1sB-11A1C4I-8zpnD-17B3F6rfwD3B1D8A3B2A1B1F4E1I1A10B1D7B3D1F3fyF-7A4B8E2B-11E2E3G1nmdC8B2E6bfuI4B3C8fD-13zD3D2E3E4I1C11A1B6C2A1E2A-7uwB3B7FB1ycrA33A18B14crC6UA4H4nhyA7A3A3A5E5A4D4B1A9C10A3A5B4G2a==',
//    creditLabel: false,
//});

function showWindowPopUp(url) {
    $.get(url, function (data) {
        //console.log(data);
        $('#ModalWindow').html(data);
        $('#ModalWindow').modal({ backdrop: 'static', keyboard: false });
    }).done(function () {
        var form = document.getElementById("form1");
        $(form).removeData("validator")
            .removeData("unobtrusiveValidation");
        //$.validator.unobtrusive.parse(form);
    }).fail(function () {
        console.log('popup error')
        window.location.reload(false)
    });
}

// Hub URL
function systemHubUrl() {
    const virtualApp = window.location.host == 'localhost' ? '' : window.location.pathname.split('/')[1]
    return '/' + virtualApp + '/systemHub';
}

function waitTime(refresh) {
    setTimeout(function () {
        refresh();
    }, 1500);
}