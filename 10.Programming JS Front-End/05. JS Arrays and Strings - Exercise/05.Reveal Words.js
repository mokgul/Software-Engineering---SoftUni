function solve(words, text){
    words = words.split(", ");
    text = text.split(" ");

    for(let i = 0; i < words.length; i++){
        let currentWord = words[i];
        for(let j = 0; j < text.length; j++){
            let hiddenWord = text[j].startsWith('*',0) && text[j].length === currentWord.length;
            if(hiddenWord)
                text[j] = currentWord;
        }
    }
    console.log(text.join(" "));
}

solve('great',
    'softuni is ***** place for learning new programming languages');
solve('great, learning',
    'softuni is ***** place for ******** new programming languages'
)