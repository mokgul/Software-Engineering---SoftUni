function solve(starting_yield){
    let days = 0;
    let extracted = 0;
    while(starting_yield >= 100){
        extracted += starting_yield;
        if(extracted >= 26){
            extracted -= 26;
        }
        days++;
        starting_yield -= 10;
    }
    if(extracted >= 26){
        extracted -= 26;
    }
    console.log(days);
    console.log(extracted);
}

solve(111);
solve(450);