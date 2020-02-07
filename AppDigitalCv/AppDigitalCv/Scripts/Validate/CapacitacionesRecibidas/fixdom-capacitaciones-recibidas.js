$(document).ready(function ()
{

    $('#idTipoCapacitacion').change(function ()
    {
        let data = $(this).val();

        switch (data) {
            case "1":
                $('#lblNombre').html('Nombre del Diplomado:');
                $('#lblHoras').html('Total de Horas del Diplomado:');
                break;
            case "2":
                $('#lblNombre').html('Nombre del Curso:');
                $('#lblHoras').html('Total de Horas del Curso:');
                break;
            case "3":
                $('#lblNombre').html('Nombre del Taller:');
                $('#lblHoras').html('Total de Horas del Taller:');
                break;
            default:
                $('#lblNombre').html('Nombre:');
                $('#lblHoras').html('Total de Horas:');
                break;
        }

    });

});