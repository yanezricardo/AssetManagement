/// <reference path="../GeneratedArtifacts/viewModel.js" />

myapp.Software.prototype.getLicenciasAutorizadas = function () {
    var promise = this.getLicencia();
    promise.then(function (value) {
        var result = 0;
        value.each(function (item) {
            result = result + item.Autorizadas;
            return true;
        })
        return result;
    });
    return promise;
};
myapp.Software.prototype.getLicenciasUsadas = function () {
    return this.Licencia.sum(function (i) {
        i.Autorizadas
    });
};
myapp.Software.prototype.getLicenciasDisponibles = function () {
    return this.Licencia.sum(function (i) {
        i.Autorizadas
    });
};
