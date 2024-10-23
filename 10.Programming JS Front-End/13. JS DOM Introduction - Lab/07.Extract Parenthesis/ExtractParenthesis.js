function extract(content) {
    const text = document.getElementById(content).textContent;
    const pattern = /\((.+?)\)/gm;

    const matches = [...text.matchAll(pattern)].map(match => match[1]);

    let result = matches.join("; ");
    return result;
}
