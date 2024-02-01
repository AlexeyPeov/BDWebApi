const API_ENDPOINT = 'api/people';

async function fetchData(pageNum = 0) {
    const response = await fetch(`${API_ENDPOINT}/${pageNum}`);
    return await response.json();
}

function displayData(data) {
    const appDiv = document.getElementById('app');
    appDiv.innerHTML = '';

    data.forEach(person => {
        const personDiv = document.createElement('div');
        personDiv.textContent = `${person.name} ${person.secondName} - ${person.birthday}`;
        appDiv.appendChild(personDiv);
    });
}

fetchData().then(displayData);
