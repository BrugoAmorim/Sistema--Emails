
let titulo = document.getElementById("tituloemail");
let remetente = document.getElementById("ctt");
let sair = document.getElementById("apagaddtemporarios");
let blido = document.getElementById("marcacao");
let conteudo = document.getElementById("conteudo");

window.onload = function(){

    let ti = localStorage.getItem("titulo");
    let re = localStorage.getItem("remetente");
    let id = localStorage.getItem("idmail");
    let ct = localStorage.getItem("conteudo");
    let ld = localStorage.getItem("lido");

    let ins = document.createElement("ins");
    
    titulo.appendChild(document.createTextNode(ti));
    ins.appendChild(document.createTextNode(re));
    
    conteudo.appendChild(document.createTextNode(ct));
    remetente.appendChild(ins);

    if(ld == "true")
        blido.checked = true;
    else
        blido.checked = false;

    console.log(id);
}

sair.onclick = function(){
    localStorage.removeItem("titulo");
    localStorage.removeItem("remetente");
    localStorage.removeItem("idmail");
    localStorage.removeItem("conteudo");
    localStorage.removeItem("lido");
    localStorage.removeItem("data");
}