function factorialDivision(first, second) {
    function getFactorial(number) {
        if(number < 0)
            return -1;
        else if(number == 0)
            return 1;
        else
            return (number * getFactorial(number - 1));
    }

    // function getFactorial(number) {
    //     let factorial = 1;
    //     for (let i = number; i >= 1; i--) {
    //         factorial *= i;
    //     }
    //     return factorial;
    // }

    let result = getFactorial(first) / getFactorial(second);
    console.log(result.toFixed(2));
}

factorialDivision(5, 2);
factorialDivision(6, 2);