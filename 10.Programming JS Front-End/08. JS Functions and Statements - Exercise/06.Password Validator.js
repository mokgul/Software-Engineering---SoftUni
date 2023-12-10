function passwordValidator(password) {
    function isLengthValid(pass) {
        return pass.length >= 6 && pass.length <= 10;
    }

    function isOnlyOfLettersAndDigits(pass) {
        let pattern = /^[A-Za-z0-9]+$/gm;
        let result = pattern.test(pass);
        return result;
    }

    function doesContainsAtLeastTwoDigits(pass) {
        let pattern = /[0-9]{2,}/gm;
        let result = pattern.test(pass);
        return result;
    }

    let checkFinal = true;

    let check = isLengthValid(password);
    if (!check) {
        console.log(`Password must be between 6 and 10 characters`);
        checkFinal = false;
    }

    check = isOnlyOfLettersAndDigits(password);
    if (!check) {
        console.log(`Password must consist only of letters and digits`);
        checkFinal = false;
    }

    check = doesContainsAtLeastTwoDigits(password);
    if (!check) {
        console.log(`Password must have at least 2 digits`);
        checkFinal = false;
    }

    if (checkFinal)
        console.log(`Password is valid`)
}

passwordValidator('logIn');
passwordValidator('MyPass123');
passwordValidator('Pa$s$s');