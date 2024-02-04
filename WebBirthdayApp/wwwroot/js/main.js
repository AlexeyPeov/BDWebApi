import * as api from './api.js';

let numPages = 0;
(async () => { numPages = await api.getPagesAmount(); })();
let sort = document.getElementById('sort');

let pageNum = getPageNum();
sort.value = getSortVal();
sessionStorage.clear();
function getPageNum(){
    let pgn = parseInt(sessionStorage.getItem('pageNum'));
    if(isNaN(pgn))
        return 0;
    return pgn;
    
}
function getSortVal(){
    let s = sessionStorage.getItem('sorted');
    if(s === null)
        s = "false"
    
    return s;
}

displayPeople(await api.getAllPeople(isSorted(),pageNum));


sort.addEventListener('change', async () => {
    displayPeople(await api.getAllPeople(isSorted(), 0));
});

document.getElementById('prev-page').addEventListener('click', async () => {
    if (pageNum > 0) {
        pageNum -= 1;
        displayPeople(await api.getAllPeople(isSorted(), pageNum));
    }
});

document.getElementById('next-page').addEventListener('click', async () => {
    if(pageNum >= numPages)
        return;

    pageNum += 1;
    displayPeople(await api.getAllPeople(isSorted(), pageNum));
});

function displayPeople(people) {
    const appDiv = document.getElementById('app');
    appDiv.innerHTML = '';

    const table = document.createElement('table');
    table.style.width = '100%';
    table.style.tableLayout = 'fixed';

    const thead = document.createElement('thead');
    const headerRow = document.createElement('tr');

    ['Фотография', 'Фамилия', 'Имя', 'Отчество', 'Дата рождения'].forEach(text => {
        const th = document.createElement('th');
        th.textContent = text;
        headerRow.appendChild(th);
    });

    thead.appendChild(headerRow);
    table.appendChild(thead);

    const tbody = document.createElement('tbody');
    for (const person of people) {

        const row = document.createElement('tr');
        row.style.cursor = 'pointer';

        let image = api.image_cache[person.id];

        if(image === undefined){
            image = 'default.jpg';
        }

        if(person.patronymic == null){
            person.patronymic = '-';
        }

        row.innerHTML = `
        
            <td><img src="${image}" alt="img"></td>
            <td class="dots">${truncateText(person.secondName)}</td>
            <td class="dots">${truncateText(person.name)}</td>
            <td class="dots">${truncateText(person.patronymic)}</td>
            <td class="dots">${truncateText(person.birthday)}</td>
            
        `;

        row.addEventListener('click', () => {
            sessionStorage.setItem('pageNum', pageNum);
            sessionStorage.setItem('sorted', isSorted() ? "true" : "false" );
            window.location.href = `/person.html?id=${person.id}`;
        });

        tbody.appendChild(row);
    }
    table.appendChild(tbody);

    appDiv.appendChild(table);
}

function truncateText(text) {
    const maxLength = 15;
    return text.length > maxLength ? text.slice(0, maxLength - 3) + '...' : text;
}

function isSorted(){
    return sort.value === 'true';
}

document.getElementById('add-person').addEventListener('click', () => {
    sessionStorage.setItem('pageNum', pageNum);
    sessionStorage.setItem('sorted', isSorted() ? "true" : "false" );
    window.location.href = `/create.html`;
});