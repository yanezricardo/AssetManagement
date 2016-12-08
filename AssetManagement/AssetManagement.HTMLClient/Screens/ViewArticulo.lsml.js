/// <reference path="../GeneratedArtifacts/viewModel.js" />

myapp.ViewArticulo.Delete_execute = function (screen) {
    if (confirm('Desea eliminar el artículo?')) {
        screen.Articulo.deleteEntity();
        return myapp.commitChanges().then(null, function fail(e) {
            myapp.cancelChanges();
            throw e;
        });
    }
};