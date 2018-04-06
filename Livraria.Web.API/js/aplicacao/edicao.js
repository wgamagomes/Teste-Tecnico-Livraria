/**
 * Função responsável por invocar a API para obter o livro e construir o formulário de edição
 * @param {any} id
 */
function editarLivro(id) {

    var url = 'api/livro/' + id;

    $.ajax({
        url: url,
        type: 'GET',
        success: function (livro) {
            construirFormularioEdicao(livro);
        },        
        error: function (result) {
            if (result.status === 500)
                exibirToastr('Erro interno ao servidor ao tentar obter este livro!', 'error');
        }
    });
}


/**
 * Função responsável por renderizar o formulário de edição dos livros
 * @param {any} livro
 */
function construirFormularioEdicao(livro) {
    
    $.get("partial/_formEdicao.html", function (html_string) {
        $("#conteudo-id").html(html_string);
        mapearLivro(livro);
        personalizarCabecalho('fa fa-fw fa-pencil-square', "Edição");
    }, 'html');    
}

/**
 * Função responsável mapear o livro para para o formulário
 * @param {any} livro
 */
function mapearLivro(livro)
{
    $("#titulo").val(livro.Titulo);
    $("#autor").val(livro.Autor);
    $("#editor").val(livro.Editor);
    $("#preco").val(livro.Preco);
    $("#livro-id").val(livro.Id);    
}

/**
 * Função responsável submeter o livro a api para edição
 */
function submeterFormularioEdicao() {
    var form = $('#form-edicao');

    $.ajax({
        type: 'POST',
        url: 'api/livro',
        data: form.serialize(),
        success: function () {
            listarTodosLivros();
            exibirToastr('Livro ' + $('#titulo').val() + ' editado com sucesso!');
        },        
        error: function (result) {
            if (result.status === 500)
                exibirToastr('Erro interno ao servidor ao tentar editar este livro!', 'error');
        }
    });    
}