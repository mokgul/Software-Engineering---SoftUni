function solve(first, second, operator){
    const operations = {
        multiply: (first, second) => first * second,
        divide: (first, second) => first / second,
        add: (first, second) => first + second,
        subtract: (first, second) => first - second,
    };

    console.log(operations[operator](first,second));
}

solve(5, 5, 'multiply');
solve(40, 8, 'divide');
solve(12, 19, 'add');
solve(50, 13, 'subtract');