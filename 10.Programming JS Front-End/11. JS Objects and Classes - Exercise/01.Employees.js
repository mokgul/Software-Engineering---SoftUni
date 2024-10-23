function getEmployees(arr){
    arr.forEach( employee => {
        const employeeName = employee;
        const personalNumber = employee.length;

        console.log(`Name: ${employeeName} -- Personal Number: ${personalNumber}`);
    })
}

getEmployees([
        'Silas Butler',
        'Adnaan Buckley',
        'Juan Peterson',
        'Brendan Villarreal'
    ]
);
getEmployees([
        'Samuel Jackson',
        'Will Smith',
        'Bruce Willis',
        'Tom Holland'
    ]
);