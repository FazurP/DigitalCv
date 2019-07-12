$(document).ready(function () {

    let date = new Date();

    let day = date.getDate();
    let month = date.getMonth() + 1;
    let year = date.getFullYear();

    let currentDate = year + "-" + 0 + month + "-" + day;

    $('#Publicacion').change(function () {

        let selectedDate = $(this).val();

        if (selectedDate > currentDate) {
            $('#Presentacion').prop('disabled', true);
            $(this).val('');
            toastr.warning('La Fecha de Publicación no Puede ser Mayor a la Actual', 'Digital-Cv dice', { timeOut: 1000, closeButton: true });
        }

    })

   


})