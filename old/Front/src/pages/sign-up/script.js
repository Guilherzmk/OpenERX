window.onload = function(){
    const registerForm = document.getElementById("sign-up");

    registerForm.addEventListener("submit", (e) => {
        e.preventDefault();
        let name = document.getElementById("name").value;
        let email = document.getElementById("email").value;
        let phone = document.getElementById("phone").value;
        let accessKey = document.getElementById("access-key").value;
        let password = document.getElementById("password").value;

        let user = {
            name: name,
            email: email,
            phone: phone,
            accessKey: accessKey,
            password: password
        }

        fetch("http://localhost:5045/v1/sign-up", {
            method: "POST",
            headers:{
                "Content-Type": "application/json"
            },
            body: JSON.stringify(user)
        })
        .then(
            (res) => {
                if(res.status == 200){
                    window.location.replace("../sing-in/sign-in.html");
                }
            }
        )
        .catch(
            (err) => {
                console.log(err);
                console.log("erro");
            }
        );  
    })
}