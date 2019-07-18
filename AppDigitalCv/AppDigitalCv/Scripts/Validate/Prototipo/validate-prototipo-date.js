$(document).ready(function () {

    $('#dteFechaPublicacion').change(function () {

        let registerDate = $(this).val();

        let dateNow = new Date();

        let day;
        let month;
        let year;

        year = dateNow.getFullYear();
        month = dateNow.getMonth() + 1;
        day = dateNow.getDate();

        let currentDate = year + '-' + 0 + month + '-' + day;

        if (registerDate > currentDate) {
            toastr.warning('La Fecha de Registro no Puede ser Mayor a la Actual', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
            $(this).val('');
            $('#ddlEstadoActual').prop('disabled', true);
            return false;
        }
    })

})