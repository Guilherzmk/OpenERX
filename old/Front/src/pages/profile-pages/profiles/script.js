if (localStorage.getItem("token") == null){
    window.location.replace("../../index/index.html")
}

function deleteToken(){
localStorage.removeItem("token");
location.reload();
}

