function solve(first, second, third){
    function sum(num1, num2) {
       return first + second;
    }

    function subtract(num1, num2){
        return num1 - num2;
    }

    console.log(subtract(sum(first,second),third));
}

solve(23, 6, 10);
solve(1, 17, 30);
solve(42, 58, 100);