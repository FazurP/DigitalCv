$(document).ready(function ()
{

    $('#FechaRegistro').change(function () {

        let registerDate = $(this).val();

        let dateNow = new Date();

        let day;
        let month;
        let year;

        year = dateNow.getFullYear();
        month = dateNow.getMonth();
        day = dateNow.getDate();

        let currentDate = year + '-' + 0 + month + '-' + day;

        if (registerDate > currentDate) {
            toastr.warning('La Fecha de Registro no Puede ser Mayor a la Actual', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $(this).val();
            $('#Proposito').prop('disabled', true);
            return false;
        }
    })

})