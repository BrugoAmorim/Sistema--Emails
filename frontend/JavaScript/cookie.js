
// Função para criar Cookie
export function setCookie(nome,valor, dias) {
    
    document.cookie = nome + "=" + (valor || "")  + "; expires=" + dias + "; path=/";
}

// Função para procurar um cookie em expecifico
export function getCookie(nome) {
    var nomeCookie = nome + "=";
    var ca = document.cookie.split(';');
    for(var i=0;i < ca.length;i++) {
        var c = ca[i];
        while (c.charAt(0)==' ') c = c.substring(1,c.length);
        if (c.indexOf(nomeCookie) == 0) return c.substring(nomeCookie.length,c.length);
    }
    return null;
}

// Função para apagar um cookie
export function deleteCookie(nome) {   
    document.cookie = nome +'=; Path=/; Expires=Thu, 01 Jan 1970 00:00:01 GMT;';
}
