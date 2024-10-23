function wordsTracker(list) {
    let words = list.shift().split(' ');

    let occurrences = {};

    words.forEach((word) => {
        occurrences[word] = 0;
        list.forEach((element) => {
            if (word === element) {
                occurrences[word] += 1;
            }
        });
    });

    let entries = Object.entries(occurrences).sort((a, b) => b[1] - a[1]);

    for (const [key, value] of entries) {
        console.log(`${key} - ${value}`);
    };
}

wordsTracker([
        'this sentence',
        'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
    ]
);
wordsTracker([
    'is the',
    'first', 'sentence', 'Here', 'is', 'another', 'the', 'And', 'finally', 'the', 'the', 'sentence']
);