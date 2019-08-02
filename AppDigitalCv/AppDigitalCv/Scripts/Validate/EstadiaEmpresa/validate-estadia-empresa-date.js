$(document).ready(function () {

    dateStart = "";
    dateEnd = "";

    var dateNow = new Date();

    $('#dteFechaInicio').change(function () {

        dateStart = $(this).val();

        var day;
        var month;
        var year;

        year = dateNow.getFullYear();
        month = dateNow.getMonth() + 1;
        day = dateNow.getDate();

        var dateCurrent;
    
        if (month == 10 || month == 11 || month == 12) {
            if (day < 10) {
                dateCurrent = year + '-' + month + '-' + 0 + day;
            } else
            {
                dateCurrent = year + '-' + month + '-' + day;
            }
             dateCurrent = year + '-' + month + '-' + day;
        } else
        {
            if (day < 10) {
                dateCurrent = year + '-' + 0 + month + '-' + 0 + day;
            } else
            {
                dateCurrent = year + '-' + 0 + month + '-' + day;
            }
            
        }
      
        if (dateStart > dateCurrent) {
            toastr.warning('La Fecha de Inicio no Puede ser Mayor a la Actual', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $(this).val('');
            $('#dteFechaTermino').prop('disabled', true);
            return false;
        }

    });

    $('#dteFechaTermino').change(function () {

        dateEnd = $(this).val();


        var day;
        var month;
        var year;

        year = dateNow.getFullYear();
        month = dateNow.getMonth() + 1;
        day = dateNow.getDate();
        
        var dateCurrent;

        if (month == 10 || month == 11 || month == 12) {
            if (day < 10) {
                dateCurrent = year + '-' + month + '-' + 0 + day;
            } else
            {
                dateCurrent = year + '-' + month + '-' + day;
            }
           
        } else {
            if (day < 10) {
                dateCurrent = year + '-' + 0 + month + '-' + 0 + day;
            } else
            {
                dateCurrent = year + '-' + 0 + month + '-' +  day;
            }
        }

        if (dateEnd < dateStart) {
            toastr.warning('La Fecha de Terminación no Puede ser Anterior', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $(this).val('');
            $('#txtNumeroAlumnos').prop('disabled', true);
            return false;
        }
        if (dateCurrent < dateEnd) {
            toastr.warning('La Fecha de Terminación no Puede ser una Fecha Superior al Dia Actual', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $(this).val('');
            $('#txtNumeroAlumnos').prop('disabled', true);
            return false;
        }

    })

});