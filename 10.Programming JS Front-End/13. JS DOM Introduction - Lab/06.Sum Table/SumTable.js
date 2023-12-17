function sumTable() {
    const tableRows = document.querySelectorAll('table tr');

    let totalSum = 0;

    for (let index = 1; index < tableRows.length; index++){
        const cells = tableRows[index].children;
        const cellPrice = Number(cells[1].textContent);
        totalSum += cellPrice;
    }

    document.getElementById('sum').textContent = totalSum.toString();
}