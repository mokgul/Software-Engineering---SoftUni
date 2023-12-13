function getOccurrences(input){
    input = input.toLowerCase();
    let arrOfElements = input.split(' ');

    let map = new Map();

    arrOfElements.forEach((element) => {
        if(map.has(element)){
            let oldValue = map.get(element);
            let newValue = oldValue + 1;

            map.set(element, newValue);
        }
        else{
            map.set(element, 1);
        }
    });

    let oddElements = [];

    map.forEach((value, key) => {
        if(value % 2 !== 0){
            oddElements.push(key);
        }
    });

    console.log(oddElements.join(' '));
}

getOccurrences('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');
getOccurrences('Cake IS SWEET is Soft CAKE sweet Food');