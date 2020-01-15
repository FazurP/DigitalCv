$(document).ready(function ()
{
    let gradoAcademico = ["Seleccionar","Doctorado", "Maestria", "Ingenieria", "Licenciatura", "Bachillerato"];

    for (var i = 0; i < gradoAcademico.length; i++) {
        $('#NivelEstudio').append("<option value=" + i + ">" + gradoAcademico[i] + "</option>");
    }

    $('#NivelEstudio').change(function ()
    {
        let data = $(this).get(0).selectedIndex;
        let url
        switch (data) {
            
            case 0:
                $('#lblNombre').html("Nombre:");
                $('#InstitucionAcredita').empty();
                break;

            case 1:
                url = "/HistorialAcademico/GetInstitucionAcreditanDoctorados";
                urlStatus = "/HistorialAcademico/GetStatusDoctorados";
                urlFuenteFinaciamiento = "/HistorialAcademico/GetFuentesFinanciamientoDoctorados"
                ///
                $.get(url).done(function (response) {

                    $('#InstitucionAcredita').empty();
                    $('#InstitucionAcredita').append(response);

                }).fail(function () {
                    console.log("Service not available");
                });
                ///
                $.get(urlStatus).done(function (response)
                {
                    $('#Status').empty();
                    $('#Status').append(response);
                }).fail(function ()
                {
                    console.log("Service not available");
                });
                ///
                $.get(urlFuenteFinaciamiento).done(function (response) {
                    $('#FuenteFinanciamiento').empty();
                    $('#FuenteFinanciamiento').append(response);
                }).fail(function () {
                    console.log("Service not available");
                });

                $('#lblNombre').html("Nombre del Doctorado:");

                break;

            case 2:
                 url = "/HistorialAcademico/GetInstitucionAcreditanMaestrias";

                $.get(url).done(function (response) {

                    $('#InstitucionAcredita').empty();
                    $('#InstitucionAcredita').append(response);

                }).fail(function () {
                    console.log("Service not available");
                });

                $('#lblNombre').html("Nombre de la Maestria:");
                break;

            case 3:
                url = "/HistorialAcademico/GetInstitucionAcreditanLicenciaturaIng";

                $.get(url).done(function (response) {

                    $('#InstitucionAcredita').empty();
                    $('#InstitucionAcredita').append(response);

                }).fail(function () {
                    console.log("Service not available");
                });

                $('#lblNombre').html("Nombre de la Ingenieria:");
                break;

            case 4:
                url = "/HistorialAcademico/GetInstitucionAcreditanLicenciaturaIng";

                $.get(url).done(function (response) {

                    $('#InstitucionAcredita').empty();
                    $('#InstitucionAcredita').append(response);

                }).fail(function () {
                    console.log("Service not available");
                });

                $('#lblNombre').html("Nombre de la Licenciatura:");
                break;

            case 5:

                $('#InstitucionAcredita').empty();
                $('#NombreEstudio').prop("disabled", true);
                $('#InstitucionAcredita').remove();
                $('#txt').append("@Html.TextBoxFor(model => model.strInstitucionAcredita, new { @class = "+'form-control input-sm", id = "NombreEstudio'+" })")
                $('#FuenteFinanciamiento').prop("disabled", true);
                $('#PNPCSi').prop("disabled", true);
                $('#PNPCNo').prop("disabled", true);

                $('#lblNombre').html("Nombre de la Licenciatura:");

                break;

            default:

                break;
        }
    });

});