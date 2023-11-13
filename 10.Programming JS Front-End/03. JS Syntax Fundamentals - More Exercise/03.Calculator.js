function solve(first,operator,second){

    let operations = {
        '+' : first + second,
        '-' : first - second,
        '/' : first / second,
        '*' : first * second
    };

    let result = operations[operator];
    console.log(result.toFixed(2));
}

solve(5,
    '+',
    10
);
solve(25.5,
    '-',
    3
);