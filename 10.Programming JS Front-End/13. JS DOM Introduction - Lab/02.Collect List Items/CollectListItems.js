function extractText() {
    const items = document.getElementsByTagName('li');
    const  results = [];

    for (const htmlliElement of Array.from(items)) {
     results.push(htmlliElement.textContent);
    }

    const textAreaElement = document.getElementById('result');
    textAreaElement.textContent = results.join("\n");
}