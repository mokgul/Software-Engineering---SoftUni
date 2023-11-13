function solve(speed, area){
    let zone;
    let status;
    let difference = 0;
    switch (area){
        case 'motorway':
            if(speed > 130)
                difference = speed - 130;
            zone = 130;
            break;
        case 'interstate':
            if(speed > 90)
                difference = speed - 90;
            zone = 90;
            break;
        case 'city':
            if(speed > 50)
                difference = speed - 50;
            zone = 50;
            break;
        case 'residential':
            if(speed > 20)
                difference = speed - 20;
            zone = 20;
            break;
    }
    if(difference == 0)
        return console.log(`Driving ${speed} km/h in a ${zone} zone`)

    status = difference <= 20 ? 'speeding' :
        difference <= 40 ? 'excessive speeding' : 'reckless driving';

    console.log(`The speed is ${difference} km/h faster than the allowed speed of ${zone} - ${status}`)
}

solve(40, 'city')
solve(21, 'residential')
solve(120, 'interstate')
solve(200, 'motorway')