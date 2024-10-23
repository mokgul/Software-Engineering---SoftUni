function solve(year){
    let result;
    if(year % 4 == 0 && year % 100 != 0)
        result = 'yes';
    else if(year % 400 == 0)
        result = 'yes'
    else
        result = 'no';
    console.log(result)
}

solve(1984)
solve(2003)
solve(4)