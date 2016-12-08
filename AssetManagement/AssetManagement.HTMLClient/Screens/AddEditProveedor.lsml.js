/// <reference path="../GeneratedArtifacts/viewModel.js" />

myapp.AddEditProveedor.GetRIFFromSeniat_execute = function (screen) {
    myapp.AddEditProveedor.NumeroRif = screen.Proveedor.RIF;
    if (myapp.AddEditProveedor.NumeroRif === undefined) {
        alert("Por favor escriba el RIF para buscar los datos en el portal del seniat.");
    } else {
        msls.promiseOperation(GetRIFFromSeniat).then(function PromiseSeccess(PromiseResult) {
            screen.Proveedor.RIF = PromiseResult.Numero;
            screen.Proveedor.Nombre = PromiseResult.Nombre;
        }).done(null, function () {
            alert("RIF inválido. Por favor verifique.");
        }, null);
    }
};

function GetRIFFromSeniat(operation) {
    $.ajax({
        type: 'post',
        data: { rif: myapp.AddEditProveedor.NumeroRif },
        url: '../GetRifFromSeniat.ashx',
        success: operation.code(function AjaxSeccess(AjaxResult) {
            operation.complete(AjaxResult);
        })
    });
}