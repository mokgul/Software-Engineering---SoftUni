function solve(x1, y1, x2, y2){
    let x = 0;
    let y = 0;

    let resultOne = Math.sqrt((x1 - x) ** 2 + (y1 - y) ** 2);
    let resultTwo = Math.sqrt((x2 - x) ** 2 + (y2 - y) ** 2);
    let resultThree = Math.sqrt((x2 - x1) ** 2 + (y2 - y1) ** 2);

    let firstCheck = Number.isInteger(resultOne) ? 'valid' : 'invalid';
    let secondCheck = Number.isInteger(resultTwo) ? 'valid' : 'invalid';
    let thirdCheck = Number.isInteger(resultThree) ? 'valid' : 'invalid';

    console.log(`{${x1}, ${y1}} to {0, 0} is ${firstCheck}`);
    console.log(`{${x2}, ${y2}} to {0, 0} is ${secondCheck}`);
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${thirdCheck}`);

}

solve(3, 0, 0, 4)
solve(2, 1, 1, 1)