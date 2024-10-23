function solve(group,type,day){
    let price;
    let studentDiscount = (type == 'Students' && group >= 30) ? 0.15 : 0;
    let businessPeopleFree = (type == 'Business' && group >= 100) ? 10 : 0;
    let regularDiscount = (type == 'Regular' && (group >= 10 && group <= 20)) ? 0.05 : 0;
    switch (type){
        case 'Students':
            switch (day){
                case 'Friday': price = (8.45 * group) * (1 - studentDiscount); break;
                case 'Saturday': price = (9.80 * group) * (1 - studentDiscount); break;
                case 'Sunday': price = (10.46 * group) * (1 - studentDiscount); break;
            }
            break;
        case 'Business':
            switch (day){
                case 'Friday': price = 10.90 * (group - businessPeopleFree); break;
                case 'Saturday': price = 15.60 * (group - businessPeopleFree); break;
                case 'Sunday': price = 16.00 * (group - businessPeopleFree); break;
            }
            break;
        case 'Regular':
            switch (day){
                case 'Friday': price = (15.00 * group) * (1 - regularDiscount); break;
                case 'Saturday': price = (20.00 * group) * (1 - regularDiscount); break;
                case 'Sunday': price = (22.50 * group) * (1 - regularDiscount); break;
            }
            break;
    }
    console.log(`Total price: ${price.toFixed(2)}`)
}

solve(30,
    "Students",
    "Sunday"
)
solve(40,
    "Regular",
    "Saturday"
)