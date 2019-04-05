$(document).ready(function(){

    $('#IdParentesco').attr('disabled', true);
    $('#Telefono').attr('disabled', true);
    $('#Direccion').attr('disabled', true);
    $('#btnGuardar').attr('disabled', true);
    var p = $('#IdParentesco').val();

    $('#Nombre').keyup(function () {

        var text = $('#Nombre').val();

        if (text == "") {
            $('#IdParentesco').attr('disabled', true);
            $('#Telefono').attr('disabled', true);
            $('#Direccion').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#Telefono').val("");
            $('#Direccion').val("");

        } else {

            $('#IdParentesco').attr('disabled', false);

        }

        


    })

    $('#IdParentesco').change(function () {

        var pp = $("#IdParentesco").val();

        if (pp == "0" || pp == "") {
            $('#btnGuardar').attr("disabled", true);
            $('#Telefono').attr('disabled', true);
            $('#Direccion').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);

            $('#Telefono').val("");
            $('#Direccion').val("");
        } else {
            toastr.success("Parentesco Seleccionado");
            $('#Telefono').attr('disabled', false);

        }

    })

    $('#Telefono').keyup(function () {

        var text = $('#Telefono').val();

        if (text == "") {
            $('#Direccion').attr('disabled', true);
            $('#btnGuardar').attr('disabled', true);
        } else {

            $('#Direccion').attr('disabled', false);

        }

    })

    $('#Direccion').keyup(function () {

        var text = $('#Direccion').val();

        if (text == "") {

            $('#btnGuardar').attr('disabled', true);
        } else {

            $('#btnGuardar').attr('disabled', false);

        }

    })


})