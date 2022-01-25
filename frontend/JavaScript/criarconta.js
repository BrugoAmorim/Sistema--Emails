
import { setCookie, getCookie } from './cookie.js'

let nvemail = document.getElementById("novoEmail");
let nvsenha = document.getElementById("novaSenha");
let cfsenha = document.getElementById("confirmarSenha");

let criar = document.getElementById("criarConta");

criar.onclick = async function(){

    const obj = {
        "Email": nvemail.value,
        "Senha": nvsenha.value,
        "ConfirmarSenha": cfsenha.value
    }

    let url = "http://localhost:5000/Usuarios/novaconta";
    
    const api = await fetch(url, {
        mode:'cors',
        method:'POST',
        headers:{
            'Content-Type':'application/json'
        },

        body: JSON.stringify(obj)
    })

    let res = api.json();

    res.then(res => {

        if(res.codigo == 400)
            alert(res.motivo);
        else
            alert("Conta criada com sucesso!");
        
    })
}
