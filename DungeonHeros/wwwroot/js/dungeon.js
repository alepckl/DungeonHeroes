function addMonster(element) {
    let id = element.id;
    const group = document.getElementById('monsterGroup');
    let allCurrent = document.getElementById(`monster${id}`)


    let count = 1;
    group.childNodes.forEach(e => {
            if (e.nodeName === "DIV") count++;
        }
    )
    
    let currentCard = {};
    currentCard.imageSrc = document.getElementById(`monsterImage${id}`).src;
    currentCard.title = document.getElementById(`monsterName${id}`).textContent;
    currentCard.strength = document.getElementById(`monsterStrength${id}`).textContent;
    currentCard.stamina = document.getElementById(`monsterStamina${id}`).textContent;    
    
    let div = document.createElement('div');
    div.className = 'col-xl-3 col-sm-6 mt-4 mb-4';
    const trash = 'https://localhost:7074/assets/trash-fill.svg';
    div.id = `monster${id}`;
    div.innerHTML = `<div class="bg-body rounded shadow-sm px-4 py-5">
                    <div class="d-grid d-md-flex justify-content-md-end">
                        <a id="${id}" class="btn btn-danger mb-3 deleteCardButton" type="button" onclick="removeMonster(this)">
                            <img src="${trash}" alt="" width="30" height="24">
                        </a>
                    </div>
                    <img id="monsterImage${id}" src="${currentCard.imageSrc}" alt="" width="100" class="rounded-circle mb-3 img-fluid  img-thumbnail shadow-sm">
                    <h5 class="mb-0 text-white" id="monsterName${id}">${currentCard.title}</h5>
                    <ul class="mb-0 mt-3">
                        <li class="text-white" id="monsterStrength${id}"><h6>${currentCard.strength}</h6></li>
                        <li class="text-white" id="monsterStamina${id}"><h6>${currentCard.stamina}</h6></li>
                    </ul>
                </div>
            <input name="monsterId[]" type="text" hidden="true" value="${id}"/>`
    
    group.appendChild(div);
    allCurrent.innerHTML = '';
    allCurrent.remove();
}

function removeMonster(element) {
    let id = element.id;
    const toAdd = document.getElementById(`possibleMonsters`);
    const group = document.getElementById('monsterGroup');
    let chosenElement;


    group.childNodes.forEach(e => {
        if (`monster${element.id}` === e.id) {
            chosenElement = e;
        }
    });
    
    
    let currentCard = {};
    currentCard.imageSrc = document.getElementById(`monsterImage${id}`).src;
    currentCard.title = document.getElementById(`monsterName${id}`).textContent;
    currentCard.strength = document.getElementById(`monsterStrength${id}`).textContent;
    currentCard.stamina = document.getElementById(`monsterStamina${id}`).textContent;
    
    let div = document.createElement('div');
    div.className = 'col';
    div.id = `monster${id}`;
    div.innerHTML = `<div class="card">
                            <img id="monsterImage${id}" src="${currentCard.imageSrc}" class="card-img-top" alt="">
                            <div class="card-body bg-body">
                                <h5 id="monsterName${id}" class="card-title">${currentCard.title}</h5>
                                <p id="monsterStrength${id}" class="card-text">${currentCard.strength}</p>
                                <p id="monsterStamina${id}" class="card-text">${currentCard.stamina}</p>
                                <a id="${id}" class="btn btn-primary" onclick="addMonster(this)">Add to dungeon</a>
                            </div>
                        </div>`
    
    toAdd.appendChild(div);
    chosenElement.innerHTML = '';
    chosenElement.remove();
}