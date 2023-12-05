function solve(arr, step){

    let result = arr.filter((_, i) =>  i % step === 0);
    return result;
}

solve(['5', '20', '31', '4', '20'], 2);
solve(['dsa', 'asd', 'test', 'tset'], 2);