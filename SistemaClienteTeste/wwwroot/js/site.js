$(document).ready(function () {
    getDatatable('#table-cliente');

    $("#DataNascimento").mask("00/00/0000");
    $("#Cep").mask("00000-000");
    $("#CPF").mask("000.000.000-00");
})

function buscarCep() {
    var cep = $("#Cep").val();

    $.get(`https://viacep.com.br/ws/${cep}/json`, function (data, status) {
        if (data) {
            $("#Logradouro").val(data.logradouro);
            $("#UF").val(data.uf);
            $("#Cidade").val(data.localidade);
        }
    });
}

function getDatatable(id) {
    $(id).DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ at&eacute; _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 at&eacute; 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
}


$('.close-alert').click(function() {
    $(".alert").hide('hide');
});