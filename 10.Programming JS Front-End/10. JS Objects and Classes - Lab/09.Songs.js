function getSongs(array){
    class Song{
        constructor(typeList, name, time) {
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    const songsToPrint = [];
    let typeList = array.pop();
    let numberOfSongs = array.shift();

    for(let i = 0; i < numberOfSongs; i++){
        let [type, name, time] = array[i].split('_');
        let song = new Song(type, name, time);
        songsToPrint.push(song);
    }
    if(typeList === 'all'){
        songsToPrint.forEach((i) => console.log(i.name));
    }
    else{
        let filtered = songsToPrint.filter((i) => i.typeList === typeList);
        filtered.forEach((i) => console.log(i.name));
    }
};

getSongs([3,
    'favourite_DownTown_3:14',
    'favourite_Kiss_4:16',
    'favourite_Smooth Criminal_4:01',
    'favourite']
);
getSongs([4,
    'favourite_DownTown_3:14',
    'listenLater_Andalouse_3:24',
    'favourite_In To The Night_3:58',
    'favourite_Live It Up_3:48',
    'listenLater']
);
getSongs([2,
    'like_Replay_3:15',
    'ban_Photoshop_3:48',
    'all']
);