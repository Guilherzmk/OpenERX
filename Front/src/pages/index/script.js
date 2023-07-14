let listELements = document.getElementById("item-menu");

if (localStorage.getItem("token") == null) {
    window.location.replace("../sing-in/sign-in.html")
}


function deleteToken() {
    localStorage.removeItem("token");
    location.reload();
}
