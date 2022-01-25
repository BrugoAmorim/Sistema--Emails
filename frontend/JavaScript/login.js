let setEmail = document.getElementById("inserirEmail");
let setSenha = document.getElementById("inserirSenha");
let ConfirmarLogin = document.getElementById("Confirmar");

let vl;

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

    let pegavl;

    let res = api.json();
    res.then(res =>{
        pegavl = res.idUsuario;
        console.log(res.email);
        vl = pegavl;
        console.log(vl);
    })

    window.location.href = "../Html/criarconta.html";
}

export { vl }
