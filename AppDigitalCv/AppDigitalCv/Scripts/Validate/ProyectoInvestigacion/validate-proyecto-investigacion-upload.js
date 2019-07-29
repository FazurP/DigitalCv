$(document).ready(function () {

    let regExp = /.pdf/;

    $('#inputFileUploadResumen').change(function () {

        let data = $(this).val();

        if (!regExp.exec(data))
        {
            toastr.warning('Solo se Permiten Archivos PDF', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $(this).val('');
            $('#btnGuardar').prop('disabled', true);
        }

    });

});