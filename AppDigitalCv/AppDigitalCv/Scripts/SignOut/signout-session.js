$('#BtnCerrarSession').click(function () {
    $.ajax({
        type: "POST",
        url: '/Seguridad/Cerrar',
        success: function ()
        {

            toastr.success("Sesion Cerrada Exitosamente.");
            location.href = "";
        }
    })

    
})
