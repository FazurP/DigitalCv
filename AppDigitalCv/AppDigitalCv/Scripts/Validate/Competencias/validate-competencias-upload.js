$(document).ready(function () {

    $('#fUpload').change(function () {

        let regExp = new RegExp(".pdf");

        let file = $(this).val();

        if (!regExp.exec(file)) {
            toastr.warning('Solo se Permiten Archivos PDF', 'Digital-Cv dice', { closeButton: true, timeOut: 1000 });
            $(this).val('');
            $('#Enviar').prop('disabled', true);
        } else
        {
            $('#Enviar').prop('disabled', false);
        }

    })

})