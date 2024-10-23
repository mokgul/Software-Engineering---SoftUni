function solve(numbers){
    function isIntegerPalindrome(number){
        let numAsString = number.toString();
        let reverseNum = numAsString.split('').reverse().join('');
        return numAsString === reverseNum;
    }

    let length = numbers.length;
    for(const curr of numbers){
        console.log(isIntegerPalindrome(curr));
    }
}

solve([123,323,421,121]);
solve([32,2,232,1010]);