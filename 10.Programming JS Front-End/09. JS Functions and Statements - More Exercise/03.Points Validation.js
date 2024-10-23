function pointsValidation(coords) {

    const [x1, y1, x2, y2] = coords;

    function getDistance(x1, y1, x2, y2) {
        let distance = Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
        return Number.isInteger(distance);
    }

    function printResult(x1, y1, x2, y2, valid) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${valid ? 'valid' : 'invalid'}`);
    }

    let firstToZero = getDistance(x1, y1, 0, 0);
    let secondToZero = getDistance(x2, y2, 0, 0);
    let firstToSecond = getDistance(x1, y1, x2, y2);

    printResult(x1, y1, 0, 0, firstToZero);
    printResult(x2, y2, 0, 0, secondToZero);
    printResult(x1, y1, x2, y2, firstToSecond);
}

pointsValidation([3, 0, 0, 4]);
pointsValidation([2, 1, 1, 1]);