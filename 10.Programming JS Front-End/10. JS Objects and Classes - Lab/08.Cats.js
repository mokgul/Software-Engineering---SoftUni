function getCats(array){
    class Cat{
        constructor(name, age) {
            this.name = name;
            this.age = age;
        }

        meow(){
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    for(let index = 0; index < array.length; index++){
        let currentCat = array[index];
        const [name, age] = currentCat.split(" ");
        let cat = new Cat(name, age);
        cat.meow();
    }
}

getCats(['Mellow 2', 'Tom 5']);
getCats(['Candy 1', 'Poppy 3', 'Nyx 2']);