
function solve(num1, num2, num3){
    let result = num1 > num2 && num1 > num3 ? num1 : num2 > num1 && num2 > num3 ? num2 : num3;
    console.log(`The largest number is ${result}`)
}

solve(5, -3, 16)
solve(-3, -5, -22.5)