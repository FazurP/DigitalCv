$(document).ready(function () {

    $('#idArea').prop('disabled', true);
    $('#dteFechaInicio').prop('disabled', true);
    $('#dteFechaTermino').prop('disabled', true);
    $('#strActividadDesempeñada').prop('disabled', true);
    $('input[name=bitPuestoActual]').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);

    $('#idCategoria').change(function () {

        var dato = $(this).val();

        if (dato == null || dato == 0 || dato == '0' || dato == "0") {
            $('#idArea').prop('disabled', true);
            $('input[name=bitPuestoActual]').prop('disabled', true);
            $('#dteFechaInicio').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#strActividadDesempeñada').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#idArea').val(0);
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
            $('#dteFechaInicio').prop('disabled', true);
            $('input[name=bitPuestoActual]').prop('disabled', true);
            $('#dteFechaTermino').prop('disabled', true);
            $('#strActividadDesempeñada').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);

            $('#dteFechaInicio').val('');
            $('#dteFechaTermino').val('');
            $('#strActividadDesempeñada').val('');
        } else {
            toastr.success('Area Seleccionada', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('input[name=bitPuestoActual]').prop('disabled', false);
        }

    })

    $('input[id=paSi]').on('ifChecked', function () {
        $('#dteFechaInicio').prop('disabled', false);
        $('#dteFechaTermino').prop('disabled', true);
        $('#dteFechaTermino').val("");
        $('#strActividadDesempeñada').prop('disabled', false);
    });

    $('input[id=paNo]').on('ifChecked', function () {
        $('#dteFechaInicio').prop('disabled', false);
        $('#dteFechaTermino').prop('disabled', false);
        $('#strActividadDesempeñada').prop('disabled', false);
    });

    $('#dteFechaInicio').change(function () {

        toastr.success("Fecha de Inicio Seleccionada", "Digital-Cv dice", { timeOut: 1000, closeButton:true });

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