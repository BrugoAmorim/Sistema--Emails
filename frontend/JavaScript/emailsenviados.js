
import { getCookie } from './cookie.js'

let tbody = document.getElementById("campoinfo");
let load = document.getElementById("recarregar");

window.onload = async function(){

    let iduser = getCookie("idusuario");
    let url = "http://localhost:5000/Emails/emails-enviados/" + iduser;

    const api = await fetch(url, {

        mode:'cors',
        method:'GET'
    });

    let res = api.json();
    res.then(res =>{
        for(let i = 0; i < res.length; i++){

            let obj = res[i];

            let corpo = document.createElement("tr");
            let ti = document.createElement("td");
            let dest = document.createElement("td");
            
            ti.appendChild(document.createTextNode(obj.titulo));
            dest.appendChild(document.createTextNode(obj.emailDestinatario));
            
            corpo.appendChild(ti);
            corpo.appendChild(dest);
            tbody.appendChild(corpo);

            if(corpo.addEventListener("click", function(){

                localStorage.setItem("idmail", JSON.stringify(obj.idEmailEnviado));
                localStorage.setItem("titulo", obj.titulo);
                localStorage.setItem("conteudo", obj.conteudo);
                localStorage.setItem("emaildest", obj.emailDestinatario);
                localStorage.setItem("emailreme", obj.emailRemetente);
                localStorage.setItem("dtenvio", obj.horarioEnvio);

                window.location.href = "../Html/detalhesemail.html";
            }));
        }
    })

}

load.onclick = function(){
    window.location.reload();
}