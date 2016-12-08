/// <reference path="../GeneratedArtifacts/viewModel.js" />

myapp.ViewLicencia.Eliminar_execute = function (screen) {
    if (confirm('Desea eliminar la licencia?')) {
        screen.Licencia.deleteEntity();
        return myapp.commitChanges().then(null, function fail(e) {
            myapp.cancelChanges();
            throw e;
        });
    }
};