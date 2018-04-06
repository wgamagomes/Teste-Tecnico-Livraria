$(document).ready(function ()
{
    inicializarToastr();

    personalizarCabecalho('fa-fw fa fa-home', 'Home');
    $("#conteudo-id").html('Bem vindo ao sistema de livraria!');

    
    $("#relatorio-id").click(function () {
        personalizarCabecalho('fa fa-fw fa-search-plus', $("#relatorio-id  > span").text());
        listarTodosLivros();
    });


    $("#cadastro-id").click(function () {    
        personalizarCabecalho('fa fa-fw fa-plus', $("#cadastro-id  > span").text());
        carregarFormularioCadastro();
    });


    $("#home-id").click(function () {
        personalizarCabecalho('fa-fw fa fa-home', 'Home');
        $("#conteudo-id").html('Bem vindo ao sistema de livraria!');
    });

    $("#consulta-id").click(function () {
        personalizarCabecalho('fa-fw fa fa-search', 'Consultar');
        construirFormularioConsulta();
    });
    
});

/**
 * Função responsável por personalizar o cabeçalho
 * @param {any} icon
 * @param {any} title
 */
function personalizarCabecalho(icon, title)
{
    $("#breadcrumb-id").text(title)
    var header = '<h1 class="page-title txt-color-blueDark"><i class="' + icon + '"></i>' + title +'</h1>';
    $('#header-id').html(header);
}
