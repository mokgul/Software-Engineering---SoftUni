function colorize() {
   const rows = document.querySelectorAll('tr:nth-child(even):not(:first-child)');

    for (const row of rows) {
        row.style.background = "teal";
    }
}