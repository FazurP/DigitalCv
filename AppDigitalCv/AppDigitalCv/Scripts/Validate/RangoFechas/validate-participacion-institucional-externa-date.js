$(document).ready(function () {

    dateStart = "";
    dateEnd = "";

    var dateNow = new Date();

    dateNow.toLocaleDateString();

 
    $('#dteFechaInicio').change(function () {
     
         dateStart = $(this).val();
    });

    $('#dteFechaTerminio').change(function () {
         dateEnd = $(this).val();

        if (dateEnd <= dateStart) {
            toastr.warning('La Fecha de Terminación no Puede ser Anterior', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $(this).val('');
            $('#inputUploadFile').prop('disabled', true);
            return false;
        } else if (dateEnd > dateNow.toLocaleDateString()) {

        }
        
    })



});