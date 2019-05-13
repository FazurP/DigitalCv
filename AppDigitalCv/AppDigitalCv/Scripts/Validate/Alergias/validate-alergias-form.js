$(document).ready(function () {

    $('#Alimentos').prop('disabled', true);
    $('#Alergenos').prop('disabled', true);
    $('#Medicamentos').prop('disabled', true);
    $('#btnGuardar').prop('disabled', true);
  

    $('#rdbSi').change(function () {

        $('#Alimentos').prop('disabled', false);
        $('#Alergenos').prop('disabled', false);
        $('#Medicamentos').prop('disabled', false);
    

    })

    $('#rdbNo').change(function () {

        if ($('#rdbNo').prop('checked', true)) {

            $('#Alimentos').prop('disabled', true);
            $('#Alergenos').prop('disabled', true);
            $('#Medicamentos').prop('disabled', true);
            $('#Alimentos').val("0");
            $('#Alergenos').val("0");
            $('#Medicamentos').val("0");
            $('#btnGuardar').prop('disabled', true);

        } 

    })

    $('#Alimentos').change(function () {

        var alimentos = $('#Alimentos').val();

        if (alimentos == "0" || alimentos == "" || alimentos == 0) {
            if ($('#Alergenos').val() == 0 && $('#Medicamentos').val()==0) {
                $('#btnGuardar').prop('disabled', true);
            } else {
                $('#btnGuardar').prop('disabled', false)
            }
           
        } else {
            $('#btnGuardar').prop('disabled', false)
        }
           
        
    })
    $('#Alergenos').change(function () {

        var alergenos = $('#Alergenos').val();

        if (alergenos == "0" || alergenos == "" || alergenos == 0) {
            if ($('#Alimentos').val() == 0 && $('#Medicamentos').val() == 0) {
                $('#btnGuardar').prop('disabled', true);
            } else {
                $('#btnGuardar').prop('disabled', false)
            }
           
        } else {
            $('#btnGuardar').prop('disabled', false)
        }

    })

    $('#Medicamentos').change(function () {

        var medicamentos = $('#Medicamentos').val();

        if (medicamentos == "0" || medicamentos == "" || medicamentos == 0) {
            if ($('#Alimentos').val() == 0 && $('#Alergenos').val() == 0) {
                $('#btnGuardar').prop('disabled', true);
            } else {
                $('#btnGuardar').prop('disabled', false);
            }          
        } else {
            $('#btnGuardar').prop('disabled', false);
        }

    })

})