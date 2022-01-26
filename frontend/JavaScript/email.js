
let pegadata = document.getElementById("dataemail");

let titulo = document.getElementById("tituloemail");
let remetente = document.getElementById("ctt");
let sair = document.getElementById("apagaddtemporarios");
let blido = document.getElementById("marcacao");
let conteudo = document.getElementById("conteudo");

// quando a página carregar o navegador pegará as informacoes instanciadas e mostrará ao usuário
window.onload = function(){

    let ti = localStorage.getItem("titulo");
    let re = localStorage.getItem("remetente");
    let ct = localStorage.getItem("conteudo");
    let ld = localStorage.getItem("lido");
    let dt = localStorage.getItem("data");

    let novadt = new Date(dt);
    let mes = ConverterMes(novadt.getMonth());

    let ins = document.createElement("ins");
    
    titulo.appendChild(document.createTextNode(ti));
    ins.appendChild(document.createTextNode(re));
    pegadata.appendChild(document.createTextNode(" - " +  novadt.getDate() + "/" + mes));
    
    conteudo.appendChild(document.createTextNode(ct));
    remetente.appendChild(ins);

    if(ld == "true")
        blido.checked = true;
    else
        blido.checked = false;

}

// quando o usuário sair da página essas informações do email serão excluídas
sair.onclick = function(){
    localStorage.removeItem("titulo");
    localStorage.removeItem("remetente");
    localStorage.removeItem("idmail");
    localStorage.removeItem("conteudo");
    localStorage.removeItem("lido");
    localStorage.removeItem("data");
}

// essa funcao irá desmarcar ou marcar como lido o email que o usuário desejar
blido.onclick = async function MarcaouDesmarca(){
    
    let id = localStorage.getItem("idmail");

    let vl;
    if(blido.checked == true)
        vl = 1;
    else
        vl = 0;

    let url = "http://localhost:5000/Emails/marcar-lido/" + id + "/" + vl;

    const api = await fetch(url, {
        mode:'cors',
        method:'PUT'
    });
}


let del = document.getElementById("apagaremail");
// a funcao apagará o email permanentemente
del.onclick = async function DeletaEmail(){

    let id = localStorage.getItem("idmail");
    console.log(id);

    let url = "http://localhost:5000/Emails/apagar-email/" + id;

    const api = await fetch(url, {
        mode:'cors',
        method:'DELETE'
    });

    let res = api.json();
    res.then(res => {
        if(res.codigo == 400)
            alert(res.motivo)    
    })
}

function ConverterMes(nuMes){

    let mes;

    if(nuMes == 0) // janeiro
        mes = 1;
    else if(nuMes == 1) // fevereiro
        mes = 2;
    else if(nuMes == 2) // março
        mes = 3;
    else if(nuMes == 3) // abril
        mes = 4;
    else if(nuMes == 4) // maio
        mes = 5;
    else if(nuMes == 5) // junho
        mes = 6;
    else if(nuMes == 6) // julho
        mes = 7;
    else if(nuMes == 7) // agosto
        mes = 8;
    else if(nuMes == 8) // setembro
        mes = 9;
    else if(nuMes == 9) // outubro
        mes = 10;
    else if(nuMes == 10) // novembro
        mes = 11;
    else if(nuMes == 11) // dezembro
        mes = 12;

    return mes;
}