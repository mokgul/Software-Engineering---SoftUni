function solve(text){
    let pattern = /[A-Z][a-z]*/gm;
    let matches = text.match(pattern);
    console.log(matches.join(", "));
}

solve('SplitMeIfYouCanHaHaYouCantOrYouCan');
solve('HoldTheDoor');
solve('ThisIsSoAnnoyingToDo');