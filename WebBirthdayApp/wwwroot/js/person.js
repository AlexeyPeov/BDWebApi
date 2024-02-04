import * as api from 'api.js';

const personId = new URLSearchParams(window.location.search).get('id');

let person = await api.getPerson(personId);
let image = await api.getImage(personId);

let form = displayPerson(person, image);
form.addEventListener('submit', submitForm);

let fileInput = document.getElementById('file-input');
let preview = document.getElementById('preview');

fileInput.addEventListener('change', imgDisplayCb);

function imgDisplayCb () {
    const file = this.files[0];
    if (file) {
        const reader = new FileReader();
        reader.onloadend = function() {
            const img = new Image();
            img.onload = function() {

                const canvas = document.createElement('canvas');
                const ctx = canvas.getContext('2d');

                const minDim = Math.min(img.width, img.height);
                const xOffset = (img.width - minDim) / 2;
                const yOffset = (img.height - minDim) / 2;

                canvas.width = canvas.height = 200;
                ctx.drawImage(img, xOffset, yOffset, minDim, minDim, 0, 0, 200, 200);
                preview.src = canvas.toDataURL();
            }
            img.src = reader.result;
        }
        reader.readAsDataURL(file);
    }
}

async function submitForm(event) {
    event.preventDefault();
    const formData = new FormData(form);
    
    const response = await api.updatePerson(formData, personId);
    if(!response.ok){
        let data = await response.json();
        alert(api.formatErrors(data.errors));
        form = reconfigureForm(form);
    }
    else{
        alert("Данные были успешно изменены!");
    }
}

function reconfigureForm(form){
    form.remove();
    form = displayPerson(person, image);
    form.addEventListener('submit', submitForm);
    fileInput = document.getElementById('file-input');
    preview = document.getElementById('preview');
    fileInput.addEventListener('change', imgDisplayCb);
    return form;
}

document.getElementById('delete-btn').addEventListener('click', async () => {
    let response = await api.deletePerson(personId);
    let data = await response.json();

    if(!response.ok){
        alert(api.formatErrors(data.errors));
    }
    else{
        alert("Данные были успешно удалены, нажмите \"Ок\" чтобы перейти на главную страницу");
        window.location.href = '/';
    }
});

document.getElementById('go-back').addEventListener('click', async () => {
    window.location.href = '/';
});

function displayPerson(person, image) {
    
    const detailsDiv = document.getElementById('person-details');
    detailsDiv.innerHTML = `
        <a>Ваша фотография</a>
        <div><img id="preview" src="${image}" alt="person-image"></div>
        
        <form id="person-form">
        <label>
            Фамилия:
            <input name="SecondName" value="${person.secondName}"required>
        </label>
        <label>
            Имя:
            <input name="Name" value="${person.name}" required>
        </label>
        <label>
            Отчество:
            <input name="Patronymic" value="${person.patronymic}" required>
        </label>
        <label>
            Дата рождения:
           <input name="Birthday" value="${person.birthday}" type="date" required>
        </label>
        <label>
            Фотография:
            <input id="file-input" name="Img" type="file">
        </label>
        <button class="btn" type="submit">Обновить</button>
        <button class="btn" id="delete-btn">Удалить</button>
        </form>           
            `;
    
    return document.getElementById('person-form');
}