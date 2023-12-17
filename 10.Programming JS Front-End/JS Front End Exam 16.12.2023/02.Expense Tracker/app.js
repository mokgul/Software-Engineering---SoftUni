window.addEventListener("load", solve);

function solve(){
    const [expense, amount, date] = document.getElementsByTagName("input");
    const addButton = document.querySelector("#add-btn");
    const deleteButton = document.querySelector("#expenses > button");
    const form = document.querySelector("form");

    addButton.addEventListener("click", fillInfo);
    deleteButton.addEventListener("click", deleteInfo);

    function deleteInfo(){
        location.reload();
        form.reset();
    }

    function fillInfo(){
        if(expense.value == "" || amount.value == "" || date.value == ""){
            return;
        }

        const ul = document.querySelector("#preview-list");
        const li = document.createElement("li");
        li.classList.add("expense-item");

        const article = document.createElement("article");

        const para1 = document.createElement("p");
        para1.textContent = `Type: ${expense.value}`;
        const para2 = document.createElement("p");
        para2.textContent = `Amount: ${amount.value}$`;
        const para3 = document.createElement("p");
        para3.textContent = `Date: ${date.value}`;

        let tempExpense = expense.value;
        let tempAmount = amount.value;
        let tempDate = date.value;

        article.appendChild(para1);
        article.appendChild(para2);
        article.appendChild(para3);

        const div = document.createElement("div");
        div.classList.add("buttons");

        const editButton = document.createElement("button");
        editButton.textContent = "edit";
        editButton.classList.add("btn", "edit");
        editButton.addEventListener("click", editInfo);

        const okButton = document.createElement("button");
        okButton.textContent = "ok";
        okButton.classList.add("btn", "ok");
        okButton.addEventListener("click", okInfo);

        li.appendChild(article);
        div.appendChild(editButton);
        div.appendChild(okButton);
        li.appendChild(div);
        ul.appendChild(li);

        expense.value = "";
        amount.value = "";
        date.value = "";
        addButton.disabled = true;

        function editInfo(){
            expense.value = tempExpense;
            amount.value = tempAmount;
            date.value = tempDate;
            addButton.disabled = false;

            ul.removeChild(li);
        }

        function okInfo(){
            ul.removeChild(li);

            const ulList = document.querySelector("#expenses-list");
            const liList = document.createElement("li");
            liList.classList.add("expense-item");

            const article = document.createElement("article");
            const para1 = document.createElement("p");
            para1.textContent = tempExpense;
            const para2 = document.createElement("p");
            para2.textContent = tempAmount;
            const para3 = document.createElement("p");
            para3.textContent = tempDate;

            article.appendChild(para1);
            article.appendChild(para2);
            article.appendChild(para3);

            liList.appendChild(article);
            ulList.appendChild(liList);
            addButton.disabled = false;

        }
    }
}