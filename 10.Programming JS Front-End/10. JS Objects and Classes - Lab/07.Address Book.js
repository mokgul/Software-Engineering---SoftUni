function getAddressBook(info){
    const addressBook = {};

    for (const addressBookElement of info) {
        const [name, address] = addressBookElement.split(":");
        addressBook[name] = address;
    }

    const addressBookArray = Object.entries(addressBook);
    addressBookArray.sort((a, b) => a[0].localeCompare(b[0]));

    for (const [name,address] of addressBookArray) {
        console.log(`${name} -> ${address}`);
    }
}

getAddressBook(['Tim:Doe Crossing',
    'Bill:Nelson Place',
    'Peter:Carlyle Ave',
    'Bill:Ornery Rd']);

getAddressBook(['Bob:Huxley Rd',
    'John:Milwaukee Crossing',
    'Peter:Fordem Ave',
    'Bob:Redwing Ave',
    'George:Mesta Crossing',
    'Ted:Gateway Way',
    'Bill:Gateway Way',
    'John:Grover Rd',
    'Peter:Huxley Rd',
    'Jeff:Gateway Way',
    'Jeff:Huxley Rd']);