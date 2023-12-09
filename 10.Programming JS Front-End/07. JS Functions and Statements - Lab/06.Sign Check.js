function signCheck(first, second, third){
    let result = first * second * third;
    if(result >= 0)
        console.log('Positive')
    else
        console.log('Negative');
}

signCheck( 5, 12, -15);
signCheck( -6, -12, 14);
signCheck( -1, -2, -3);
signCheck( -5, 1, 1);