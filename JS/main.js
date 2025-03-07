const btnExecutar = document.getElementById('executarBtn');

const btnExecutarClick = function () {
    arrays();
}

function bemVindo() {
    let nome = prompt("Qual é o seu nome?");
    return 'Bem-vindo ' + nome + "!";
}

function apresentar() {
    let nome = prompt("Qual é o seu nome?");
    let idade = prompt("Qual é a sua idade?");
    let profissao = prompt("Qual é a sua profissão de objetivo?");

    return `Bem-vindo ${nome}! \nLegal, sua idade é ${idade}\nTomara que você seja um(a) ótimo(a) ${profissao}`;
}

function operadoresMatematicos(numero) {
    let resultado = numero;

    console.log(parseFloat("10") + 10);

    // Executam com base em valores e retornam
    resultado = resultado + 10;
    resultado = resultado - 10;
    resultado = resultado * 10;
    resultado = resultado / 10;

    // Executam a operação com base no valor já existente
    resultado += 10;
    resultado -= 10;
    resultado *= 10;
    resultado /= 10;

    // Atribui uma unidade
    resultado++;
    // Remove uma unidade
    resultado--;

    return resultado;
}

function exerciciosOperadores() {
    // Ex 01
    let numero01 = parseFloat(prompt("Informe um número para soma!"));
    let numero02 = parseFloat(prompt("Informe outro número para soma!"));

    alert(`O resultado da soma é ${numero01 + numero02}`);

    // Ex 02
    numero01 = parseFloat(prompt("Informe um número para subtração!"));
    numero02 = parseFloat(prompt("Informe outro número para subtração!"));

    alert(`O resultado da soma é ${numero01 - numero02}`);

    // Ex 03
    numero01 = parseFloat(prompt("Informe um número para elevação ao quadrado!"));
    alert(`O quadrado do número ${numero01} é igual a ${numero01 * numero01}`)

    // Ex 04
    numero01 = parseFloat(prompt("Informe um número para média!"));
    numero02 = parseFloat(prompt("Informe outro número para média!"));
    let numero03 = parseFloat(prompt("Informe outro número para média!"));

    alert(`A média dos números ${numero01}, ${numero02} e ${numero03} é igual a ${(numero01 + numero02 + numero03) / 3}`)
}

function operadoresComparativos() {
    /*
    == -> Verifica se é igual
    === -> Verifica se é igual, levando em consideração o tipo do dado
    != -> Verifica se é diferente
    !== -> Verifica se é diferente, levando em consideração o tipo do dados
    > -> Maior que
    >= -> Maior ou igual que
    < -> Menor que
    <= -> Menor ou igual que
    */

    // console.log(6 == 6);
    // console.log("6" == 6);
    // console.log("06" == 6);
    // console.log("6" === 6);
    // console.log(6 != "6");
    // console.log(6 !== "6");
    // console.log("6" !== "6");

    // console.log(6 > 2);
    // console.log(6 > "2");
    // console.log(6 >= 2);
    // console.log(6 < 10);
    // console.log(6 <= 2);

    console.log("Valores planos:")
    // Converte um valor para booleano
    console.log(`Zero convertido para booleano, retorna: ${Boolean(0)}`);
    console.log(`Um convertido para booleano, retorna: ${Boolean(1)}`);
    console.log(`Nove convertido para booleano, retorna: ${Boolean(9)}`);
    console.log(`Nove convertido para booleano, retorna: ${Boolean(-9)}`);
    console.log(`Três zeros em uma string convertido para booleano, retorna: ${Boolean("000")}`);
    console.log(`String vazio convertido para booleano, retorna: ${Boolean("")}`);
    console.log(`String com espaço convertido para booleano, retorna: ${Boolean(" ")}`);

    console.log(`Nulo convertido para booleano, retorna: ${Boolean(null)}`);
    console.log(`undefined convertido para booleano, retorna: ${Boolean(undefined)}`);
    
    console.log(`Array vazio convertido para booleano, retorna: ${Boolean([])}`);
    console.log(`Array populado convertido para booleano, retorna: ${Boolean(["Marco", "Professor"])}`);

    console.log(`Objeto vazio convertido para booleano, retorna: ${Boolean({})}`);
    console.log(`Objeto populado convertido para booleano, retorna: ${Boolean({nome: "Marco", profissao: "Professor"})}`);

    alert("Finalizado!");
}

function instrucoes() {
    let nome = prompt("Informe o seu nome!");
    if (nome.trim()) {
        alert("O nome está preenchido!");
    } else {
        alert("O nome não está preenchido!");
    }

    let entrada = undefined;
    do {
    entrada= prompt("Informe algo ou nada para parar!");
    } while (entrada)

    let nomes = ["Marco", "João", "Pedro"]
    for (let i = 0; i < nomes.length; i++) {
        alert(nomes[i])
    }

    for (let nomeLista of nomes) {
        alert(nomeLista)
    }
}

function objetos() {
    let pessoa = {
        nome: "Marco",
    };

    pessoa.idade = prompt("Informe sua idade");

    console.log(pessoa.nome);
    console.log(pessoa["idade"]);
}

function ExercicioObjetoEsquenta() {
    let pessoa = {
        // apresentar: function () {
        //     alert(`Olá, meu nome é ${this.nome}, tenho ${this.idade} anos. Meu CPF é ${this.cpf}!`);
        // },
        apresentar: () => {
            alert(`Olá, meu nome é ${this.nome}, tenho ${this.idade} anos. Meu CPF é ${this.cpf}!`);
        }
    };

    pessoa.nome = prompt("Informe seu nome!");
    pessoa.idade = prompt("Informe sua idade!");
    pessoa.cpf = prompt("Informe seu CPF!");

    return pessoa;
}

function arrays() {
    let array = [1,2,3,4,5];
    console.log(JSON.stringify(array));

    array.push(6);
    console.log(JSON.stringify(array));

    array.pop();
    console.log(JSON.stringify(array));

    array.shift();
    console.log(JSON.stringify(array));

    array.unshift(567);
    console.log(JSON.stringify(array));

    array.forEach(function (elemento, index) {
        console.log(elemento);
        console.log(index);
    });

    let arrayMapeado = array.map(function (elemento, index) {
        return {
            valor: elemento,
            indice: index,
        }
    });

    console.log(JSON.stringify(arrayMapeado));
}

btnExecutar.addEventListener('click', btnExecutarClick)