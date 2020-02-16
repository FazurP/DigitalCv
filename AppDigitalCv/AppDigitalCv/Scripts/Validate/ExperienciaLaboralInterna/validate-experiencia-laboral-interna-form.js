$(document).ready(function () {

    $('#idArea').prop('disabled', true);
    $('#idProgramaEducativo').prop('disabled', true);
    $('#idPeriodo').prop('disabled', true);
    $('#dteFechaInicio').prop('disabled', true);
    $('#dteFechaTermino').prop('disabled', true);
    $('#strActividadDesempeñada').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);

    $('#idCategoria').change(function () {

        var dato = $(this).val();

        if (dato == null || dato == 0 || dato == '0' || dato == "0") {
            $('#idArea').prop('disabled', true);
            $('#idProgramaEducativo').prop('disabled', true);
            $('#idPeriodo').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#strActividadDesempeñada').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#idArea').val(0);
            $('#idProgramaEducativo').val(0);
            $('#idPeriodo').val(0);
            $('#dteFechaInicio').val('');
            $('#dteFechaTermino').val('');
            $('#strActividadDesempeñada').val('');
        } else {
            toastr.success('Categoria Seleccionada', 'Digital-Cv dice', { timeOut: 1000, closeButton:true });
            $('#idArea').prop('disabled', false);
        }

    })

    $('#idArea').change(function () {

        var dato = $(this).val();

        if (dato == null || dato == 0 || dato == '0' || dato == "0") {
            $('#idProgramaEducativo').prop('disabled', true);
            $('#idPeriodo').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#strActividadDesempeñada').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#idProgramaEducativo').val(0);
            $('#idPeriodo').val(0);
            $('#dteFechaInicio').val('');
            $('#dteFechaTermino').val('');
            $('#strActividadDesempeñada').val('');
        } else {
            toastr.success('Area Seleccionada', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#idProgramaEducativo').prop('disabled', false);
        }

    })

    $('#idProgramaEducativo').change(function () {

        var dato = $(this).val();

        if (dato == null || dato == 0 || dato == '0' || dato == "0") {

            $('#idPeriodo').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#strActividadDesempeñada').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#idPeriodo').val(0);
            $('#dteFechaInicio').val('');
            $('#dteFechaTermino').val('');
            $('#strActividadDesempeñada').val('');
        } else {
            toastr.success('Programa Educativo Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#idPeriodo').prop('disabled', false);
        }

    })

    $('#idPeriodo').change(function () {

        var dato = $(this).val();

        if (dato == null || dato == 0 || dato == '0' || dato == "0") {

            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#strActividadDesempeñada').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#dteFechaInicio').val('');
            $('#dteFechaTermino').val('');
            $('#strActividadDesempeñada').val('');
        } else {
            toastr.success('Periodo Seleccionado', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#dteFechaInicio').prop('disabled', false);
        }

    })

    $('#dteFechaInicio').change(function () {

        var dato = $(this).val();

        if (dato == null || dato == 0 || dato == '0' || dato == "0") {

            $('#dteFechaTermino').prop('disabled', true);
            $('#strActividadDesempeñada').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#dteFechaTermino').val('');
            $('#strActividadDesempeñada').val('');
        } else {

            $('#dteFechaTermino').prop('disabled', false);
        }

    })

    $('#dteFechaTermino').change(function () {

        var dato = $(this).val();

        if (dato == null || dato == 0 || dato == '0' || dato == "0") {

            $('#strActividadDesempeñada').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#strActividadDesempeñada').val('');
        } else {
            $('#strActividadDesempeñada').prop('disabled', false);
        }

    })

    $('#strActividadDesempeñada').keyup(function () {

        var dato = $(this).val();

        if (dato == null || dato == '' || dato == "") {

            $('#btnGuardar').prop('disabled', true);

        } else {
            $('#btnGuardar').prop('disabled', false);
        }

    })

})