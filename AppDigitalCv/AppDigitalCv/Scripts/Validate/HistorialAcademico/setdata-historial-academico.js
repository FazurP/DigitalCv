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

                $.get(url).done(function (response) {
               
                    $('#InstitucionAcredita').append(response);

                }).fail(function () {
                    console.log("Service not available");
                });

                $('#lblNombre').html("Nombre del Doctorado:");

                break;

            case 2:
                 url = "/HistorialAcademico/GetInstitucionAcreditanMaestrias";

                $.get(url).done(function (response) {

                    $('#InstitucionAcredita').append(response);

                }).fail(function () {
                    console.log("Service not available");
                });

                $('#lblNombre').html("Nombre de la Maestria:");
                break;

            case 3:
                url = "/HistorialAcademico/GetInstitucionAcreditanLicenciaturaIng";

                $.get(url).done(function (response) {

                    $('#InstitucionAcredita').append(response);

                }).fail(function () {
                    console.log("Service not available");
                });

                $('#lblNombre').html("Nombre de la Ingenieria:");
                break;

            case 4:
                url = "/HistorialAcademico/GetInstitucionAcreditanLicenciaturaIng";

                $.get(url).done(function (response) {

                    $('#InstitucionAcredita').append(response);

                }).fail(function () {
                    console.log("Service not available");
                });

                $('#lblNombre').html("Nombre de la Licenciatura:");
                break;

            case 5:

                $('#NombreEstudio').prop("disabled", true);
                $('#InstitucionAcredita').remove();
                $('#txt').append("<input type=" + 'text' + " class=" +'form-control input-smform-control input-sm'+"/>")
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