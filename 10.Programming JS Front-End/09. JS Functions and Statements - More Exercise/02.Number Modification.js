function numberModification(number){

    function getDigitsAverage(num){
        let length = num.toString().length;
        let result = num.toString()
            .split('')
            .reduce((a,b) => Number(a) + Number(b)) / length;
        return result;
    }
    let result = number.toString();
    let average = getDigitsAverage(number);
    if(average >= 5)
        console.log(result);
    else{
        result += '9';
        numberModification(Number(result));
    }
}

numberModification(101);
numberModification(5835);