window.onload=function(){

    if (localStorage.getItem("token") != null){
        window.location.replace("../index/index.html")
    }

    const loginForm = document.querySelector("#login");

    loginForm.addEventListener("submit", async (e) =>{
        e.preventDefault();
    
        let accessKey = document.querySelector("#user");
        let password = document.querySelector("#password");
    
        let user = {
            accessKey: accessKey.value,
            password: password.value
        }

        
            await fetch("http://localhost:5045/v1/sign-in", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(user)
            })
            
            .then(
                async (response) => {
                    var body = await response.json();
                    console.log(body.token)
                    if(response.status == 200){
                        localStorage.setItem("token", JSON.stringify(body.token));
                        console.log("deu certo")
                        window.location.replace("../index/index.html");
                    }else{
                        console.log("deu erro")
                    }
                }
            )
            .catch(
                (err) => {
                    debugger;
                    console.log("erro");
                }
            )
            
        

        
        
        
       
        
        var allInputs = document.querySelectorAll('input');
        allInputs.forEach(singleInput => singleInput.value = '');
    });
}

