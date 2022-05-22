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

// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function onStaminaChanged() {
    let staminaValue = document.getElementById('inputStamina');
    let strengthValue = document.getElementById('inputStrength');

    // Je ne sais pas pourquoi le switch n'allait pas ? 
    if (staminaValue.value >= 7) {
        strengthValue.value = 0;
        staminaValue.value = 7;
    } else if (staminaValue.value == 6) {
        strengthValue.value = 1;
    } else if (staminaValue.value == 5) {
        strengthValue.value = 2;
    } else if (staminaValue.value == 4) {
        strengthValue.value = 3;
    } else if (staminaValue.value == 3) {
        strengthValue.value = 4;
    } else if (staminaValue.value == 2) {
        strengthValue.value = 5;
    } else if (staminaValue.value == 1) {
        strengthValue.value = 6;
    } else if (staminaValue.value == 0) {
        strengthValue.value = 7;
    }
}

function onStrengthChanged() {
    let strengthVal = document.getElementById('inputStrength');
    let staminaVal = document.getElementById('inputStamina');

    // Je ne sais pas pourquoi le switch n'allait pas ? 
    if (strengthVal.value >= 7) {
        staminaVal.value = 0;
        strengthVal.value = 7;
    } else if (strengthVal.value == 6) {
        staminaVal.value = 1;
    } else if (strengthVal.value == 5) {
        staminaVal.value = 2;
    } else if (strengthVal.value == 4) {
        staminaVal.value = 3;
    } else if (strengthVal.value == 3) {
        staminaVal.value = 4;
    } else if (strengthVal.value == 2) {
        staminaVal.value = 5;
    } else if (strengthVal.value == 1) {
        staminaVal.value = 6;
    } else if (strengthVal.value == 0) {
        staminaVal.value = 7;
    }
}


function addPlayer(element) {
    let team = document.getElementById('team');
    const popupButton = document.getElementById('popup');

    let count = 1;
    team.childNodes.forEach(e => {
            if (e.nodeName === "DIV") count++;
        }
    )
    if (count === 4) {
        popupButton.click();
    } else {
        let id = element.id;
        let currentCard = {};
        currentCard.imageSrc = document.getElementById(`image${id}`).src;

        currentCard.title = document.getElementById(`name${id}`).textContent;
        currentCard.class = document.getElementById(`class${id}`).textContent;
        currentCard.race = document.getElementById(`race${id}`).textContent;
        currentCard.level = document.getElementById(`niveau${id}`).textContent;
        currentCard.strength = document.getElementById(`force${id}`).textContent;
        currentCard.stamina = document.getElementById(`endurance${id}`).textContent;

        let div = document.createElement('div');
        let trash = 'https://localhost:7074/assets/trash-fill.svg';
        div.className = 'col-xl-3 col-sm-6 mt-4 mb-4';
        div.id = `Member${id}`;
        div.innerHTML = `
                <div class="bg-body rounded shadow-sm px-4 py-5">
                    <div class="d-grid d-md-flex justify-content-md-end">
                        <a id="${id}" class="btn btn-danger mb-3 deleteCardButton" type="button" onclick="removePlayer(this)">
                            <img id="trash${id}" class="${++count}" src="${trash}" alt="trash" width="30" height="24">
                        </a>
                    </div>
                    <img id="image${id}" src="${currentCard.imageSrc}" alt="" width="100" height="100px" class="img-fluid rounded-circle mb-3 img-thumbnail shadow-sm">
                    <h5 class="mb-0 text-white" id="name${id}">${currentCard.title}</h5><span class="small text-uppercase text-muted" id="classe${id}">${currentCard.class}</span>
                    <ul class="mb-0 mt-3">
                        <li class="text-white" id="race${id}"><h6>${currentCard.race}</h6></li>
                        <li class="text-white" id="level${id}"><h6>${currentCard.level}</h6></li>
                        <li class="text-white" id="strength${id}"><h6>${currentCard.strength}</h6></li>
                        <li class="text-white" id="stamina${id}"><h6>${currentCard.stamina}</h6></li>
                    </ul>
                </div>
                <input id="" name="players[]" type="text" hidden="true" value="${id}"/>`

        team.appendChild(div);
        let toDelete = document.getElementById(`player${id}`);
        document.getElementById(`form${count}`)
        toDelete.innerHTML = '';
        toDelete.remove();
    }
}

function removePlayer(element) {
    let team = document.getElementById('team');
    let id = element.id;
    let chosenElement;

    team.childNodes.forEach(e => {
        if (`Member${element.id}` === e.id) {
            chosenElement = e;
        }
    });
    console.log(chosenElement)

    let players = document.getElementById('possiblePlayers');

    let count = 0;
    players.childNodes.forEach(e => {
        if(e.nodeName === 'DIV') {
            count++;
        }
    })

    let newElement = document.createElement('div');
    newElement.className = 'col';
    newElement.id = `player${id}`;
    newElement.innerHTML = `<div class="card">
                <img id="image${id}" src="${document.getElementById(`image${id}`).src}" class="card-img-top" alt="userImage">
                <div class="card-body">
                    <h5 id="name${id}" class="card-title">${document.getElementById(`name${id}`).textContent}</h5>
                    <p id="class${id}" class="card-text">${document.getElementById(`classe${id}`).textContent}</p>
                    <p id="race${id}" class="card-text">${document.getElementById(`race${id}`).textContent}</p>
                    <p id="niveau${id}" class="card-text">${document.getElementById(`level${id}`).textContent}</p>
                    <p id="force${id}" class="card-text">${document.getElementById(`strength${id}`).textContent}</p>
                    <p id="endurance${id}" class="card-text">${document.getElementById(`stamina${id}`).textContent}</p>
                    <a href="#" id="${id}" class="btn btn-primary" onclick="addPlayer(this)">Add to my team</a>
                </div>
            </div>`;

    let form = document.getElementById('');

    players.appendChild(newElement);
    chosenElement.innerHTML = '';
    chosenElement.remove();
}

function check() {
    document.getElementById("sumbitForm").click();
}

function editValue(element) {
    let id = element.id;
    let formBtn = document.querySelector(`.${id}`).click();
    formBtn.click();

}

