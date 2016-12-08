/// <reference path="../GeneratedArtifacts/viewModel.js" />

myapp.ViewComputador.Delete_execute = function (screen) {
    if (confirm('Desea eliminar el computador?')) {
        screen.Computador.deleteEntity();
        return myapp.commitChanges().then(null, function fail(e) {
            myapp.cancelChanges();
            throw e;
        });
    }
};