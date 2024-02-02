const API_ENDPOINT = 'api/people';
const id = new URLSearchParams(window.location.search).get('id');

async function fetchPerson() {
    const response = await fetch(`${API_ENDPOINT}/${id}/get`);
    return await response.json();
}

function displayPerson(person) {
    const detailsDiv = document.getElementById('person-details');
    detailsDiv.innerHTML = `
            <form id="person-form">
                <label>
                    Фамилия:
                    <input name="secondName" value="${person.secondName}">
                </label>
                <label>
                    Имя:
                    <input name="name" value="${person.name}">
                </label>
                <label>
                    Отчество:
                    <input name="patronymic" value="${person.patronymic}">
                </label>
                <label>
                    Дата рождения:
                    <input name="birthday" value="${person.birthday}">
                </label>
            </form>
        `;
}

window.onload = async function() {
    const id = new URLSearchParams(window.location.search).get('id');
    let person = await fetchPerson();
    let originalPerson = { ...person };

    document.getElementById('update-btn').addEventListener('click', async () => {
        const updatedPerson = Object.fromEntries(new FormData(document.getElementById('person-form')));
        if (JSON.stringify(updatedPerson) !== JSON.stringify(person)) {
            let ret = await updatePerson(updatedPerson);
            if(ret !== 204){
                person = await fetchPerson();
                displayPerson(person);
            }
            originalPerson = { ...person };    
        }
        
    });

    document.getElementById('patch-btn').addEventListener('click', async () => {
        const updatedPerson = Object.fromEntries(new FormData(document.getElementById('person-form')));
        const patchDocument = [];

        // Compare updatedPerson with originalPerson and create patch document
        for (let key in updatedPerson) {
            if (updatedPerson[key] !== originalPerson[key]) {
                patchDocument.push({
                    op: "replace",
                    path: `/${key}`,
                    value: updatedPerson[key]
                });
            }
        }

        if (patchDocument.length > 0) {
            let ret = await patchPerson(patchDocument);
            if(ret !== 204){
                person = await fetchPerson();
                displayPerson(person);
            }
            originalPerson = { ...person };
        }
    });

    document.getElementById('delete-btn').addEventListener('click', async () => {
        await deletePerson();
        window.location.href = '/';
    });

    displayPerson(person);
}


async function updatePerson(person) {
    const response = await fetch(`${API_ENDPOINT}/${id}/update`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(person)
    });
    const resp = await response;
    return resp.status;
}

async function patchPerson(patchDocument) {
    const response = await fetch(`${API_ENDPOINT}/${id}/patch`, {
        method: 'PATCH',
        headers: {
            'Content-Type': 'application/json-patch+json'
        },
        body: JSON.stringify(patchDocument)
    });
    const resp = await response;
    return resp.status;
}

async function deletePerson() {
    const response = await fetch(`${API_ENDPOINT}/${id}/delete`, {
        method: 'DELETE'
    });
    const resp = await response;
    return resp.status;
}

