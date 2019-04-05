$(document).ready(function () {


    $('#btnGuardar').click(function () {

        if (!$("#radios input[id='sexo']").is(':checked')) {
            toastr.warning('Debes seleccionar un sexo');
            return false;
        } else {
            return true;
        }

    })

})