$(document).ready(function ()
{

    $('#Documento').change(function ()
    {
        let data = $(this).get(0).files[0];
        if (data != undefined) {
            if (data.type != "application/pdf") {
                $(this).val("");
                toastr.warning("Solo se Permiten Archivos en PDF", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            }
        }
        

    });

});