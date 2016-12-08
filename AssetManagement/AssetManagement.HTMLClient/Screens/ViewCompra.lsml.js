/// <reference path="../GeneratedArtifacts/viewModel.js" />

myapp.ViewCompra.Delete_execute = function (screen) {
    if (confirm('Desea eliminar la compra?')) {
        screen.Compra.deleteEntity();
        return myapp.commitChanges().then(null, function fail(e) {
            myapp.cancelChanges();
            throw e;
        });
    }
};