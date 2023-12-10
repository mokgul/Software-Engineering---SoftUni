function printMatrix(num){
    function printRow(num){
        console.log((num.toString() + ' ').repeat(num));
    }

    for(let i = 0; i < num; i++){
        printRow(num);
    }
}

printMatrix(3);
printMatrix(7);
printMatrix(2);