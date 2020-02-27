$(document).ready(function () {

    $('#fUpload').change(function () {

        let data = $(this).get(0).files[0];

        let regExp = new RegExp(".pdf");

        let file = $(this).val();

        if (!regExp.exec(file)) {
            toastr.warning('Solo se Permiten Archivos PDF', 'Digital-Cv dice', { closeButton: true, timeOut: 1000 });
            $(this).val('');
            $('#Enviar').prop('disabled', true);
        } else
        {
            if (data.size <= 2097152) {
                toastr.success('Archivo Cargado Correctamente', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
                $('#Enviar').prop('disabled', false);
            } else {
                toastr.error("No Pueder Cargar Archivos Mayores a 2MB", "Digital-Cv dice", { timeout: 1000, closeButton: true });
                $(this).val('');
            }         
           
        }

    })

})