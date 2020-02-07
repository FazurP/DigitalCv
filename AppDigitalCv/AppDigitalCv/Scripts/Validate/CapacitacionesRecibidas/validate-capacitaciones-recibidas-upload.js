$(document).ready(function ()
{

    $('#file').change(function ()
    {
        let data = $(this).get(0).files[0];

        if (data.type != "application/pdf") {
            $(this).val("");
            toastr.warning("Solo se Permiten Archivos en PDF", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#Enviar').prop("disabled", true);
        } else
        {
            toastr.success("Archivo Cargardo Correctamente", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            $('#Enviar').prop("disabled", false);
        }
    });

});