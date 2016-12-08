/// <reference path="../GeneratedArtifacts/viewModel.js" />

myapp.ReportLicenciasDisponibles.Group_render = function (element, contentItem) {
    $("<div id='loading'><h1>&nbsp;&nbsp;&nbsp;&nbsp;Loading Report...</h1></div>").appendTo($(element));
    var reportViewer = $("<div></div>").html("<object width='650px' height='650px' data='../reports/ReportViewer.aspx?ReportName=LicenciasDisponibles'/>");
    reportViewer.css({
        "margin-top": "-50px"
    });
    reportViewer.appendTo($(element));
};