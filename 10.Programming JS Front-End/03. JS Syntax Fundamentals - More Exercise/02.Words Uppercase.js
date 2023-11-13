function solve(message){
    let array = message.match(/\w+/g);
    array = array.map(function (element){
        return element.toUpperCase();
    });
    array = array.join(", ")
    console.log(array);
}

solve('Hi, how are you?');
solve('hello')