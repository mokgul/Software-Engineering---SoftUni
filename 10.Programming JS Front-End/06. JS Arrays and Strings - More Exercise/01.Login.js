function solve(info){
    let tries = 0;
    let [username, ...passwords] = info;
    let password = username.split("").reverse().join("");
    while(tries < 4){
        let currentPass = passwords[tries];
        let correctPass = currentPass === password;
        if(tries == 3 && !correctPass){
            console.log(`User ${username} blocked!`);
            break;
        }

        if(correctPass){
            console.log(`User ${username} logged in.`);
            break;
        }
        else
            console.log(`Incorrect password. Try again.`);
        tries++;
    }

}

solve(['Acer','login','go','let me in','recA']);
solve(['momo','omom']);
solve(['sunny','rainy','cloudy','sunny','not sunny']);