$(document).ready(function () {

    $('#inputFileUpload').change(function () {

        let data = $(this).val();

        let regExp = /.pdf/;

        if (!regExp.exec(data)) {
            $('#btnGuardar').prop('disabled', true);
            toastr.warning('Solo Se Permiten Archivos PDF', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $(this).val('');
        } else {
            toastr.success('Archivo Cargado Correctamente', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }

    })

})