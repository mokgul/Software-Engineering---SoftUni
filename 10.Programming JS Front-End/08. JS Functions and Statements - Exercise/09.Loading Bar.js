function printLoadingBar(percentage){
    if(percentage === 100){
        console.log(`100% Complete`)
    }
    else if(percentage == null){
        console.log("[%%%%%%%%%%]\n")
    }
    else{
        let bar = '';
        for(let i = 10; i <= 100; i+=10){
            if(i <= percentage)
                bar += '%';
            else
                bar+='.';
        }
        console.log(`${percentage}% [${bar}]`);
        console.log(`Still loading...`);
    }
}

printLoadingBar(30);
printLoadingBar(50);
printLoadingBar(100);
printLoadingBar();