const txtContador = document.getElementById('txtContador');
const btnContadorClr = document.getElementById('btnContadorClr');
const btnContadorAdd = document.getElementById('btnContadorAdd');

const dados = document.getElementById('dados');
const selTipoDado = document.getElementById('selTipoDado');
const btnLancarDados = document.getElementById('btnLancarDados');
const numQtdDados = document.getElementById('numQtdDados');

const arrayCores = ['blue', 'red', 'green'];
var corAtual = -1;

const btnContadorAddClick = function () {
    let valorContador = parseInt(txtContador.innerText);
    txtContador.innerText = valorContador + 1;

    corAtual = (++corAtual) > (arrayCores.length - 1) ? 0 : corAtual;
    btnContadorAdd.style.backgroundColor = arrayCores[corAtual];
}

const btnContadorClrClick = function () {
    txtContador.innerText = 0;
}

const btnLancarDadosClick = () => {
    let valorMaximo = parseInt(selTipoDado.value);
    let valorMinimo = 1;

    let dadosEmTela = document.getElementsByClassName('dados__dado');
    for (i = (dadosEmTela.length - 1); i >= 0; i--) {
        dadosEmTela[i].remove();
    }

    let qtdDados = parseInt(numQtdDados.value);
    while (qtdDados > 0) {
        let dadoValor = document.createElement('span');
        dadoValor.innerText = obterNumeroAleatorio(valorMinimo, valorMaximo);

        let dado = document.createElement('div');
        dado.classList.add('dados__dado')
        dado.appendChild(dadoValor);
        dados.appendChild(dado);
        qtdDados--;
    }
}

function obterNumeroAleatorio(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min) + min)
}

btnContadorAdd.addEventListener('click', btnContadorAddClick)
btnContadorClr.addEventListener('click', btnContadorClrClick)
btnLancarDados.addEventListener('click', btnLancarDadosClick)