const btnExecutar = document.getElementById('executarBtn');

const btnExecutarClick = function () {
    exercicio01();
}

function exercicio01 () {
    alert("Mensagem do exercício 01");
}

btnExecutar.addEventListener('click', btnExecutarClick)