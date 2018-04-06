/**
 * função responsável por carregar o formulário de cadastro de livros
 */
function carregarFormularioCadastro() {
    $("#conteudo-id").load("partial/_formularioCadastro.html");
}

/**
 * função responsável por submeter o formulário de cadastro de livros a API
 */
function submeterFormularioCadastro()
{
    var form = $('#form-envio');

        $.ajax({
            type: 'POST',
            url: 'api/livro',
            data: form.serialize(),
            success: function () {
                $('#form-envio').each(function () {
                    this.reset();
                    exibirToast('Livro cadastrado com sucesso!');
                });
            },
            error: function (result) {
                if (result.status === 500)
                    exibirToast('Erro interno ao servidor ao tentar cadastrar este livro!', 'error');
            }
        });    
}