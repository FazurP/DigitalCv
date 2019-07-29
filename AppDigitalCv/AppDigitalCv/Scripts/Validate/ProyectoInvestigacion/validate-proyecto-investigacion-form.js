$(document).ready(function () {

    $('#txtNombrePatrocinador').prop('disabled', true);
    $('#dteFechaInicio').prop('disabled', true);
    $('#dteFechaFin').prop('disabled', true);
    $('#ddlTipoPatrocinador').prop('disabled', true);
    $('#txtInvestigadores').prop('disabled', true);
    $('#txtAlumnos').prop('disabled', true);
    $('#txtActividades').prop('disabled', true);
    $('#txtConvocatoria').prop('disabled', true);
    $('#inputFileUploadResumen').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);


    $('#txtTituloProyecto').keyup(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {

            $('#txtNombrePatrocinador').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaFin').prop('disabled', true);
            $('#ddlTipoPatrocinador').prop('disabled', true);
            $('#txtInvestigadores').prop('disabled', true);
            $('#txtAlumnos').prop('disabled', true);
            $('#txtActividades').prop('disabled', true);
            $('#txtConvocatoria').prop('disabled', true);
            $('#inputFileUploadResumen').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#txtNombrePatrocinador').val('');
            $('#dteFechaInicio').val('');
            $('#dteFechaFin').val('');
            $('#ddlTipoPatrocinador').get(0).selectedIndex = 0;
            $('#txtInvestigadores').val('');
            $('#txtAlumnos').val('');
            $('#txtActividades').val('');
            $('#txtConvocatoria').val('');
            $('#inputFileUploadResumen').val('');

        } else {
            $('#txtNombrePatrocinador').prop('disabled', false);
        }

    });
  
    $('#txtNombrePatrocinador').keyup(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {

            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaFin').prop('disabled', true);
            $('#ddlTipoPatrocinador').prop('disabled', true);
            $('#txtInvestigadores').prop('disabled', true);
            $('#txtAlumnos').prop('disabled', true);
            $('#txtActividades').prop('disabled', true);
            $('#txtConvocatoria').prop('disabled', true);
            $('#inputFileUploadResumen').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#dteFechaInicio').val('');
            $('#dteFechaFin').val('');
            $('#ddlTipoPatrocinador').get(0).selectedIndex = 0;
            $('#txtInvestigadores').val('');
            $('#txtAlumnos').val('');
            $('#txtActividades').val('');
            $('#txtConvocatoria').val('');
            $('#inputFileUploadResumen').val('');

        } else {
            $('#dteFechaInicio').prop('disabled', false);
        }

    });

    $('#dteFechaInicio').change(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {

            $('#dteFechaFin').prop('disabled', true);
            $('#ddlTipoPatrocinador').prop('disabled', true);
            $('#txtInvestigadores').prop('disabled', true);
            $('#txtAlumnos').prop('disabled', true);
            $('#txtActividades').prop('disabled', true);
            $('#txtConvocatoria').prop('disabled', true);
            $('#inputFileUploadResumen').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#dteFechaFin').val('');
            $('#ddlTipoPatrocinador').get(0).selectedIndex = 0;
            $('#txtInvestigadores').val('');
            $('#txtAlumnos').val('');
            $('#txtActividades').val('');
            $('#txtConvocatoria').val('');
            $('#inputFileUploadResumen').val('');

        } else {
            $('#dteFechaFin').prop('disabled', false);
        }

    });

    $('#dteFechaFin').change(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {

            $('#ddlTipoPatrocinador').prop('disabled', true);
            $('#txtInvestigadores').prop('disabled', true);
            $('#txtAlumnos').prop('disabled', true);
            $('#txtActividades').prop('disabled', true);
            $('#txtConvocatoria').prop('disabled', true);
            $('#inputFileUploadResumen').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#ddlTipoPatrocinador').get(0).selectedIndex = 0;
            $('#txtInvestigadores').val('');
            $('#txtAlumnos').val('');
            $('#txtActividades').val('');
            $('#txtConvocatoria').val('');
            $('#inputFileUploadResumen').val('');

        } else {
            $('#ddlTipoPatrocinador').prop('disabled', false);
        }

    });

    $('#ddlTipoPatrocinador').change(function () {

        let data = $(this).get(0).selectedIndex;

        if (data == null || data == 0 || data == "0" || data == '0') {

            $('#txtInvestigadores').prop('disabled', true);
            $('#txtAlumnos').prop('disabled', true);
            $('#txtActividades').prop('disabled', true);
            $('#txtConvocatoria').prop('disabled', true);
            $('#inputFileUploadResumen').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#txtInvestigadores').val('');
            $('#txtAlumnos').val('');
            $('#txtActividades').val('');
            $('#txtConvocatoria').val('');
            $('#inputFileUploadResumen').val('');

        } else {
            toastr.success('Tipo de Patrocinador Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#txtInvestigadores').prop('disabled', false);
        }

    });

    $('#txtInvestigadores').keyup(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {

            $('#txtAlumnos').prop('disabled', true);
            $('#txtActividades').prop('disabled', true);
            $('#txtConvocatoria').prop('disabled', true);
            $('#inputFileUploadResumen').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#txtAlumnos').val('');
            $('#txtActividades').val('');
            $('#txtConvocatoria').val('');
            $('#inputFileUploadResumen').val('');

        } else {
            $('#txtAlumnos').prop('disabled', false);
        }
    });

    $('#txtAlumnos').keyup(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {

            $('#txtActividades').prop('disabled', true);
            $('#txtConvocatoria').prop('disabled', true);
            $('#inputFileUploadResumen').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#txtActividades').val('');
            $('#txtConvocatoria').val('');
            $('#inputFileUploadResumen').val('');

        } else {
            $('#txtActividades').prop('disabled', false);
        }
    });

    $('#txtActividades').keyup(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {

            $('#txtConvocatoria').prop('disabled', true);
            $('#inputFileUploadResumen').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#txtConvocatoria').val('');
            $('#inputFileUploadResumen').val('');

        } else {
            $('#txtConvocatoria').prop('disabled', false);
        }
    });

    $('#txtConvocatoria').keyup(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {

            $('#inputFileUploadResumen').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#inputFileUploadResumen').val('');

        } else {
            $('#inputFileUploadResumen').prop('disabled', false);
        }
    });

    $('#inputFileUploadResumen').change(function () {

        let data = $(this).val();

        if (data == null || data == "" || data == '') {

            $('#btnGuardar').prop('disabled', true);

        } else {
            $('#btnGuardar').prop('disabled', false);
        }
    });
})