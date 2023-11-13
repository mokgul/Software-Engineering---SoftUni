function solve(fights, helmet, sword, shield, armor){
    let price = 0;
    for(let i = 1; i <= fights; i++){
        if(i % 2 == 0){
            price += helmet;
        }
        if(i % 3 == 0){
            price += sword;
        }
        if(i % 6 == 0){
            price += shield;
        }
        if(i % 12 == 0){
            price += armor;
        }
    }
    console.log(`Gladiator expenses: ${price.toFixed(2)} aureus`)
}

solve(7,
    2,
    3,
    4,
    5
);
solve(23,
    12.50,
    21.50,
    40,
    200
);