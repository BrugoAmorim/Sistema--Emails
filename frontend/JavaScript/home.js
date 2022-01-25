
import { getCookie } from './cookie.js'

let tbody = document.getElementById("campoinformacoes");

let objeto;
window.onload = async function(){

    let iduser = getCookie("idusuario");
    let url = "http://localhost:5000/Emails/emails-recebidos/" + iduser;

    const api = await fetch(url, {
        mode: 'cors',
        method: 'GET'
    });

    let res = api.json();

    res.then(res => {
        objeto = res;
        if(objeto.length > 0)
            GerarElemento(objeto);
        else
            alert(res.motivo);
    });
    
}

function GerarElemento(objeto){
    for(let i = 0; i < objeto.length; i++)
        {

            let mod = objeto[i];
            
            let corpo = document.createElement("tr");
            let titulo = document.createElement("strong");
            let remetente = document.createElement("td");

            titulo.appendChild(document.createTextNode(mod.titulo));
            remetente.appendChild(document.createTextNode((mod.remetente)));
            
            corpo.appendChild(titulo);
            corpo.appendChild(remetente);

            tbody.appendChild(corpo);

            if(corpo.addEventListener("click", function(){
                localStorage.setItem("idmail", JSON.stringify(mod.idEmailRecebido));
                localStorage.setItem("titulo", mod.titulo);
                localStorage.setItem("remetente",mod.remetente);
                localStorage.setItem("conteudo", mod.dConteudo);
                localStorage.setItem("lido", JSON.stringify(mod.lido));
                localStorage.setItem("data", mod.horarioEnvio);

                window.location.href = "./email.html";
            }));
        }
}
