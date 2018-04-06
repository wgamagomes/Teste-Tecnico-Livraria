/**
 * Função responsável por listar todos os livvros
 */
function listarTodosLivros() {
    var url = 'api/livro/';

    $.ajax({
        url: url,
        type: 'GET',
        success: function (result) {
            montarTabela(result);
        },
        error: function (result) {
            if (result.status === 500)
                exibirToastr('Erro interno ao servidor ao tentar listar os livros!', 'error');
        }
    });    
}


/**
 * Função responsável por montar a grid de relatório de livros
 * @param {any} conteudo
 */
function montarTabela(conteudo) {
    $('#conteudo-id').html('');
    $('#conteudo-id').html(' <table id="tabela-relatorio-id" class="table table-bordered"></table>');

    $('#tabela-relatorio-id').DataTable({
        data: conteudo,
        columns: [
            { title: 'Excluir' },
            { title: 'Editar' },
            { title: 'Autor' },
            { title: 'Editor' },
            { title: 'Preco' },
            { title: 'Titulo' }
        ],
        columnDefs: [
            {
                targets: 0,
                render: renderizarBotaoExclusao
            },
            {
                targets: 1,
                render: renderizarBotaoEdicao
            }
        ],

        language: {
            lengthMenu: "Exibindo _MENU_ registros por página",
            zeroRecords: "Nenhum registro encontrado.",
            info: "Mostrando",
            infoEmpty: "Nenhum registro encontrado.",
            paginate: {
                previous: "Anterior",
                next: "Próximo",
            },

        },
        dom: "B<\"quantidade-paginas\"l>tp"
    });
}


/**
 * Função responsável por renderizar o botão de exclusão
 * @param {any} data
 * @param {any} type
 * @param {any} row
 * @param {any} meta
 */
function renderizarBotaoExclusao(data, type, row, meta) {
    if (type == "display") {
        return '<a href="#" onclick="excluirLivro(' + data + ')"><i style="font-size: 22px; color: darkred; text-align:center; display: inline-block; width: 100%;" class="fa fa-lg fa-times"></i></a>';
    }
    return data;
}

/**
 * Função responsável por renderizar o botão de edição
 * @param {any} data
 * @param {any} type
 * @param {any} row
 * @param {any} meta
 */
function renderizarBotaoEdicao(data, type, row, meta) {
    if (type == "display") {
        return '<a href="#" onclick="editarLivro(' + data + ')"><i style="font-size: 22px; text-align:center; display: inline-block; width: 100%;" class="fa fa-lg fa-fw fa-pencil-square"></i></a>';
    }
    return data;
}

/**
 * Função responsável por invocar a API para exclusão do livro
 * @param {any} id
 */
function excluirLivro(id) {
    var url = 'api/livro/' + id;

    $.ajax({
        url: url,
        type: 'DELETE',
        success: function (result) {
            listarTodosLivros();
            exibirToastr('Livro excluído com sucesso!');
        },
        error: function (result) {
            if (result.status === 500)
                exibirToastr('Erro interno ao servidor ao tentar excluir este livro!', 'error');
        }
    });

}






