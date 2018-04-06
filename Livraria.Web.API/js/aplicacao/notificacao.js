/**
 * Função responsável por inicializar toastr
 */
function inicializarToastr() {
    toastr.options.positionClass = 'toast-top-right';
    toastr.options.extendedTimeOut = 1000;
    toastr.options.timeOut = 1000;
    toastr.options.fadeOut = 250;
    toastr.options.fadeIn = 250;
    
}
/**
 * Função responsável por exibir toastr
 * @param {any} mensagem
 * @param {any} tipo
 */
function exibirToastr(mensagem, tipo = '') {

    if (tipo === 'error')
        toastr.error(mensagem);
    else if (tipo === 'wrn')
        toastr.warning(mensagem);
    else
        toastr.success(mensagem);
}