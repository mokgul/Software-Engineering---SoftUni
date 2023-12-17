function editElement(ref, match, replacer) {
    const  content = ref.textContent;
    const  editedText = content.replace(new RegExp(match, 'g'), replacer);

    ref.textContent = editedText;
}