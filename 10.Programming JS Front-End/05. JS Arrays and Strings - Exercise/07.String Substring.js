function solve(word, text){
    let wordFound = `${word} not found!`;
    word = word.toLowerCase();
    text = text.split(" ").map((item) => item.toLowerCase());
    let textLength = text.length;

    for(let i = 0; i < textLength; i++){
        if(text[i] === word){
            wordFound = word;
            break;
        }
    }
    console.log(wordFound);
}

solve('javascript','JavaScript is the best programming language');
solve('python',
    'JavaScript is the best programming language');