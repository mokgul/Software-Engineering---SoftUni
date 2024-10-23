function solve(start, end){
    let result =''
    let sum = 0;
    for(let i = start; i <= end; i++){
        result += i.toString() + ' ';
        sum += i;
    }
    console.log(result);
    console.log(`Sum: ${sum}`);
}

solve(5, 10)
solve(0, 26)
solve(50, 60)