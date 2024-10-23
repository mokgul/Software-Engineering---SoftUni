function solve(num){
    let result = true;
    let numberToString = num.toString();
    let firstDigit = numberToString[0];
    let sum = Number(firstDigit);

    for(let i = 1; i < numberToString.length; i++){
        if(numberToString[i] != firstDigit)
            result = false;
        sum += Number(numberToString[i]);
    }

    console.log(result)
    console.log(sum)
}

solve(2222222)
solve(1234)