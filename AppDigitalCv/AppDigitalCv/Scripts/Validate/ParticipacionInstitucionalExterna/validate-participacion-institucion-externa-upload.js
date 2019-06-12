$(document).ready(function(){

    $('#inputUploadFile').change(function () {

        var file = $(this).val();
        var ext = /.pdf/

        if (!ext.exec(file)) {
            $('#inputUploadFile').val('');
            toastr.warning('Solo se Permiten Archivos PDF', 'Digital-Cv dice', { timeOut: 1000, closeButton: true })
            $('#btnGuardar').prop('disabled',true);
        } else {
            toastr.success('Archivo Cargado Correctamente', 'Digital-Cv dice', { timeOut: 1000, closeButton: true })
        }

    })

})