function solve(arr) {
    let baristaCount = arr.shift();

    const baristas = {};

    for (let index = 0; index < baristaCount; index++) {
        const [name, shift, drinks] = arr.shift().split(" ");
        baristas[name] = {shift, types: drinks.split(',')};
    }

    let isClosed = false;
    while (!isClosed) {
        let [command, name, shift, drink] = arr.shift().split(' / ');

        switch (command) {
            case 'Prepare':
                if (baristas[name].shift === shift && baristas[name].types.includes(drink)) {
                    console.log(`${name} has prepared a ${drink} for you!`);
                } else {
                    console.log(`${name} is not available to prepare a ${drink}.`);
                }
                break;
            case 'Change Shift':
                baristas[name].shift = shift;
                console.log(`${name} has updated his shift to: ${baristas[name].shift}`);
                break;
            case 'Learn':
                drink = shift;
                if(baristas[name].types.includes(drink)){
                    console.log(`${name} knows how to make ${drink}.`)
                }
                else{
                    baristas[name].types.push(drink);
                    console.log(`${name} has learned a new coffee type: ${drink}.`);
                }
                break;
        }
        if (command == 'Closed')
            break;
    }

    for (const [name, info] of Object.entries(baristas)) {
        console.log(`Barista: ${name}, Shift: ${info.shift}, Drinks: ${info.types.join(', ')}`);
    }
}

solve([
    '3',
    'Alice day Espresso,Cappuccino',
    'Bob night Latte,Mocha',
    'Carol day Americano,Mocha',
    'Prepare / Alice / day / Espresso',
    'Change Shift / Bob / night',
    'Learn / Carol / Latte',
    'Learn / Bob / Latte',
    'Prepare / Bob / night / Latte',
    'Closed']
);
solve(['4',
    'Alice day Espresso,Cappuccino',
    'Bob night Latte,Mocha',
    'Carol day Americano,Mocha',
    'David night Espresso',
    'Prepare / Alice / day / Espresso',
    'Change Shift / Bob / day',
    'Learn / Carol / Latte',
    'Prepare / Bob / night / Latte',
    'Learn / David / Cappuccino',
    'Prepare / Carol / day / Cappuccino',
    'Change Shift / Alice / night',
    'Learn / Bob / Mocha',
    'Prepare / David / night / Espresso',
    'Closed']
);