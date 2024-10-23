function storeProvision(currentStock, orderedProducts){
    const stocks = {};

    for (let index = 0; index < currentStock.length; index += 2){
        let product = currentStock[index];
        let quantity = Number(currentStock[index + 1]);

        if(!stocks.hasOwnProperty(product)){
            stocks[product] = quantity;
        }
        else {
            stocks[product] += quantity;
        }
    }

    for (let index = 0; index < orderedProducts.length; index += 2){
        let product = orderedProducts[index];
        let quantity = Number(orderedProducts[index + 1]);

        if(!stocks.hasOwnProperty(product)){
            stocks[product] = quantity;
        }
        else {
            stocks[product] += quantity;
        }
    }

    for (const product in stocks) {
        console.log(`${product} -> ${stocks[product]}`);
    }
}

storeProvision([
        'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
    ],
    [
        'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
);
storeProvision([
        'Salt', '2', 'Fanta', '4', 'Apple', '14', 'Water', '4', 'Juice', '5'
    ],
    [
        'Sugar', '44', 'Oil', '12', 'Apple', '7', 'Tomatoes', '7', 'Bananas', '30'
    ]
);