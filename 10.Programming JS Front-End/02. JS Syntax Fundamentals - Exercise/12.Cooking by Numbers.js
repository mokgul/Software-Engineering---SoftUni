function solve(number,...operations){
    let result = Number(number);
    for(let i = 0; i < operations.length; i++){
        switch (operations[i]){
            case 'chop': result /= 2; break;
            case 'dice': result = Math.sqrt(result); break;
            case 'spice': result += 1; break;
            case 'bake': result *= 3; break;
            case 'fillet': result *= 0.80; break;
        }
        console.log(result);
    }
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop')
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet')