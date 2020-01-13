$(document).ready(function ()
{
    let gradoAcademico = ["Seleccionar","Doctorado", "Maestria", "Ingenieria", "Licenciatura", "Bachillerato"];

    for (var i = 0; i < gradoAcademico.length; i++) {
        $('#NivelEstudio').append("<option value=" + i + ">" + gradoAcademico[i] + "</option>");
    }

});