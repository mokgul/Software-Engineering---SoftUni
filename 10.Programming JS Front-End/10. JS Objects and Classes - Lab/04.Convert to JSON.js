function convertToJSON(name, lastName, hairColor){
    let obj = { name, lastName, hairColor };
    let jsonString = JSON.stringify(obj);
    console.log(jsonString);
}

convertToJSON('George', 'Jones', 'Brown');
convertToJSON('Peter', 'Smith', 'Blond');