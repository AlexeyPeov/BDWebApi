const API_ENDPOINT = 'api/people';
var pageNum = 0;

var numPages = 0;
(async () => {
    numPages = await (await fetch(`${API_ENDPOINT}/pages_amount`)).json();
})();
var cacheUnsorted = {};
var cacheSorted = {};

async function fetchData(sort = false, pageNum = 0) {
    var sorted = document.getElementById('sort').value === 'true';
    var cache = sorted ? cacheSorted : cacheUnsorted;
    
    if (cache[pageNum])
        return cache[pageNum];
    
    const response = await fetch(`${API_ENDPOINT}/${pageNum}` + (sort ? "?s=bd" : ""));
    const data = await response.json();
    cache[pageNum] = data;
    return data;
}

function displayData(data) {
    const appDiv = document.getElementById('app');
    appDiv.innerHTML = '';

    // Create table
    const table = document.createElement('table');

    // Create table header
    const thead = document.createElement('thead');
    const headerRow = document.createElement('tr');
    ['Фамилия', 'Имя', 'Отчество', 'Дата рождения'].forEach(text => {
        const th = document.createElement('th');
        th.textContent = text;
        headerRow.appendChild(th);
    });
    thead.appendChild(headerRow);
    table.appendChild(thead);

    // Create table body
    const tbody = document.createElement('tbody');
    data.forEach(person => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${person.secondName}</td>
            <td>${person.name}</td>
            <td>${person.patronymic}</td>
            <td>${person.birthday}</td>
        `;
        row.addEventListener('click', () => {
            window.location.href = `/person.html?id=${person.id}`;
        });
        tbody.appendChild(row);
    });
    table.appendChild(tbody);

    appDiv.appendChild(table);
}

document.getElementById('sort').addEventListener('change', () => {
    fetchData(document.getElementById('sort').value === 'true', pageNum).then(displayData);
});

document.getElementById('prev-page').addEventListener('click', () => {
    if (pageNum > 0) {
        pageNum--;
        fetchData(document.getElementById('sort').value === 'true', pageNum).then(displayData);
    }
});

document.getElementById('next-page').addEventListener('click', () => {
    if(pageNum >= numPages)
        return;
    
    pageNum += 1;
    fetchData(document.getElementById('sort').value === 'true', pageNum).then(displayData);
});

fetchData().then(displayData);
