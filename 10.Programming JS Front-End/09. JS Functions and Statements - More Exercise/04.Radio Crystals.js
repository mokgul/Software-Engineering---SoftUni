function radioCrystals(inputs){
    const [target, ...crystals] = inputs;

    const operations = {
        Cut: (mass) => mass - mass * 0.75,
        Lap: (mass) => mass - mass * 0.20,
        Grind: (mass) => mass - 20,
        Etch: (mass) => mass - 2,
        'X-ray': (mass) => mass + 1,
        Wash: (mass) => Math.floor(mass),
    }

    function processCrystal(crystal, target){
        const counters = {
            cut: 0,
            lap: 0,
            grind: 0,
            etch: 0,
            xray: 0,
        };
        let original = crystal;
        while(crystal !== target){
            //console.log(crystal);
            if(operations['Cut'](crystal) >= target){
                crystal = operations['Cut'](crystal);
                counters['cut'] += 1;
                crystal = operations.Wash(crystal);
                continue;
            }
            else if(operations['Lap'](crystal) >= target){
                crystal = operations['Lap'](crystal);
                counters['lap'] += 1;
                crystal = operations.Wash(crystal);
                continue;
            }
            else if(operations['Grind'](crystal) >= target){
                crystal = operations['Grind'](crystal);
                counters['grind'] += 1;
                crystal = operations.Wash(crystal);
                continue;
            }
            else if(crystal >= target){
                crystal = operations['Etch'](crystal);
                counters['etch'] += 1;
                crystal = operations.Wash(crystal);
                continue;
            }
            else if(crystal < target){
                crystal = operations['X-ray'](crystal);
                counters['xray'] += 1;
                continue;
            }
        }
        console.log(`Processing chunk ${original} microns`);
        if(counters['cut'] > 0){
            console.log(`Cut x${counters['cut']}`);
            console.log('Transporting and washing')
        }
        if(counters['lap'] > 0){
            console.log(`Lap x${counters['lap']}`);
            console.log('Transporting and washing')
        }
        if(counters['grind'] > 0){
            console.log(`Grind x${counters['grind']}`);
            console.log('Transporting and washing')
        }
        if(counters['etch'] > 0){
            console.log(`Etch x${counters['etch']}`);
            console.log('Transporting and washing')
        }
        if(counters['xray'] > 0){
            console.log(`X-ray x${counters['xray']}`);
        }
        console.log(`Finished crystal ${target} microns`)
    }

    for(let i = 0; i < crystals.length; i++){
        processCrystal(crystals[i], target);
    }
}

radioCrystals([1375, 50000]);
radioCrystals([1000, 4000, 8100]);