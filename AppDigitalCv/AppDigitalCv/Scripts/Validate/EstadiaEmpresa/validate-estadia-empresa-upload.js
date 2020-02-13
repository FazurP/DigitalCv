$(document).ready(function () {

    $('#file').change(function () {

        let regExp = new RegExp(".pdf");

        let file = $(this).val();


        if (!regExp.exec(file)) {
            toastr.warning('Solo se Permiten Archivos PDF', 'Digital-Cv dice', { closeButton: true, timeOut: 1000 });
            $(this).val('');
            $('#btnGuardar').prop('disabled', true);
        } else
        {
            toastr.success("Archivo Cargado Correctamente", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#btnGuardar').prop('disabled', false);
        }

    })

})