function solve(num){
    let result;
    if(num >= 0 && num <= 2)
        result = 'baby';
    else if(num >= 3 && num <= 13)
        result = 'child'
    else if(num >= 14 && num <= 19)
        result = 'teenager'
    else if(num >= 20 && num <= 65)
        result = 'adult'
    else if(num >= 66)
        result = 'elder'
    else
        result = 'out of bounds'

    console.log(result)
}

solve(20)
solve(1)
solve(100)
solve(-1)