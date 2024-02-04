export const base_endpoint = '/api/people';
export let image_cache = {}

export async function getAllPeople(sort = false, page = 0) {
    const endpoint =`${base_endpoint}/${page}` + (sort ? "?s=bd" : "");
    
    const response = await fetch(endpoint);
    const data = await response.json();
    
    for(const person of data){
        if(person.imgId !== null && image_cache[person.id] === undefined)
            await getImage(person.id);
    }
    
    return data;
}

export async function getImage(id) {
    const response = await fetch(`${base_endpoint}/${id}/get_image`);

    if (!response.ok) {
        return 'default.jpg';
    }

    const blob = await response.blob();

    return new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.onloadend = function() {
            image_cache[id] = reader.result;
            resolve(image_cache[id]);
        }
        reader.onerror = reject;
        reader.readAsDataURL(blob);
    });
    
}

export async function create_person(form_data){
    return await fetch(`/api/people/create`, {
        method: 'POST',
        body: form_data
    });
}

export async function updatePerson(form_data, id){
    return await fetch(`/api/people/${id}/update`, {
        method: 'PUT',
        body: form_data
    });
}

export async function patchPerson(patch_doc, id) {
    return await fetch(`${base_endpoint}/${id}/patch`, {
        method: 'PATCH',
        headers: {
            'Content-Type': 'application/json-patch+json'
        },
        body: JSON.stringify(patch_doc)
    });
}

export async function patchImage(patch_doc, id) {
    return await fetch(`${base_endpoint}/${id}/patch_img`, {
        method: 'PATCH',
        body: patch_doc
    });
}

export async function getPerson(id) {
    const response = await fetch(`${base_endpoint}/${id}/get`);
    if(response.status !== 200)
        return undefined;
    
    return await response.json();
}

export async function deletePerson(id) {
    return await fetch(`${base_endpoint}/${id}/delete`, {
        method: 'DELETE'
    });
}

export async function getPagesAmount(){
    const response = await fetch(`${base_endpoint}/pages_amount`);
    if(response.status !== 200)
        return undefined;
    
    return response.json();
}

export function formatErrors(errors) {
    let formattedErrors = "Одна или более ошибок валидации.\n";
    for (let field in errors) {
        if (errors.hasOwnProperty(field)) {
            formattedErrors += errors[field].join('\n') + '\n';
        }
    }
    return formattedErrors;
}