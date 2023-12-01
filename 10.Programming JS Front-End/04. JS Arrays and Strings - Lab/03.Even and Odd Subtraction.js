function solve(arr){
    let even = arr.filter((num) => num % 2 == 0);
    let odd = arr.filter((num) => num % 2 != 0);
    console.log(even.reduce((a, b) => a + b, 0) - odd.reduce((a, b) => a + b, 0));
}

solve([1,2,3,4,5,6]);
solve([3,5,7,9]);
solve([2,4,6,8,10]);