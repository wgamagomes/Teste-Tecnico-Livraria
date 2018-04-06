/**
 * Função responsável por invocar a API para obter o livro e construir o formulário de edição
 * @param {any} id
 */
function consultar() {

    var titulo = $('#titulo').val();
    var url = 'api/livro/selecionarPorTitulo/' + titulo;

    $.ajax({
        url: url,
        type: 'GET',
        success: function (livro) {
            mapear(livro);
        },
        error: function (result) {
            if (result.status === 500)
                exibirToast('Erro interno ao servidor ao tentar buscar livro!', 'error');
            else (result.status === 404)
            exibirToast('Livro não encontrado na base de dados!', 'wrn');
        }
    });
}


/**
 * Função responsável por renderizar o formulário de edição dos livros
 * @param {any} livro
 */
function construirFormularioConsulta() {

    $.get("partial/_formConsulta.html", function (html_string) {
        $("#conteudo-id").html(html_string);
        personalizarCabecalho('fa-fw fa fa-search', 'Consultar');
    }, 'html');
}

/**
 * Função responsável mapear o livro para para o formulário
 * @param {any} livro
 */
function mapear(livro) {
    $("#autor").val(livro.Autor);
    $("#editor").val(livro.Editor);
    $("#preco").val(livro.Preco);
    $("#livro-id").val(livro.Id);
}
