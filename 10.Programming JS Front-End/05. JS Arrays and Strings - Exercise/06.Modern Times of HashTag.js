function solve(text){
    let pattern = /#[A-Za-z]+/gm;
    let matches = text.match(pattern)

    for(let i = 0; i < matches.length; i++){
        console.log(matches[i].replace('#', ''))
    }
}

solve('Nowadays everyone uses # to tag a #special word in #socialMedia');
solve('The symbol # is known #variously in English-speaking #regions as the #number sign');