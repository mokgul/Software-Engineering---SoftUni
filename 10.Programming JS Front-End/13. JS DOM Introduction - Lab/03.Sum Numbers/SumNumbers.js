function calc() {
    const first = document.getElementById('num1');
    const firstNumber = Number(first.value);

    const second = document.getElementById('num2');
    const secondNumber = Number(second.value);

    const sum = document.getElementById('sum');
    sum.value = firstNumber + secondNumber;
}
