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
                    <p id="class${id}" class="card-text">${document.getElementById(`class${id}`).textContent}</p>
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
