$(document).ready(function ()
{

    $('#Documento').change(function ()
    {

        let data = [];

        data = $(this).get(0).files[0];

        if (data != undefined) {
            if (data[0].type != "application/pdf" || data[1].type != "application/pdf") {
                $(this).val("");
                toastr.warning("Solo se Permiten Archivos en PDF", "Digital-Cv dice", { timeOut: 1000, closeButton: true });
            } else {
                if (data[0].size <= 2097152 && data[1].size <= 2097152) {
                    toastr.success("Archivos Cargados Correctamente", "Digital-Cv dice", { timeOut: 1000, closeButton: true })
                } else
                {
                    toastr.error("No Puedes Cargar Archivos Mayores a 2mb", "Digital-Cv dice", { timeOut: 1000, closeButton: true })
                    $(this).val("");
                }
            }
        }      
    });
});