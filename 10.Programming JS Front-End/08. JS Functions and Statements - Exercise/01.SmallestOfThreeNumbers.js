function smallestOfThree(first, second, third){
    function smaller(num1, num2){
        return num1 <= num2 ? num1 : num2;
    }
    let smallest = smaller(first, smaller(second, third));
    console.log(smallest);
}

smallestOfThree(2, 5, 3);
smallestOfThree(600, 342, 123);
smallestOfThree(25, 21, 4);
smallestOfThree(2, 2, 2);