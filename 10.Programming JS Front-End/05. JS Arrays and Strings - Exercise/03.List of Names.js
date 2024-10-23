function solve(arr){
    let result = arr.sort()
        .map((item,i) => `${i + 1}.${item.toString()}`);
    result.forEach((item) => console.log(item));
}

solve(["John", "Bob", "Christina", "Ema"]);