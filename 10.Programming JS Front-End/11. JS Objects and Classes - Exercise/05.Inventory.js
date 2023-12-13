function getInventory(input){
    let heroes = [];

    for (const heroData of input) {
        let [name, level, items] = heroData.split(' / ');
        let hero = {
            name,
            level: Number(level),
            items,
        };

        heroes.push(hero);
    };
    heroes.sort((a, b) => a.level - b.level);

    for(const hero of heroes){
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items}`);
    }
}

getInventory([
        'Isacc / 25 / Apple, GravityGun',
        'Derek / 12 / BarrelVest, DestructionSword',
        'Hes / 1 / Desolator, Sentinel, Antara'
    ]
);
getInventory([
        'Batman / 2 / Banana, Gun',
        'Superman / 18 / Sword',
        'Poppy / 28 / Sentinel, Antara'
    ]
);