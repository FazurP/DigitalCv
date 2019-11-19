$(document).ready(function () {


    $('#btnSubmit').prop('disabled', true);
    $('#idNivelConocimiento').prop('disabled', true);
    $('#fUpload').prop('disabled', true);



    $('#IdIdioma').change(function () {

        var idioma = $('#IdIdioma').val();

        if (idioma == null || idioma == 0 || idioma == '0' || idioma == "0") {

            $('#btnSubmit').prop('disabled', true);
            $('#idNivelConocimiento').prop('disabled', true);
            $('#fUpload').prop('disabled', true);

            $('#idNivelConocimiento').val(0);
            $('#fUpload').val('');

        } else {

            toastr.success("Idioma Seleccionado.", "Digital-Cv dice:", { timeOut: 1000, closeButton: true });
            $('#idNivelConocimiento').prop('disabled', false);
        }

    });

    $('#idNivelConocimiento').change(function () {

        var data = $(this).val();

        if (data == 0 || data == "0" || data == '0' || data == null) {

            $('#fUpload').prop('disabled', true);
            $('#btnSubmit').prop('disabled', true);

            $('#fUpload').val('');
        } else {
            toastr.success("Nivel Seleccionado.", "Digital-Cv dice:", { timeOut: 1000, closeButton: true });
            $('#fUpload').prop('disabled', false);
        }

    });

    $('#fUpload').change(function () {

        let data = $(this).val();

        if (data == "") {
            $('#btnSubmit').prop('disabled', true);
        } else {
            toastr.success("Evidencia Cargada.", "Digital-Cv dice:", { timeOut: 1000, closeButton: true });
            $('#btnSubmit').prop('disabled', false);
        }
    });

});
    