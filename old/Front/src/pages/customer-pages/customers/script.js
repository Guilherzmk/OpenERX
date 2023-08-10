let customers = new Array();

let token = JSON.parse(localStorage.getItem("token"));

list();

function list(){
    fetch("http://localhost:5045/v1/customers", {
        method: "GET",
        headers: {
            "Authorization": "Bearer " + token,
        }
    })
        .then((res) => res.json())
        .then((data) => {
            const tbody = document.getElementById("tbody");
    
            data.map((item) => {
                let tr = tbody.insertRow();
    
                let id = tr.insertCell();
                let code = tr.insertCell();
                let name = tr.insertCell();
                let nickname = tr.insertCell();
                let birthDate = tr.insertCell();
                let identity = tr.insertCell();
                let note = tr.insertCell();
                let actions = tr.insertCell();
                
                console.log(item);
    
                id.innerText = item.id;
                code.innerText = item.code;
                name.innerText = item.name;
                nickname.innerText = item.nickname;
                birthDate.innerText = moment(item.birthDate).format("DD/MM/YYYY");
                identity.innerText = item.identity;
                note.innerText = item.note;
    
                code.classList.add("code");
                id.classList.add("customer-id");
                actions.classList.add("action");
    
                let imgEdit = document.createElement("img");
                imgEdit.src = "../../../images/pencil.svg";
                imgEdit.setAttribute("onclick", "updateCustomer("+JSON.stringify(item)+")");
    
                let imgDelete = document.createElement("img");
                imgDelete.src = "../../../images/trash.svg";
                imgDelete.setAttribute("onclick", "deleteCustomer('"+item.id+"')");
    
                actions.appendChild(imgEdit);
                actions.appendChild(imgDelete);
                
            })
        })
    
        .catch(
            (err) => {
                console.log("erro");
                //window.location.replace("../../sing-in/index.html")
            }
        )
}

    const createBtn = document.getElementById("create");

    createBtn.addEventListener("click", (e) => {
        window.location.replace("../register/register.html")
    })


    function deleteCustomer(customerId){
        let token = JSON.parse(localStorage.getItem("token"));
        fetch("http://localhost:5045/v1/customers/?Ids="+customerId, {
            method:"DELETE",
            headers:{
                "Authorization": "Bearer " + token,
            }
        })
        .then((res) => {
            if(res.status == 200){
                location.reload();
            }else{
                console.log("erro");
            }
            
        })
        
    }

    function updateCustomer(customer){
            
            let customers = localStorage.setItem("customer", JSON.stringify(customer));
            window.location.replace("../register/register.html");
    }

    function deleteToken(){
        localStorage.removeItem("token");
        location.reload();
    }
