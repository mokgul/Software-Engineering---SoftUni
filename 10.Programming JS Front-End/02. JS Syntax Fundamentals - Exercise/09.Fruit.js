function solve(fruit, weight, price){
    let weightToKgs = (weight / 1000);
    let finalPrice = (weightToKgs * price).toFixed(2);
    console.log(`I need $${finalPrice} to buy ${weightToKgs.toFixed(2)} kilograms ${fruit}.`);
}

solve('orange', 2500, 1.80)
solve('apple', 1563, 2.35)