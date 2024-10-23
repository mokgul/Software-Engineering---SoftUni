function phoneBook(arr){
    const phoneBook = {};

    for(const element of arr){
        const [name, phone] = element.split(" ");
        phoneBook[name] = phone;
    }

    for (const phoneBookKey in phoneBook) {
        console.log(`${phoneBookKey} -> ${phoneBook[phoneBookKey]}`);
    }
}

phoneBook(['Tim 0834212554',
    'Peter 0877547887',
    'Bill 0896543112',
    'Tim 0876566344']
);

phoneBook(['George 0552554',
    'Peter 087587',
    'George 0453112',
    'Bill 0845344']
);