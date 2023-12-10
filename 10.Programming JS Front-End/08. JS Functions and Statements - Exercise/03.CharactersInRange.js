function printCharactersInRange(firstChar, secondChar) {
    let result = '';
    let start = Math.min(firstChar.charCodeAt(0), secondChar.charCodeAt(0));
    let end = Math.max(firstChar.charCodeAt(0), secondChar.charCodeAt(0));

    for(let current = start + 1; current < end; current++){
        const currentChar = String.fromCharCode(current);
        result += `${currentChar} `;
    }
    console.log(result.trimEnd());
}

printCharactersInRange('a', 'd');
printCharactersInRange('#', ':');
printCharactersInRange('C', '#');