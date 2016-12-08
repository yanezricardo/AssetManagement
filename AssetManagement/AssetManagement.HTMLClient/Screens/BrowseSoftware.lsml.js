/// <reference path="../GeneratedArtifacts/viewModel.js" />

myapp.BrowseSoftware.RowTemplate_postRender = function (element, contentItem) {
    var software = contentItem.value;
    if (software != null) {
        var promise = software.getLicencia();
        promise.then(function (value) {
            var autorizadas = 0;
            var usadas = 0;
            value.each(function (item) {
                var n = 0;
                item.LicenciaRegistradas.each(function (i) { n++ });
                autorizadas += item.Autorizadas;
                usadas += n;
            });
            if (autorizadas === undefined || isNaN(autorizadas)) {
                autorizadas = 0;
            }
            if (usadas === undefined || isNaN(usadas)) {
                usadas = 0;
            }
            element.children.item(4).textContent = autorizadas;
            element.children.item(5).textContent = usadas;
            element.children.item(6).textContent = autorizadas - usadas;
        });
    }
};

myapp.BrowseSoftware.Software_postRender = function (element, contentItem) {
    contentItem.addChangeListener(null, function () {
        contentItem.value.refresh()
    });
};