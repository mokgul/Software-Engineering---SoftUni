function solve(base, increment){
    let stone = 0;
    let marble = 0;
    let lapisLazuli = 0;
    let gold = 1;
    let floor = 1;

    for(let i = base; i > 0; i -= 2){
        if(i >= 3) {
            stone += ((i - 2) ** 2) * increment;

            if (floor % 5 != 0) {
                marble += (4 * i - 4) * increment;
            } else {
                lapisLazuli += (4 * i - 4) * increment;
            }
            floor++;
        }
        if(i == 2)
            gold = i ** 2 * increment;
    }
    floor = Math.floor(floor * increment);
    console.log(`Stone required: ${Math.ceil(stone)}`);
    console.log(`Marble required: ${Math.ceil(marble)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapisLazuli)}`);
    console.log(`Gold required: ${Math.ceil(gold)}`);
    console.log(`Final pyramid height: ${floor}`);
}

solve(11, 1);
solve(11, 0.75);
solve(12, 1);
solve(23, 0.5);