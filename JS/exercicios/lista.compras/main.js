const itemBase = document.getElementById('itemBase');
const listaComprar = document.getElementById('listaComprar');
const listaComprado = document.getElementById('listaComprado');

const btnComprar = document.getElementById('btnComprar');

var itensIndex = 0;

const btnComprarClick = function () {
    let novoItem = itemBase.cloneNode(true);
    novoItem.classList.remove('item-base')
    novoItem.id = `ITEM_${++itensIndex}`;
    
    listaComprar.appendChild(novoItem)
    
    let botaoStatus = document.querySelector(`#${novoItem.id} button`)
    botaoStatus.addEventListener('click', () => { mudarStatus(novoItem.id) });
}

function mudarStatus(index) {

    let item = document.getElementById(index);
    if (item.classList.contains('comprado')) {
        item.classList.remove('comprado');
        listaComprar.appendChild(item)
    } else {
        item.classList.add('comprado');
        listaComprado.appendChild(item)
    }
}

btnComprar.addEventListener('click', btnComprarClick);
