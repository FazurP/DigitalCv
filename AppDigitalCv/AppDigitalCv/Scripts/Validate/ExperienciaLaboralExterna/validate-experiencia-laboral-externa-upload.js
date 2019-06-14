$(document).ready(function(){

    $('#inputFileUpload').change(function () {

        var file = $(this).val();
        var expReg = /.pdf/

        if (!expReg.exec(file)) {
            toastr.warning('Solo se Permiten Archivos PDF', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#btnGuardar').prop('disabled', true);
            $(this).val('');
        } else {
            toastr.success('Archivo Cargado Correctamente', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });

        }


    })

})