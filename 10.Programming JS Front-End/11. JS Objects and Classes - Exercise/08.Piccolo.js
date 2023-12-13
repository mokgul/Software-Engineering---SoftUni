function getCars(input){
    let parkingLot = [];

    for (const car of input) {
        let [direction, number] = car.split(', ');

        if(direction === 'IN' && !parkingLot.includes(number)){
            parkingLot.push(number);
        }
        else if(direction === 'OUT' && parkingLot.includes(number)){
            let index = parkingLot.indexOf(number);
            parkingLot.splice(index, 1);
        }
    };

    if(parkingLot.length > 0){
        let sorted = parkingLot.sort((a, b) =>  a.localeCompare(b));
        sorted.forEach(n => console.log(n));
    }
    else{
        console.log(`Parking Lot is Empty`);
    }
}

getCars(['IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'IN, CA9999TT',
    'IN, CA2866HI',
    'OUT, CA1234TA',
    'IN, CA2844AA',
    'OUT, CA2866HI',
    'IN, CA9876HH',
    'IN, CA2822UU']
);

getCars(['IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'OUT, CA1234TA']
);