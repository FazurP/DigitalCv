var AddEditar = function (id) {

    var url = "/ProyectoInvestigacion/GetProyectoUpdate?_idProyecto=" + id;

    $("#myModalBodyDiv1").load(url, function () {
        $("#myModal1").modal("show");

    })

};

var AddEliminar = function (id) {

    var url = "/ProyectoInvestigacion/GetProyectoDelete?_idProyecto=" + id;

    $("#myModalBodyDiv1").load(url, function () {
        $("#myModal1").modal("show");

    })

};

$(document).ready(function () {
    var oTable;

    BindDataTable();

    function BindDataTable() {

        if ($.fn.DataTable.isDataTable('#tblProyecto')) {
            oTable.Draw();
        }
        else {
            oTable = $('#tblProyecto').DataTable({

                "bServerSide": true,
                "sAjaxSource": '/ProyectoInvestigacion/GetProyectos',
                "fnServerData": function (sSource, aoData, fnCallback) {
                    $.ajax({
                        type: "Get",
                        data: aoData,
                        url: sSource,
                        success: fnCallback
                    })
                },
                "pageLength": 5,
                "paging": true,
                "language": {

                    "sProcessing": "Procesando...",
                    "sLengthMenu": "Mostrar _MENU_ registros",
                    "sZeroRecords": "No se encontraron resultados",
                    "sEmptyTable": "Ningún dato disponible en esta tabla",
                    "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                    "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                    "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                    "sInfoPostFix": "",
                    "sSearch": "Buscar:",
                    "sUrl": "",
                    "sInfoThousands": ",",
                    "sLoadingRecords": "Cargando...",
                    "oPaginate": {
                        "sFirst": "Primero",
                        "sLast": "Último",
                        "sNext": "Siguiente",
                        "sPrevious": "Anterior"
                    },
                    "oAria": {
                        "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                        "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                    }
                },
                "dataSrc": "",
                "columns": [

                    { "data": "strTituloProyecto" },

                    {
                        "data": "id",
                        "render": function (id, type, full, meta) {

                            return '<a href="#" onclick="AddEditar(' + id + ')"><i class="btn btn-sm btn-success fa fa-pencil-square-o"></i></a>'
                        }
                    },
                    {
                        "data": "id",
                        "render": function (id, type, full, meta) {

                            return '<a href="#" onclick="AddEliminar(' + id + ')"><i class="btn btn-sm btn-google glyphicon glyphicon-trash"></i></a>'
                        }
                    },
                ]
            });
        }
    }

})