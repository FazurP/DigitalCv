$(document).ready(function () {

    $('#ddlTipoProducto').prop('disabled', true);
    $('#txtResumenProyecto').prop('disabled', true);
    $('#txtObjetivo').prop('disabled', true);
    $('#ddlProgramaEducativo').prop('disabled', true);
    $('#dteFechaInicio').prop('disabled', true);
    $('#dteFechaTermino').prop('disabled', true);
    $('#txtNumeroAlumnos').prop('disabled', true);
    $('#txtNumeroHoras').prop('disabled', true);
    $('#txtNombreEmpresa').prop('disabled', true);
    $('#txtPuntosCriticos').prop('disabled', true);
    $('#txtLogros').prop('disabled', true);
    $('#ddlEstadoEstadia').prop('disabled', true);
    $('#inputFileUpload').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);

    $('#txtNombreEstadia').keyup(function () {

        let data = $(this).val();

        if (data = null || data == "" || data == '') {

            $('#ddlTipoProducto').prop('disabled', true);
            $('#txtResumenProyecto').prop('disabled', true);
            $('#txtObjetivo').prop('disabled', true);
            $('#ddlProgramaEducativo').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#txtNumeroAlumnos').prop('disabled', true);
            $('#txtNumeroHoras').prop('disabled', true);
            $('#txtNombreEmpresa').prop('disabled', true);
            $('#txtPuntosCriticos').prop('disabled', true);
            $('#txtLogros').prop('disabled', true);
            $('#ddlEstadoEstadia').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ddlTipoProducto').val(0);
            $('#txtResumenProyecto').val('');
            $('#txtObjetivo').val('');
            $('#ddlProgramaEducativo').val(0);
            $('#dteFechaInicio').val('');
            $('#dteFechaTermino').val('');
            $('#txtNumeroAlumnos').val('');
            $('#txtNumeroHoras').val('');
            $('#txtNombreEmpresa').val('');
            $('#txtPuntosCriticos').val('');
            $('#txtLogros').val('');
            $('#ddlEstadoEstadia').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');

        } else
        {
            $('#ddlTipoProducto').prop('disabled',false);
        }


    })

    $('#ddlTipoProducto').change(function () {

        let data = $(this).val();

        if (data = null || data == 0 || data == "0" || data == '0') {

            $('#txtResumenProyecto').prop('disabled', true);
            $('#txtObjetivo').prop('disabled', true);
            $('#ddlProgramaEducativo').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#txtNumeroAlumnos').prop('disabled', true);
            $('#txtNumeroHoras').prop('disabled', true);
            $('#txtNombreEmpresa').prop('disabled', true);
            $('#txtPuntosCriticos').prop('disabled', true);
            $('#txtLogros').prop('disabled', true);
            $('#ddlEstadoEstadia').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#txtResumenProyecto').val('');
            $('#txtObjetivo').val('');
            $('#ddlProgramaEducativo').val(0);
            $('#dteFechaInicio').val('');
            $('#dteFechaTermino').val('');
            $('#txtNumeroAlumnos').val('');
            $('#txtNumeroHoras').val('');
            $('#txtNombreEmpresa').val('');
            $('#txtPuntosCriticos').val('');
            $('#txtLogros').val('');
            $('#ddlEstadoEstadia').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');

        } else {
            toastr.success('Tipo de Producto Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#txtResumenProyecto').prop('disabled', false);
        }


    })

    $('#txtResumenProyecto').keyup(function () {

        let data = $(this).val();

        if (data = null || data == "" || data == '') {

            $('#txtObjetivo').prop('disabled', true);
            $('#ddlProgramaEducativo').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#txtNumeroAlumnos').prop('disabled', true);
            $('#txtNumeroHoras').prop('disabled', true);
            $('#txtNombreEmpresa').prop('disabled', true);
            $('#txtPuntosCriticos').prop('disabled', true);
            $('#txtLogros').prop('disabled', true);
            $('#ddlEstadoEstadia').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#txtObjetivo').val('');
            $('#ddlProgramaEducativo').val(0);
            $('#dteFechaInicio').val('');
            $('#dteFechaTermino').val('');
            $('#txtNumeroAlumnos').val('');
            $('#txtNumeroHoras').val('');
            $('#txtNombreEmpresa').val('');
            $('#txtPuntosCriticos').val('');
            $('#txtLogros').val('');
            $('#ddlEstadoEstadia').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');

        } else {
            $('#txtObjetivo').prop('disabled', false);
        }


    })

    $('#txtObjetivo').keyup(function () {

        let data = $(this).val();

        if (data = null || data == "" || data == '') {

            $('#ddlProgramaEducativo').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#txtNumeroAlumnos').prop('disabled', true);
            $('#txtNumeroHoras').prop('disabled', true);
            $('#txtNombreEmpresa').prop('disabled', true);
            $('#txtPuntosCriticos').prop('disabled', true);
            $('#txtLogros').prop('disabled', true);
            $('#ddlEstadoEstadia').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ddlProgramaEducativo').val(0);
            $('#dteFechaInicio').val('');
            $('#dteFechaTermino').val('');
            $('#txtNumeroAlumnos').val('');
            $('#txtNumeroHoras').val('');
            $('#txtNombreEmpresa').val('');
            $('#txtPuntosCriticos').val('');
            $('#txtLogros').val('');
            $('#ddlEstadoEstadia').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');

        } else {
            $('#ddlProgramaEducativo').prop('disabled', false);
        }


    })

    $('#ddlProgramaEducativo').change(function () {

        let data = $(this).val();

        if (data = null || data == 0 || data == "0" || data == '0') {

            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#txtNumeroAlumnos').prop('disabled', true);
            $('#txtNumeroHoras').prop('disabled', true);
            $('#txtNombreEmpresa').prop('disabled', true);
            $('#txtPuntosCriticos').prop('disabled', true);
            $('#txtLogros').prop('disabled', true);
            $('#ddlEstadoEstadia').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#dteFechaInicio').val('');
            $('#dteFechaTermino').val('');
            $('#txtNumeroAlumnos').val('');
            $('#txtNumeroHoras').val('');
            $('#txtNombreEmpresa').val('');
            $('#txtPuntosCriticos').val('');
            $('#txtLogros').val('');
            $('#ddlEstadoEstadia').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');

        } else {
            toastr.success('Programa Educativo Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#dteFechaInicio').prop('disabled', false);
        }


    })

    $('#dteFechaInicio').change(function () {

        let data = $(this).val();

        if (data = null || data == "" || data == '') {

            $('#dteFechaTermino').prop('disabled', true);
            $('#txtNumeroAlumnos').prop('disabled', true);
            $('#txtNumeroHoras').prop('disabled', true);
            $('#txtNombreEmpresa').prop('disabled', true);
            $('#txtPuntosCriticos').prop('disabled', true);
            $('#txtLogros').prop('disabled', true);
            $('#ddlEstadoEstadia').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#dteFechaTermino').val('');
            $('#txtNumeroAlumnos').val('');
            $('#txtNumeroHoras').val('');
            $('#txtNombreEmpresa').val('');
            $('#txtPuntosCriticos').val('');
            $('#txtLogros').val('');
            $('#ddlEstadoEstadia').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');

        } else {
            $('#dteFechaTermino').prop('disabled', false);
        }


    })

    $('#dteFechaTermino').change(function () {

        let data = $(this).val();

        if (data = null || data == "" || data == '') {

            $('#txtNumeroAlumnos').prop('disabled', true);
            $('#txtNumeroHoras').prop('disabled', true);
            $('#txtNombreEmpresa').prop('disabled', true);
            $('#txtPuntosCriticos').prop('disabled', true);
            $('#txtLogros').prop('disabled', true);
            $('#ddlEstadoEstadia').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#txtNumeroAlumnos').val('');
            $('#txtNumeroHoras').val('');
            $('#txtNombreEmpresa').val('');
            $('#txtPuntosCriticos').val('');
            $('#txtLogros').val('');
            $('#ddlEstadoEstadia').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');

        } else {
            $('#txtNumeroAlumnos').prop('disabled', false);
        }


    })

    $('#txtNumeroAlumnos').keyup(function () {

        let data = $(this).val();

        if (data = null || data == "" || data == '') {

            $('#txtNumeroHoras').prop('disabled', true);
            $('#txtNombreEmpresa').prop('disabled', true);
            $('#txtPuntosCriticos').prop('disabled', true);
            $('#txtLogros').prop('disabled', true);
            $('#ddlEstadoEstadia').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#txtNumeroHoras').val('');
            $('#txtNombreEmpresa').val('');
            $('#txtPuntosCriticos').val('');
            $('#txtLogros').val('');
            $('#ddlEstadoEstadia').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');

        } else {
            $('#txtNumeroHoras').prop('disabled', false);
        }


    })

    $('#txtNumeroHoras').keyup(function () {

        let data = $(this).val();

        if (data = null || data == "" || data == '') {

            $('#txtNombreEmpresa').prop('disabled', true);
            $('#txtPuntosCriticos').prop('disabled', true);
            $('#txtLogros').prop('disabled', true);
            $('#ddlEstadoEstadia').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#txtNombreEmpresa').val('');
            $('#txtPuntosCriticos').val('');
            $('#txtLogros').val('');
            $('#ddlEstadoEstadia').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');

        } else {
            $('#txtNombreEmpresa').prop('disabled', false);
        }


    })

    $('#txtNombreEmpresa').keyup(function () {

        let data = $(this).val();

        if (data = null || data == "" || data == '') {

            $('#txtPuntosCriticos').prop('disabled', true);
            $('#txtLogros').prop('disabled', true);
            $('#ddlEstadoEstadia').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#txtPuntosCriticos').val('');
            $('#txtLogros').val('');
            $('#ddlEstadoEstadia').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');

        } else {
            $('#txtPuntosCriticos').prop('disabled', false);
        }


    })

    $('#txtPuntosCriticos').keyup(function () {

        let data = $(this).val();

        if (data = null || data == "" || data == '') {

            $('#txtLogros').prop('disabled', true);
            $('#ddlEstadoEstadia').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#txtLogros').val('');
            $('#ddlEstadoEstadia').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');

        } else {
            $('#txtLogros').prop('disabled', false);
        }


    })

    $('#txtLogros').keyup(function () {

        let data = $(this).val();

        if (data = null || data == "" || data == '') {

            $('#ddlEstadoEstadia').prop('disabled', true);
            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ddlEstadoEstadia').get(0).selectedIndex = 0;
            $('#inputFileUpload').val('');

        } else {
            $('#ddlEstadoEstadia').prop('disabled', false);
        }


    })

    $('#ddlEstadoEstadia').change(function () {

        let data = $(this).get(0).selectedIndex;

        if (data = null || data == 0 || data == "0" || data == '0') {

            $('#inputFileUpload').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#inputFileUpload').val('');

        } else {
            toastr.success('Estado de la Estadia Seleccionada', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#inputFileUpload').prop('disabled', false);
        }


    })

    $('#inputFileUpload').change(function () {

        let data = $(this).val();

        if (data = null || data == "" || data == '') {

            $('#btnGuardar').prop('disabled', true);

        } else {
            $('#btnGuardar').prop('disabled', false);
        }
    })
});