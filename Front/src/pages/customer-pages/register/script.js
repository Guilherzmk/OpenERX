window.onload = function () {

    const registerForm = document.getElementById("register-form");
    const listButton = document.getElementById("list");

    listButton.addEventListener("click", (e) => {
        e.preventDefault();

        localStorage.removeItem("customer");
        window.location.replace("../customers/customers.html")

    });

    if(localStorage.getItem("customer") == null){
        create();
    }else{
        update();
    }

    function create(){
        registerForm.addEventListener("submit", (e) => {
            e.preventDefault();
    
            let name = document.getElementById("name").value;
            let nickname = document.getElementById("nickname").value;
            let birthDate = document.getElementById("birth-date").value;
            let identity = document.getElementById("identity").value;
            let note = document.getElementById("note").value;
    
            let customer = {
                name: name,
                nickname: nickname,
                birthDate: birthDate,
                identity: identity,
                note: note
            };
    
            let token = JSON.parse(localStorage.getItem("token"));
    
            fetch("http://localhost:5045/v1/customers", {
                method: "POST",
                headers: {
                    "Authorization": "Bearer " + token,
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(customer)
            })
                .then(
                    (res) => {
                        console.log(res)
                        if (res.status == 401) {
                            window.location.replace("../../sing-in/sign-in.html")
                        }
                    }
                )
                .catch(
                    (err) => {
                        console.log("erro");
                        window.location.replace("../../sing-in/sign-in.html")
                    }
                );
    
            var allInputs = document.querySelectorAll('input');
            allInputs.forEach(singleInput => singleInput.value = '');
    
        });
    }

    function update() {

        if (localStorage.getItem("customer") == null) {
    
        } else {
            let customer = JSON.parse(localStorage.getItem("customer"));
            console.log(customer);
    
            let name = document.getElementById("name");
            let nickname = document.getElementById("nickname");
            let birthDate = document.getElementById("birth-date");
            let identity = document.getElementById("identity");
            let note = document.getElementById("note");
    
            name.value = customer.name;
            nickname.value = customer.nickname;
            birthDate.value = moment(customer.birthDate).format("DD/MM/YYYY");
            identity.value = customer.identity;
            note.value = customer.note;
    
            registerForm.addEventListener("submit", (e) => {
                e.preventDefault();
    
            let token = JSON.parse(localStorage.getItem("token"));
    
            customer.name = document.getElementById("name").value;
            customer.nickname = document.getElementById("nickname").value;
            customer.birthDate = document.getElementById("birth-date").value;
            customer.identity = document.getElementById("identity").value;
            customer.note = document.getElementById("note").value;
    
            

            fetch("http://localhost:5045/v1/customers/{"+customer.id+"}", {
                method: "PUT",
                headers: {
                    "Authorization": "Bearer " + token,
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(customer)
            })
            .then((res) => console.log(res))




                localStorage.removeItem("customer");
    
                var allInputs = document.querySelectorAll('input');
            allInputs.forEach(singleInput => singleInput.value = '');
    
            })
    
        }
    }
}
