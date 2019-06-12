$(document).ready(function () {

    dateStart = "";
    dateEnd = "";

    var dateNow = new Date();

    var options = {year:'numeric',month:'long',day:'numeric'};

 
    $('#dteFechaInicio').change(function () {
     
         dateStart = $(this).val();
    });

    $('#dteFechaTerminio').change(function () {
       

        dateEnd = $(this).val();

        alert(dateEnd);
        alert(dateNow);

        if (dateEnd < dateStart) {
            toastr.warning('La Fecha de Terminación no Puede ser Anterior', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $(this).val('');
            $('#inputUploadFile').prop('disabled', true);
            return false;
        }
        if (dateNow.toLocaleDateString() < dateEnd) {
            toastr.warning('La Fecha de Terminación no Puede ser una Fecha Superior al Dia Actual', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $(this).val('');
            $('#inputUploadFile').prop('disabled', true);
            return false;
        }
        
    })



});