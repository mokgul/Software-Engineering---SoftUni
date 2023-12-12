function printDNA(number) {
    let pattern = "ATCGTTAGGG".repeat(number);
    const rows = {
        1: (A, B) => console.log(`**${A}${B}**`),
        2: (A, B) => console.log(`*${A}--${B}*`),
        3: (A, B) => console.log(`${A}----${B}`),
        4: (A, B) => console.log(`*${A}--${B}*`),
    };
    let rowCounter = 1;
    let indexCounter = 0;

    for (let i = 1; i <= number; i++) {
        rows[rowCounter](pattern[indexCounter], pattern[indexCounter + 1]);

        rowCounter = rowCounter + 1 < 5 ? rowCounter += 1 : 1;
        indexCounter += 2;
    }
}

printDNA(4);
printDNA(10);