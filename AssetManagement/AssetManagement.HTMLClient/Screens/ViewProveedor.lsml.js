/// <reference path="../GeneratedArtifacts/viewModel.js" />

myapp.ViewProveedor.Eliminar_execute = function (screen) {
    if (confirm('Desea eliminar el proveedor?')) {
        screen.Proveedor.deleteEntity();
        return myapp.commitChanges().then(null, function fail(e) {
            myapp.cancelChanges();
            throw e;
        });
    }
};