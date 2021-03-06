﻿$(document).ready(function ()
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
                $('#Institucion').empty();
                $('#Status').empty();
                $('#FuenteFinanciamiento').empty();
                break;

            case 1:

                url = "/digitalcv/HistorialAcademico/GetInstitucionAcreditanDoctorados";
                urlStatus = "/digitalcv/HistorialAcademico/GetStatusDoctorados";
                urlFuenteFinaciamiento = "/digitalcv/HistorialAcademico/GetFuentesFinanciamientoDoctorados"
                ////////////////////////////////////////////////////////
                $.get(url).done(function (response) {

                    $('#Institucion').empty();
                    $('#Institucion').append(response);

                }).fail(function () {
                    console.log("Service not available");
                });
                /////////////////////////////////////////////////////////
                $.get(urlStatus).done(function (response)
                {
                    $('#Status').empty();
                    $('#Status').append(response);
                }).fail(function ()
                {
                    console.log("Service not available");
                });
                /////////////////////////////////////////////////////////
                $.get(urlFuenteFinaciamiento).done(function (response) {
                    $('#FuenteFinanciamiento').empty();
                    $('#FuenteFinanciamiento').append(response);
                }).fail(function () {
                    console.log("Service not available");
                });
                ///////////////////////////////////////////////////////
                $('#lblNombre').html("Nombre del Doctorado:");

                break;

            case 2:

                url = "/digitalcv/HistorialAcademico/GetInstitucionAcreditanMaestrias";
                urlStatus = "/digitalcv/HistorialAcademico/GetStatusMaestrias";
                urlFuenteFinanciamiento = "/digitalcv/HistorialAcademico/GetFuentesFinanciamientoMaestrias";
                //////////////////////////////////////////
                $.get(url).done(function (response) {

                    $('#Institucion').empty();
                    $('#Institucion').append(response);

                }).fail(function () {
                    console.log("Service not available");
                });
                //////////////////////////////////////////
                $.get(urlStatus).done(function (response) {

                    $('#Status').empty();
                    $('#Status').append(response);

                }).fail(function () {
                    console.log("Service not available");
                });
                /////////////////////////////////////////////////////////
                $.get(urlFuenteFinanciamiento).done(function (response) {

                    $('#FuenteFinanciamiento').empty();
                    $('#FuenteFinanciamiento').append(response);

                }).fail(function () {
                    console.log("Service not available");
                });
                //////////////////////////////////////////////
                $('#lblNombre').html("Nombre de la Maestria:");

                break;

            case 3:
                url = "/digitalcv/HistorialAcademico/GetInstitucionAcreditanLicenciaturaIng";
                url2 = "/digitalcv/HistorialAcademico/GetStatusLicenciaturasIng";

                $.get(url).done(function (response) {

                    $('#Institucion').empty();
                    $('#Institucion').append(response);

                }).fail(function () {
                    console.log("Service not available");
                });

                $.get(url2).done(function (response) {
                
                    $('#Status').empty();
                    $('#Status').append(response);

                }).fail(function () {
                    console.log("Service not available");
                });


                $('#lblNombre').html("Nombre de la Ingenieria:");
                break;

            case 4:
                url = "/digitalcv/HistorialAcademico/GetInstitucionAcreditanLicenciaturaIng";
                url2 = "/digitalcv/HistorialAcademico/GetStatusLicenciaturasIng";

                $.get(url).done(function (response) {

                    $('#Institucion').empty();
                    $('#Institucion').append(response);

                }).fail(function () {
                    console.log("Service not available");
                });

                $.get(url2).done(function (response) {

                    $('#Status').empty();
                    $('#Status').append(response);

                }).fail(function () {
                    console.log("Service not available");
                });

                $('#lblNombre').html("Nombre de la Licenciatura:");
                break;
            case 5:
                $('#lblNombre').html("Institución que lo Acredita:");
                break;

            default:

                break;
        }
    });

});