$(document).ready(function () {


    $('#btnSubmit').prop('disabled', true);
    $('#StrEscrituraProcentaje').prop('disabled', true);
    $('#StrLecturaPorcentaje').prop('disabled', true);
    $('#StrEntendimientoPorcentaje').prop('disabled', true);
    $('#StrComunicacionPorcentaje').prop('disabled', true);


    $('#IdDialecto').change(function () {

        var idioma = $('#IdDialecto').val();

        if (idioma == null || idioma == 0 || idioma == '0' || idioma == "0") {
            $('#StrEscrituraProcentaje').prop('disabled', true);
            $('#StrLecturaPorcentaje').prop('disabled', true);
            $('#StrEntendimientoPorcentaje').prop('disabled', true);
            $('#StrComunicacionPorcentaje').prop('disabled', true);
            $('#btnSubmit').prop('disabled', true);

            $('#StrEscrituraProcentaje').get(0).selectedIndex = 0;
            $('#StrLecturaPorcentaje').get(0).selectedIndex = 0;
            $('#StrEntendimientoPorcentaje').get(0).selectedIndex = 0;
            $('#StrComunicacionPorcentaje').get(0).selectedIndex = 0;
        } else {

            toastr.success("Dialecto Seleccionado.", "Digital-Cv dice:", { timeOut: 1000 });
            $('#StrEscrituraProcentaje').prop('disabled', false);
        }

    })

    $('#StrEscrituraProcentaje').change(function () {

        var escritura = $('#StrEscrituraProcentaje').val();

        if (escritura == "--Seleccionar") {
            $('#StrLecturaPorcentaje').prop('disabled', true);
            $('#StrEntendimientoPorcentaje').prop('disabled', true);
            $('#StrComunicacionPorcentaje').prop('disabled', true);
            $('#btnSubmit').prop('disabled', true);

            $('#StrLecturaPorcentaje').get(0).selectedIndex = 0;
            $('#StrEntendimientoPorcentaje').get(0).selectedIndex = 0;
            $('#StrComunicacionPorcentaje').get(0).selectedIndex = 0;
        } else {
            toastr.success("Porcentaje de Escritura Seleccionado.", "Digital-Cv dice:", { timeOut: 1000 });
            $('#StrLecturaPorcentaje').prop('disabled', false);
        }

    })

    $('#StrLecturaPorcentaje').change(function () {

        var lectura = $('#StrLecturaPorcentaje').val();

        if (lectura == "--Seleccionar") {
            $('#StrEntendimientoPorcentaje').prop('disabled', true);
            $('#StrComunicacionPorcentaje').prop('disabled', true);
            $('#btnSubmit').prop('disabled', true);

            $('#StrEntendimientoPorcentaje').get(0).selectedIndex = 0;
            $('#StrComunicacionPorcentaje').get(0).selectedIndex = 0;
        } else {
            toastr.success("Porcentaje de Lectura Seleccionado.", "Digital-Cv dice:", { timeOut: 1000 });
            $('#StrEntendimientoPorcentaje').prop('disabled', false);
        }
    })

    $('#StrEntendimientoPorcentaje').change(function () {

        var entendimiento = $('#StrEntendimientoPorcentaje').val();

        if (entendimiento == "--Seleccionar") {

            $('#StrComunicacionPorcentaje').prop('disabled', true);
            $('#btnSubmit').prop('disabled', true);

            $('#StrComunicacionPorcentaje').get(0).selectedIndex = 0;
        } else {
            toastr.success("Porcentaje de Entendimiento Seleccionado.", "Digital-Cv dice:", { timeOut: 1000 });
            $('#StrComunicacionPorcentaje').prop('disabled', false);
        }
    })

    $('#StrComunicacionPorcentaje').change(function () {

        var comunicacion = $('#StrComunicacionPorcentaje').val();

        if (comunicacion == "--Seleccionar") {

            $('#btnSubmit').prop('disabled', true);

        } else {
            toastr.success("Porcentaje de Comunicación Seleccionado.", "Digital-Cv dice:", { timeOut: 1000 });
            $('#btnSubmit').prop('disabled', false);
        }
    })

})