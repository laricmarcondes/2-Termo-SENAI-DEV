//pegar os elementos do html pelo id
var botao = document.getElementById("botao");
var fundo = document.getElementById("fundo");
var fechar = document.getElementById("fechar");

//adicionar eventos exemplo onclick
botao.onclick = function() {
    fundo.classList.add("visivel");
}

fechar.onclick = function() {
    fundo.classList.remove("visivel");
}

fundo.onclick = function(e) {
    if (e.target == fundo) {
        fundo.classList.remove("visivel");
    }
}