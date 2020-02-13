$(document).ready(function () {


    $('#txtNombreEstudiante').prop('disabled', true);
    $('#ddlTipo').prop('disabled', true);
    $('#txtHoras').prop('disabled', true);
    $('#dteFechaInicio').prop('disabled', true);
    $('#dteFechaTermino').prop('disabled', true);
    $('#ddlEstadoTutoria').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);

    $('#ddlProgramaEducativo').change(function () {

        let data = $(this).val();

        if (data == 0) {
            $('#txtNombreEstudiante').prop('disabled', true);
            $('#ddlTipo').prop('disabled', true);
            $('#txtHoras').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#ddlEstadoTutoria').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#txtNombreEstudiante').val("");
            $('#ddlTipo').get(0).selectedIndex = 0;
            $('#txtHoras').val("");
            $('#dteFechaInicio').val("");
            $('#dteFechaTermino').val("");
            $('#ddlEstadoTutoria').get(0).selectedIndex = 0;
        } else
        {
            toastr.success("Programa Educativo Seleccionado", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#txtNombreEstudiante').prop('disabled', false);
        }

    });

    $('#txtNombreEstudiante').keyup(function () {

        let data = $(this).val();

        if (data == "") {
            $('#ddlTipo').prop('disabled', true);
            $('#txtHoras').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#ddlEstadoTutoria').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ddlTipo').get(0).selectedIndex = 0;
            $('#txtHoras').val("");
            $('#dteFechaInicio').val("");
            $('#dteFechaTermino').val("");
            $('#ddlEstadoTutoria').get(0).selectedIndex = 0;
        } else {
            $('#ddlTipo').prop('disabled', false);
        }

    });

    $('#ddlTipo').change(function () {

        let data = $(this).get(0).selectedIndex;

        if (data == 0) {
            $('#txtHoras').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#ddlEstadoTutoria').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#txtHoras').val("");
            $('#dteFechaInicio').val("");
            $('#dteFechaTermino').val("");
            $('#ddlEstadoTutoria').get(0).selectedIndex = 0;
        } else {
            toastr.success("Tipo de Tutoria Seleccionada", "Digital-Cv dice", { closeButton: true, timeOut:1000 });
            $('#txtHoras').prop('disabled', false);
        }

    });

    $('#txtHoras').keyup(function () {

        let data = $(this).val();

        if (data == "") {
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#ddlEstadoTutoria').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#dteFechaInicio').val("");
            $('#dteFechaTermino').val("");
            $('#ddlEstadoTutoria').get(0).selectedIndex = 0;
        } else {
            $('#dteFechaInicio').prop('disabled', false);
        }

    });

    $('#dteFechaInicio').change(function () {

        let data = $(this).val();

        if (data == "") {
            $('#dteFechaTermino').prop('disabled', true);
            $('#ddlEstadoTutoria').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#dteFechaTermino').val("");
            $('#ddlEstadoTutoria').get(0).selectedIndex = 0;
        } else {
            toastr.success("Fecha de Inicio Seleccionada", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#dteFechaTermino').prop('disabled', false);
        }

    });

    $('#dteFechaTermino').change(function () {

        let data = $(this).val();

        if (data == "") {
            $('#ddlEstadoTutoria').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ddlEstadoTutoria').get(0).selectedIndex = 0;
        } else {
            toastr.success("Fecha de Termino Seleccionada", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#ddlEstadoTutoria').prop('disabled', false);
        }

    });

    $('#ddlEstadoTutoria').change(function () {

        let data = $(this).get(0).selectedIndex;

        if (data == 0) {
            $('#btnGuardar').prop('disabled', true);

        } else {
            toastr.success("Estado de la Tutoria Seleccionado", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#btnGuardar').prop('disabled', false);
        }

    });
    
})