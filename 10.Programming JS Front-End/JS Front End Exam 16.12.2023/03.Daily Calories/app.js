function attachEvents(){
    const baseUrl = "http://localhost:3030/jsonstore/tasks";
    const loadHistoryButton = document.getElementById("load-meals");
    const editMealButton = document.getElementById("edit-meal");
    const historyDiv = document.querySelector("#list");
    const [food, time, calories] = document.getElementsByTagName("input");
    const addMealButton = document.getElementById("add-meal");

    loadHistoryButton.addEventListener("click", loadHistory);
    addMealButton.addEventListener("click", addMeal);

    function loadHistory(){
        historyDiv.innerHTML = "";
        editMealButton.disabled = true;

        fetch(baseUrl)
            .then(response => response.json())
            .then(data => {
                Object.values(data).forEach((obj) => {
                    const div = document.createElement("div");
                    div.classList.add("meal");

                    const h2 = document.createElement("h2");
                    h2.textContent = obj.food;
                    div.appendChild(h2);

                    const h3 = document.createElement("h3");
                    h3.textContent = obj.time;
                    div.appendChild(h3);

                    const h3cal = document.createElement("h3");
                    h3cal.textContent = obj.calories;
                    div.appendChild(h3cal);

                    const divButt = document.createElement("div");
                    div.classList.add("meal-buttons");

                    const changeButton = document.createElement("button");
                    changeButton.textContent = "Change";
                    changeButton.classList.add("change-meal");
                    divButt.appendChild(changeButton);

                    const deleteButton = document.createElement("button");
                    deleteButton.textContent = "Delete";
                    deleteButton.classList.add("delete-meal");
                    divButt.appendChild(deleteButton);

                    div.appendChild(divButt);
                    historyDiv.appendChild(div);

                    const id = obj._id;

                    changeButton.addEventListener("click", (e) => changeMeal(e, h2.textContent, h3.textContent, h3cal.textContent, id));

                    deleteButton.addEventListener("click", () => {
                        fetch(`${baseUrl}/${id}`,{
                            method: "DELETE"
                        }).then(() => {
                            loadHistory();
                        });
                    });
                });
            });

        async function changeMeal(е, foodInput, timeInput, caloriesInput, id){
            editMealButton.disabled = false;
            addMealButton.disabled = true;

            food.value = foodInput;
            time.value = timeInput;
            calories.value = caloriesInput;

            е.target.parentNode.parentElement.remove();

            editMealButton.addEventListener("click", async() => {
                const newFood = food.value;
                const newTime = time.value;
                const newCalories = calories.value;

                if(newFood && newTime && newCalories){
                    const newMeal = {
                        food: newFood,
                        time: newTime,
                        calories: newCalories
                    };

                    await fetch(`${baseUrl}/${id}`, {
                        method: "PUT",
                        headers: {"Content-Type": "application/json"},
                        body: JSON.stringify(newMeal)
                    }).then(response => response.json())
                        .then(data => {
                            loadHistory();
                        });
                }
                food.value = "";
                time.value = "";
                calories.value = "";
            });
        }
    }

    function addMeal(){
        const foodValue = food.value;
        const timeValue = time.value;
        const caloriesValue = calories.value;

        if(foodValue && timeValue && caloriesValue){
            const newMeal = {
                food: foodValue,
                time: timeValue,
                calories: caloriesValue
            };

            fetch(baseUrl, {
                method: "POST",
                headers: {"Content-Type": "application/json"},
                body: JSON.stringify(newMeal)
            })
                .then(data => {
                    loadHistory();
                });
        }

        food.value = "";
        time.value = "";
        calories.value = "";
    }
}

attachEvents();