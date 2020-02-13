$(document).ready(function () {
    $('#strNombreAlumno').prop('disabled', true);
    $('#strEstadoEstadia').prop('disabled', true);
    $('#dteFechaInicio').prop('disabled', true);
    $('#dteFechaTermino').prop('disabled', true);
    $('#strResumenProyecto').prop('disabled', true);
    $('#strObjetivo').prop('disabled', true);
    $('#strPuntosCriticosResolver').prop('disabled', true);
    $('#strLogrosBeneficiosObtenidos').prop('disabled', true);
    $('#idProgramaEducativo').prop('disabled', true);
    $('#file').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);


    $('#strNombreEmpresaInstitucion').keyup(function () {

        let data = $(this).val();
        if ($.isEmptyObject(data)) {
            $('#strNombreAlumno').prop('disabled', true);
            $('#strEstadoEstadia').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#strResumenProyecto').prop('disabled', true);
            $('#strObjetivo').prop('disabled', true);
            $('#strPuntosCriticosResolver').prop('disabled', true);
            $('#strLogrosBeneficiosObtenidos').prop('disabled', true);
            $('#idProgramaEducativo').prop('disabled', true);
            $('#file').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#strNombreAlumno').val("");
            $('#strEstadoEstadia').get(0).selectedIndex;
            $('#dteFechaInicio').val("");
            $('#dteFechaTermino').val("");
            $('#strResumenProyecto').val("");
            $('#strObjetivo').val("");
            $('#strPuntosCriticosResolver').val("");
            $('#strLogrosBeneficiosObtenidos').val("");
            $('#idProgramaEducativo').val(0);
            $('#file').val("");
        } else
        {
            $('#strNombreAlumno').prop('disabled', false);
        }
    });

    $('#strNombreAlumno').keyup(function () {

        let data = $(this).val();
        if ($.isEmptyObject(data)) {
            $('#strEstadoEstadia').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#strResumenProyecto').prop('disabled', true);
            $('#strObjetivo').prop('disabled', true);
            $('#strPuntosCriticosResolver').prop('disabled', true);
            $('#strLogrosBeneficiosObtenidos').prop('disabled', true);
            $('#idProgramaEducativo').prop('disabled', true);
            $('#file').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#strEstadoEstadia').get(0).selectedIndex;
            $('#dteFechaInicio').val("");
            $('#dteFechaTermino').val("");
            $('#strResumenProyecto').val("");
            $('#strObjetivo').val("");
            $('#strPuntosCriticosResolver').val("");
            $('#strLogrosBeneficiosObtenidos').val("");
            $('#idProgramaEducativo').val(0);
            $('#file').val("");
        } else {
            $('#strEstadoEstadia').prop('disabled', false);
        }
    });

    $('#strEstadoEstadia').change(function () {

        let data = $(this).get(0).selectedIndex;
        if (data == 0) {
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#strResumenProyecto').prop('disabled', true);
            $('#strObjetivo').prop('disabled', true);
            $('#strPuntosCriticosResolver').prop('disabled', true);
            $('#strLogrosBeneficiosObtenidos').prop('disabled', true);
            $('#idProgramaEducativo').prop('disabled', true);
            $('#file').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#dteFechaInicio').val("");
            $('#dteFechaTermino').val("");
            $('#strResumenProyecto').val("");
            $('#strObjetivo').val("");
            $('#strPuntosCriticosResolver').val("");
            $('#strLogrosBeneficiosObtenidos').val("");
            $('#idProgramaEducativo').val(0);
            $('#file').val("");
        } else {
            toastr.success("Estado de la Estadia Seleccionado", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#dteFechaInicio').prop('disabled', false);
        }
    });

    $('#dteFechaInicio').change(function () {

        let data = $(this).val();
        if ($.isEmptyObject(data)) {
            $('#dteFechaTermino').prop('disabled', true);
            $('#strResumenProyecto').prop('disabled', true);
            $('#strObjetivo').prop('disabled', true);
            $('#strPuntosCriticosResolver').prop('disabled', true);
            $('#strLogrosBeneficiosObtenidos').prop('disabled', true);
            $('#idProgramaEducativo').prop('disabled', true);
            $('#file').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#dteFechaTermino').val("");
            $('#strResumenProyecto').val("");
            $('#strObjetivo').val("");
            $('#strPuntosCriticosResolver').val("");
            $('#strLogrosBeneficiosObtenidos').val("");
            $('#idProgramaEducativo').val(0);
            $('#file').val("");
        } else {
            toastr.success("Fecha de Inicio Seleccionada", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#dteFechaTermino').prop('disabled', false);
        }
    });

    $('#dteFechaTermino').change(function () {

        let data = $(this).val();
        if ($.isEmptyObject(data)) {
            $('#strResumenProyecto').prop('disabled', true);
            $('#strObjetivo').prop('disabled', true);
            $('#strPuntosCriticosResolver').prop('disabled', true);
            $('#strLogrosBeneficiosObtenidos').prop('disabled', true);
            $('#idProgramaEducativo').prop('disabled', true);
            $('#file').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#strResumenProyecto').val("");
            $('#strObjetivo').val("");
            $('#strPuntosCriticosResolver').val("");
            $('#strLogrosBeneficiosObtenidos').val("");
            $('#idProgramaEducativo').val(0);
            $('#file').val("");
        } else {
            toastr.success("Fecha de Termino Seleccionada", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#strResumenProyecto').prop('disabled', false);
        }
    });

    $('#strResumenProyecto').keyup(function () {

        let data = $(this).val();
        if ($.isEmptyObject(data)) {
            $('#strObjetivo').prop('disabled', true);
            $('#strPuntosCriticosResolver').prop('disabled', true);
            $('#strLogrosBeneficiosObtenidos').prop('disabled', true);
            $('#idProgramaEducativo').prop('disabled', true);
            $('#file').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#strObjetivo').val("");
            $('#strPuntosCriticosResolver').val("");
            $('#strLogrosBeneficiosObtenidos').val("");
            $('#idProgramaEducativo').val(0);
            $('#file').val("");
        } else {
            $('#strObjetivo').prop('disabled', false);
        }
    });

    $('#strObjetivo').keyup(function () {

        let data = $(this).val();
        if ($.isEmptyObject(data)) {
            $('#strPuntosCriticosResolver').prop('disabled', true);
            $('#strLogrosBeneficiosObtenidos').prop('disabled', true);
            $('#idProgramaEducativo').prop('disabled', true);
            $('#file').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#strPuntosCriticosResolver').val("");
            $('#strLogrosBeneficiosObtenidos').val("");
            $('#idProgramaEducativo').val(0);
            $('#file').val("");
        } else {
            $('#strPuntosCriticosResolver').prop('disabled', false);
        }
    });

    $('#strPuntosCriticosResolver').keyup(function () {

        let data = $(this).val();
        if ($.isEmptyObject(data)) {
            $('#strLogrosBeneficiosObtenidos').prop('disabled', true);
            $('#idProgramaEducativo').prop('disabled', true);
            $('#file').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#strLogrosBeneficiosObtenidos').val("");
            $('#idProgramaEducativo').val(0);
            $('#file').val("");
        } else {
            $('#strLogrosBeneficiosObtenidos').prop('disabled', false);
        }
    });

    $('#strLogrosBeneficiosObtenidos').keyup(function () {

        let data = $(this).val();
        if ($.isEmptyObject(data)) {
            $('#idProgramaEducativo').prop('disabled', true);
            $('#file').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#idProgramaEducativo').val(0);
            $('#file').val("");
        } else {
            $('#idProgramaEducativo').prop('disabled', false);
        }
    });

    $('#idProgramaEducativo').change(function () {

        let data = $(this).val();
        if (data == 0) {
            $('#file').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#file').val("");
        } else {
            toastr.success("Programa Educativo Seleccionado", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#file').prop('disabled', false);
        }
    });
});