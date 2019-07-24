$(document).ready(function () {

    $('#inputFileUpload').change(function () {

        let regExp = new RegExp(".pdf");

        let file = $(this).val();


        if (!regExp.exec(file))
        {
            toastr.warning('Solo se Permiten Archivos PDF', 'Digital-Cv dice', { closeButton: true, timeOut: 1000 });
            $(this).val('');
            $('#btnGuardar').prop('disabled', true);
        }

    })

})