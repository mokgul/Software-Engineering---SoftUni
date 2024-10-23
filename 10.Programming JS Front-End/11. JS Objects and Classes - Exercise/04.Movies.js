function getMovies(arr) {
    let movies = [];

    arr.forEach((element) => {
        if (element.includes('addMovie')) {
            let movie = element.split('addMovie ')[1];
            movies.push({name: movie});
        } else if (element.includes('directedBy')) {
            let [movie, director] = element.split(' directedBy ');

            let searchMovie = movies.find((el) => el.name === movie);
            //returns a value, which is a TRUTHY value or returns undefined which is a FALSY value
            //the next if is considered true when we pass a TRUTHY value
            if (searchMovie) {
                searchMovie['director'] = director;
            }
        } else if (element.includes('onDate')) {
            let [movie, date] = element.split(' onDate ');

            let searchMovie = movies.find((el) => el.name === movie);
            if (searchMovie) {
                searchMovie['date'] = date;
            }
        }
    });

    movies.forEach((movie) => {
        if (movie.name && movie.date && movie.director) {
            console.log(JSON.stringify(movie));
        }
    });
}

getMovies([
        'addMovie Fast and Furious',
        'addMovie Godfather',
        'Inception directedBy Christopher Nolan',
        'Godfather directedBy Francis Ford Coppola',
        'Godfather onDate 29.07.2018',
        'Fast and Furious onDate 30.07.2018',
        'Batman onDate 01.08.2018',
        'Fast and Furious directedBy Rob Cohen'
    ]
);
getMovies([
        'addMovie The Avengers',
        'addMovie Superman',
        'The Avengers directedBy Anthony Russo',
        'The Avengers onDate 30.07.2010',
        'Captain America onDate 30.07.2010',
        'Captain America directedBy Joe Russo'
    ]
);