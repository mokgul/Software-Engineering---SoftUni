function solve(string, searchedWord){
    let arr = string.split(' ').filter(str => str == searchedWord);
    console.log(arr.length);
}

solve('This is a word and it also is a sentence',
    'is');
solve('softuni is great place for learning new programming languages',
    'softuni');