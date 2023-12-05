function solve(gold) {
    let days = gold.length;
    let gramsPrice = 67.51;
    let bitcoinPrice = 11949.16;
    let stolen = 0.30;
    let boughtBitcoins = 0;
    let dayOfFirstPurchase = 0;
    let money = 0;

    for (let i = 0; i < days; i++) {
        let dailyGain = gold[i] * gramsPrice;
        if ((i + 1) % 3 == 0) {
            dailyGain -= dailyGain * stolen;
        }
        money += dailyGain;
        if (money >= bitcoinPrice) {
            while (money >= bitcoinPrice) {
                money -= bitcoinPrice;
                boughtBitcoins++;
            }
            if (dayOfFirstPurchase == 0)
                dayOfFirstPurchase = i + 1;
        }
    }

    console.log(`Bought bitcoins: ${boughtBitcoins}`);
    if (boughtBitcoins > 0)
        console.log(`Day of the first purchased bitcoin: ${dayOfFirstPurchase}`);
    console.log(`Left money: ${money.toFixed(2)} lv.`);
}

solve([3124.15,
    504.212,
    2511.124]);