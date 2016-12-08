/// <reference path="../GeneratedArtifacts/viewModel.js" />

myapp.ViewSoftware.Eliminar_execute = function (screen) {
    if (confirm('Desea eliminar el software?')) {
        screen.Software.deleteEntity();
        return myapp.commitChanges().then(null, function fail(e) {
            myapp.cancelChanges();
            throw e;
        });
    }
};