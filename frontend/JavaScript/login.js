let setEmail = document.getElementById("inserirEmail");
let setSenha = document.getElementById("inserirSenha");
let ConfirmarLogin = document.getElementById("Confirmar");

import { setCookie, getCookie } from './cookie.js'

ConfirmarLogin.onclick = async function(){
    
    const objeto = {
        "Email":setEmail.value,
        "Senha": setSenha.value
    };
    let url = "http://localhost:5000/Usuarios/login";

    const api = await fetch(url, {
        mode:'cors',
        method:'POST',
        headers:{
            'Content-Type':'application/json'
        },

        body: JSON.stringify(objeto)
    });

    let res = api.json();

    res.then(res => {

        if(res.codigo == 400){
            alert(res.motivo);
        }
        else{
            setCookie("idusuario", res.idUsuario);
            setCookie("email", res.email);
        
            window.location.href ="../Html/home.html";
        }
    })
}

