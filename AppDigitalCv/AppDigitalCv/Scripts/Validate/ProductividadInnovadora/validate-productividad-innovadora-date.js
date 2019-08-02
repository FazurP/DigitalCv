$(document).ready(function ()
{

    $('#FechaRegistro').change(function () {

        let registerDate = $(this).val();


        let dateNow = new Date();

        let day;
        let month;
        let year;
        let currentDate;

        year = dateNow.getFullYear();
        month = dateNow.getMonth() + 1;
        day = dateNow.getDate();

        if (month == 10 || month == 11 || month == 12) {
             currentDate = year + '-' + month + '-' + day;
        } else
        {
             currentDate = year + '-' + 0 + month + '-' + 0 + day;
        }
 
        if (currentDate < registerDate) {
            toastr.warning('La Fecha de Registro no Puede ser Mayor a la Actual', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $('#FechaRegistro').val();
            $('#Proposito').prop('disabled', true);
            return false;
        }
    })

})