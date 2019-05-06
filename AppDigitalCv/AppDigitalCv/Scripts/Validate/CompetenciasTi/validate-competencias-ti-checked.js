$(document).ready(function () {


    $('#btnGuardar').click(function () {

        
        if (!$("#list input[id='list']").is(':checked')) {
            toastr.warning('Debes seleccionar un sexo');
            return false;
        } else {
            return true;
        }

    })

})