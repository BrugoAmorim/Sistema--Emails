
let apagardados = document.getElementById("sair");
let mostradt = document.getElementById("dataenvio");

let pegati = document.getElementById("tituloEmail");
let pegarem = document.getElementById("emailRemetente");
let pegadest = document.getElementById("emailDestinatario");
let pegacon = document.getElementById("conteudoEmail");

// quando o navegador carregar ele pegará as informações do email da página anterior e mostrará ao usuário 
window.onload = function(){

    // essas informações são criadas na pagina que contem uma lista de cada email enviado
    let id = localStorage.getItem("idmail");
    let ti = localStorage.getItem("titulo");
    let ct = localStorage.getItem("conteudo");
    let ed = localStorage.getItem("emaildest");
    let re = localStorage.getItem("emailreme");
    let dt = localStorage.getItem("dtenvio");

    let nvdt = new Date(dt);
    let mescerto = ConverterMes(nvdt.getMonth());

    pegati.appendChild(document.createTextNode(ti));
    pegarem.appendChild(document.createTextNode("Remetente: " + re));
    pegadest.appendChild(document.createTextNode("Destinatário: " + ed));
    pegacon.appendChild(document.createTextNode(ct));

    mostradt.appendChild(document.createTextNode(" - " + nvdt.getDate() + "/" + mescerto));
}

// Os dados são armazenados temporariamente até o usuário sair da página
apagardados.onclick = function(){    
    
    localStorage.removeItem("idmail");
    localStorage.removeItem("titulo");
    localStorage.removeItem("conteudo");
    localStorage.removeItem("emaildest");
    localStorage.removeItem("emailreme");
    localStorage.removeItem("dtenvio");
}

// Essa função pega o número do mês em js e converte para a numeração correta
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