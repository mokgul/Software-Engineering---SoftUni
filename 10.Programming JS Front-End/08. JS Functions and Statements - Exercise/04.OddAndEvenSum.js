function oddEvenDigitsSum(number){
    let arr = number.toString().split("");
    let length = arr.length;
    let oddSum = 0;
    let evenSum = 0;

    for (let i = 0; i < length; i++){
        let current = Number(arr[i]);
        if(current % 2 == 0)
            evenSum += current;
        else
            oddSum += current;
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

oddEvenDigitsSum(1000435);
oddEvenDigitsSum(3495892137259234);