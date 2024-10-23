function isNumberPerfect(number) {

    let sum = 0;
    for (let i = 1; i < number; i++) {
        if (number % i == 0)
            sum += i;
    }
    if(sum === number)
        console.log(`We have a perfect number!`);
    else
        console.log(`It's not so perfect.`);
}

isNumberPerfect(6);
isNumberPerfect(28);
isNumberPerfect(1236498);