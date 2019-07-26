$(document).ready(function () {

    $('#ddlNivel').prop('disabled', true);
    $('#ddlProgramaEducativo').prop('disabled', true);
    $('#txtNumeroEstudiantes').prop('disabled', true);
    $('#txtNombreEstudiante').prop('disabled', true);
    $('#dteFechaInicio').prop('disabled', true);
    $('#dteFechaTermino').prop('disabled', true);
    $('#ddlTipo').prop('disabled', true);
    $('#ddlEstadoTutoria').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);

    $('#ddlTutoria').change(function () {

        let data = $(this).get(0).selectedIndex;

        if (data == null || data == 0 || data == "0" || data == '0') {
            $('#ddlNivel').prop('disabled', true);
            $('#ddlProgramaEducativo').prop('disabled', true);
            $('#txtNumeroEstudiantes').prop('disabled', true);
            $('#txtNombreEstudiante').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#ddlTipo').prop('disabled', true);
            $('#ddlEstadoTutoria').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ddlNivel').val(0);
            $('#ddlProgramaEducativo').val(0);
            $('#txtNumeroEstudiantes').val('');
            $('#txtNombreEstudiante').val('');
            $('#dteFechaInicio').val('');
            $('#dteFechaTermino').val('');
            $('#ddlTipo').get(0).selectedIndex = 0;
            $('#ddlEstadoTutoria').get(0).selectedIndex = 0;
        } else
        {
            toastr.success('Tutoria Seleccionada', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#ddlNivel').prop('disabled',false);
        }

    })

    $('#ddlNivel').change(function () {

        let data = $(this).val();

        if (data == null || data == 0 || data == "0" || data == '0') {
            $('#ddlProgramaEducativo').prop('disabled', true);
            $('#txtNumeroEstudiantes').prop('disabled', true);
            $('#txtNombreEstudiante').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#ddlTipo').prop('disabled', true);
            $('#ddlEstadoTutoria').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ddlProgramaEducativo').val(0);
            $('#txtNumeroEstudiantes').val('');
            $('#txtNombreEstudiante').val('');
            $('#dteFechaInicio').val('');
            $('#dteFechaTermino').val('');
            $('#ddlTipo').get(0).selectedIndex = 0;
            $('#ddlEstadoTutoria').get(0).selectedIndex = 0;
        } else {
            toastr.success('Nivel Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#ddlProgramaEducativo').prop('disabled', false);
        }

    })

    $('#ddlProgramaEducativo').change(function () {

        let data = $(this).val();

        if (data == null || data == 0 || data == "0" || data == '0') {
            $('#txtNumeroEstudiantes').prop('disabled', true);
            $('#txtNombreEstudiante').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#ddlTipo').prop('disabled', true);
            $('#ddlEstadoTutoria').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#txtNumeroEstudiantes').val('');
            $('#txtNombreEstudiante').val('');
            $('#dteFechaInicio').val('');
            $('#dteFechaTermino').val('');
            $('#ddlTipo').get(0).selectedIndex = 0;
            $('#ddlEstadoTutoria').get(0).selectedIndex = 0;
        } else {
            toastr.success('Programa Educativo Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#txtNumeroEstudiantes').prop('disabled', false);
        }

    })

    $('#txtNumeroEstudiantes').keyup(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {
            $('#txtNombreEstudiante').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#ddlTipo').prop('disabled', true);
            $('#ddlEstadoTutoria').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#txtNombreEstudiante').val('');
            $('#dteFechaInicio').val('');
            $('#dteFechaTermino').val('');
            $('#ddlTipo').get(0).selectedIndex = 0;
            $('#ddlEstadoTutoria').get(0).selectedIndex = 0;
        } else {
            $('#txtNombreEstudiante').prop('disabled', false);
        }

    })

    $('#txtNombreEstudiante').keyup(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#ddlTipo').prop('disabled', true);
            $('#ddlEstadoTutoria').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#dteFechaInicio').val('');
            $('#dteFechaTermino').val('');
            $('#ddlTipo').get(0).selectedIndex = 0;
            $('#ddlEstadoTutoria').get(0).selectedIndex = 0;
        } else {
            $('#dteFechaInicio').prop('disabled', false);
        }

    })

    $('#dteFechaInicio').change(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {
            $('#dteFechaTermino').prop('disabled', true);
            $('#ddlTipo').prop('disabled', true);
            $('#ddlEstadoTutoria').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#dteFechaTermino').val('');
            $('#ddlTipo').get(0).selectedIndex = 0;
            $('#ddlEstadoTutoria').get(0).selectedIndex = 0;
        } else {
            $('#dteFechaTermino').prop('disabled', false);
        }

    })

    $('#dteFechaTermino').change(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {
            $('#ddlTipo').prop('disabled', true);
            $('#ddlEstadoTutoria').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ddlTipo').get(0).selectedIndex = 0;
            $('#ddlEstadoTutoria').get(0).selectedIndex = 0;
        } else {
            $('#ddlTipo').prop('disabled', false);
        }

    })

    $('#ddlTipo').change(function () {

        let data = $(this).get(0).selectedIndex;

        if (data == null || data == 0 ||  data == "0" || data == '0') {
            $('#ddlEstadoTutoria').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ddlEstadoTutoria').get(0).selectedIndex = 0;
        } else {
            toastr.success('Tipo de la Tutoria Seleccionada', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#ddlEstadoTutoria').prop('disabled', false);
        }
    })

    $('#ddlEstadoTutoria').change(function () {

        let data = $(this).get(0).selectedIndex;

        if (data == null || data == 0 || data == "0" || data == '0') {
            $('#btnGuardar').prop('disabled', true);

        } else {
            toastr.success('Estado de la Tutoria Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#btnGuardar').prop('disabled', false);
        }
    })
})