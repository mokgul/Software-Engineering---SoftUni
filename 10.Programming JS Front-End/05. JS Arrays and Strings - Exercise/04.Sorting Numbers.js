function solve(arr) {
    let length = arr.length;
    let result = new Array(length);
    arr = arr.sort((a,b) => a - b);
    for (let i = 0; i < length; i++) {
        if (i % 2 == 0)
            result[i] = arr.shift();
        else
            result[i] = arr.pop();
    }
    return result;
}

solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);