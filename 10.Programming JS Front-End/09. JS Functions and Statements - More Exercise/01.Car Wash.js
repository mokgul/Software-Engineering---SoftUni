function carWash(commands){
    let value = 10;
    let length = commands.length;

    const operations ={
        soap: (x) => x + 10,
        water: (x) => x + x * 0.20,
        'vacuum cleaner': (x) => x + x * 0.25,
        mud: (x) => x - x * 0.10,
    }

    for(let index = 1; index < length; index++){
        value = operations[commands[index]](value);
    }
    console.log(`The car is ${value.toFixed(2)}% clean.`)
}

carWash(['soap', 'soap', 'vacuum cleaner', 'mud', 'soap', 'water']);
carWash(["soap", "water", "mud", "mud", "water", "mud", "vacuum cleaner"]);