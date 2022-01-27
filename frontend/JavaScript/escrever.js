
import { getCookie } from './cookie.js'

document.getElementById("emailDe").value = getCookie("email");

let conteudo = document.getElementById("ctEmail");
let dest = document.getElementById("emailPara");
let titulo = document.getElementById("titulo");
let remet = document.getElementById("emailDe");

let confirmar = document.getElementById("Enviar");
let recarregar = document.getElementById("recarregar");

confirmar.onclick = async function(){

    const objson = {
        "Titulo":titulo.value,
        "Conteudo":conteudo.value,
        "EmailDestinatario":dest.value,
        "EmailRemetente":remet.value,
    };

    let url = "http://localhost:5000/Emails/enviar-email";

    const api = await fetch(url, {

        mode:'cors',
        method:'POST',
        headers:{
            'Content-Type':'application/json'
        },

        body: JSON.stringify(objson)
    });

    let res = api.json();

    res.then(res => {
        console.log(res);
        if(res.codigo == 400)
            alert(res.motivo)
    });
}

recarregar.onclick = function(){
    window.location.reload();
}