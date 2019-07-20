$(document).ready(function () {

    $('#ddlGrado').prop('disabled', true);
    $('#FechaInicio').prop('disabled', true);
    $('#FechaTermino').prop('disabled', true);
    $('#txtNumeroAlumnos').prop('disabled', true);
    $('#ddlEstadoDireccion').prop('disabled', true);
    $('#ddlInstitucionSuperior').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);

    $('#txtTituloTesis').keyup(function () {

        let data = $(this).val();

        if (data == null || data == '' || data == "") {
            $('#ddlGrado').prop('disabled', true);
            $('#FechaInicio').prop('disabled', true);
            $('#FechaTermino').prop('disabled', true);
            $('#txtNumeroAlumnos').prop('disabled', true);
            $('#ddlEstadoDireccion').prop('disabled', true);
            $('#ddlInstitucionSuperior').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ddlGrado').val(0);
            $('#FechaInicio').val('');
            $('#FechaTermino').val('');
            $('#txtNumeroAlumnos').val('');
            $('#ddlEstadoDireccion').get(0).selectedIndex = 0;
            $('#ddlInstitucionSuperior').val(0);
        } else
        {
            $('#ddlGrado').prop('disabled', false);
        }

    })

    $('#ddlGrado').change(function () {

        let data = $(this).val();

        if (data == null || data == 0 || data == '0' || data == "0") {
            $('#FechaInicio').prop('disabled', true);
            $('#FechaTermino').prop('disabled', true);
            $('#txtNumeroAlumnos').prop('disabled', true);
            $('#ddlEstadoDireccion').prop('disabled', true);
            $('#ddlInstitucionSuperior').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#FechaInicio').val('');
            $('#FechaTermino').val('');
            $('#txtNumeroAlumnos').val('');
            $('#ddlEstadoDireccion').get(0).selectedIndex = 0;
            $('#ddlInstitucionSuperior').val(0);
        } else {
            toastr.success('Grado Academico Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#FechaInicio').prop('disabled', false);
        }

    })

    $('#FechaInicio').change(function () {

        let data = $(this).val();

        if (data == null || data == '' || data == "") {
            $('#FechaTermino').prop('disabled', true);
            $('#txtNumeroAlumnos').prop('disabled', true);
            $('#ddlEstadoDireccion').prop('disabled', true);
            $('#ddlInstitucionSuperior').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#FechaTermino').val('');
            $('#txtNumeroAlumnos').val('');
            $('#ddlEstadoDireccion').get(0).selectedIndex = 0;
            $('#ddlInstitucionSuperior').val(0);
        } else {
            $('#FechaTermino').prop('disabled', false);
        }

    })

    $('#FechaTermino').change(function () {

        let data = $(this).val();

        if (data == null || data == '' || data == "") {
            $('#txtNumeroAlumnos').prop('disabled', true);
            $('#ddlEstadoDireccion').prop('disabled', true);
            $('#ddlInstitucionSuperior').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#txtNumeroAlumnos').val('');
            $('#ddlEstadoDireccion').get(0).selectedIndex = 0;
            $('#ddlInstitucionSuperior').val(0);
        } else {
            $('#txtNumeroAlumnos').prop('disabled', false);
        }

    })

    $('#txtNumeroAlumnos').keyup(function () {

        let data = $(this).val();

        if (data == null || data == '' || data == "") {
            $('#ddlEstadoDireccion').prop('disabled', true);
            $('#ddlInstitucionSuperior').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ddlEstadoDireccion').get(0).selectedIndex = 0;
            $('#ddlInstitucionSuperior').val(0);
        } else {
            $('#ddlEstadoDireccion').prop('disabled', false);
        }

    })

    $('#ddlEstadoDireccion').change(function () {

        let data = $(this).get(0).selectedIndex;

        if (data == null || data == 0 || data == '0' || data == "0") {
            $('#ddlInstitucionSuperior').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ddlInstitucionSuperior').val(0);
        } else {
            toastr.success('Estado de la Direccion Individualizada Seleccionada', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#ddlInstitucionSuperior').prop('disabled', false);
        }

    })

    $('#ddlInstitucionSuperior').change(function () {

        let data = $(this).val();

        if (data == null || data == 0 || data == '0' || data == "0") {
            $('#btnGuardar').prop('disabled', true);

        } else {
            toastr.success('Institución Superior Seleccionada', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#btnGuardar').prop('disabled', false);
        }

    })
})
