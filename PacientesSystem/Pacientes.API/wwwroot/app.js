"use strict";

const API_URL = "/api/patients";

const patientForm = document.getElementById("patientForm");
const patientId = document.getElementById("patientId");
const firstName = document.getElementById("firstName");
const lastName = document.getElementById("lastName");
const identification = document.getElementById("identification");
const birthDate = document.getElementById("birthDate");
const phone = document.getElementById("phone");
const address = document.getElementById("address");

const patientsTable = document.getElementById("patientsTable");
const patientCount = document.getElementById("patientCount");
const searchInput = document.getElementById("searchInput");
const refreshButton = document.getElementById("refreshButton");
const saveButton = document.getElementById("saveButton");
const cancelButton = document.getElementById("cancelButton");
const formTitle = document.getElementById("formTitle");

let patients = [];

async function loadPatients() {
    patientsTable.innerHTML = `
        <tr>
            <td colspan="5" class="empty">
                Cargando pacientes...
            </td>
        </tr>
    `;

    try {
        const response = await fetch(API_URL);

        if (!response.ok) {
            throw new Error("No se pudieron consultar los pacientes.");
        }

        patients = await response.json();

        renderPatients();
    } catch (error) {
        patientsTable.innerHTML = `
            <tr>
                <td colspan="5" class="empty">
                    Error al cargar los pacientes.
                </td>
            </tr>
        `;

        patientCount.textContent = "Sin conexión";
        alert(error.message);
    }
}

function renderPatients() {
    const search = searchInput.value.trim().toLowerCase();

    const filteredPatients = patients.filter(patient => {
        const fullName =
            `${patient.firstName} ${patient.lastName}`.toLowerCase();

        const document =
            (patient.identification || "").toLowerCase();

        return fullName.includes(search) ||
            document.includes(search);
    });

    patientCount.textContent =
        `${patients.length} paciente${patients.length === 1 ? "" : "s"}`;

    patientsTable.innerHTML = "";

    if (filteredPatients.length === 0) {
        const row = document.createElement("tr");
        const cell = document.createElement("td");

        cell.colSpan = 5;
        cell.className = "empty";
        cell.textContent = search
            ? "No se encontraron pacientes con esa búsqueda."
            : "Todavía no hay pacientes registrados.";

        row.appendChild(cell);
        patientsTable.appendChild(row);
        return;
    }

    filteredPatients.forEach(patient => {
        const row = document.createElement("tr");

        const values = [
            patient.id,
            `${patient.firstName} ${patient.lastName}`,
            patient.identification,
            patient.phone || "No registrado"
        ];

        values.forEach(value => {
            const cell = document.createElement("td");
            cell.textContent = value;
            row.appendChild(cell);
        });

        const actionsCell = document.createElement("td");

        const editButton = document.createElement("button");
        editButton.type = "button";
        editButton.className = "btn-edit";
        editButton.textContent = "Editar";
        editButton.addEventListener("click", () => editPatient(patient.id));

        const deleteButton = document.createElement("button");
        deleteButton.type = "button";
        deleteButton.className = "btn-delete";
        deleteButton.textContent = "Eliminar";
        deleteButton.addEventListener("click", () => deletePatient(patient.id));

        actionsCell.appendChild(editButton);
        actionsCell.appendChild(deleteButton);
        row.appendChild(actionsCell);

        patientsTable.appendChild(row);
    });
}

function getFormData() {
    return {
        firstName: firstName.value.trim(),
        lastName: lastName.value.trim(),
        identification: identification.value.trim(),
        birthDate: birthDate.value
            ? `${birthDate.value}T00:00:00`
            : "2000-01-01T00:00:00",
        phone: phone.value.trim(),
        address: address.value.trim()
    };
}

patientForm.addEventListener("submit", async (event) => {
    event.preventDefault();

    const id = patientId.value;
    const isEditing = id !== "";

    const patientData = getFormData();

    const url = isEditing
        ? `${API_URL}/${id}`
        : API_URL;

    const method = isEditing ? "PUT" : "POST";

    saveButton.disabled = true;
    saveButton.textContent = "Guardando...";

    try {
        const response = await fetch(url, {
            method: method,
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(patientData)
        });

        if (!response.ok) {
            const message = await response.text();

            throw new Error(
                message || "No se pudo guardar el paciente."
            );
        }

        alert(isEditing
            ? "Paciente actualizado correctamente."
            : "Paciente registrado correctamente.");

        resetForm();
        await loadPatients();

    } catch (error) {
        alert(`Error: ${error.message}`);
    } finally {
        saveButton.disabled = false;

        saveButton.textContent = patientId.value
            ? "Actualizar paciente"
            : "Guardar paciente";
    }
});

async function editPatient(id) {
    try {
        const response = await fetch(`${API_URL}/${id}`);

        if (!response.ok) {
            throw new Error("No se pudo consultar el paciente.");
        }

        const patient = await response.json();

        patientId.value = patient.id;
        firstName.value = patient.firstName || "";
        lastName.value = patient.lastName || "";
        identification.value = patient.identification || "";
        birthDate.value = patient.birthDate
            ? patient.birthDate.substring(0, 10)
            : "";
        phone.value = patient.phone || "";
        address.value = patient.address || "";

        formTitle.textContent = "Editar paciente";
        saveButton.textContent = "Actualizar paciente";
        cancelButton.hidden = false;

        patientForm.scrollIntoView({
            behavior: "smooth",
            block: "center"
        });

        firstName.focus();

    } catch (error) {
        alert(`Error: ${error.message}`);
    }
}

async function deletePatient(id) {
    const patient = patients.find(p => p.id === id);

    if (!patient) {
        alert("Paciente no encontrado.");
        return;
    }

    const confirmed = confirm(
        `¿Deseas eliminar a ${patient.firstName} ${patient.lastName}?\n\n` +
        "Esta acción no se puede deshacer."
    );

    if (!confirmed) {
        return;
    }

    try {
        const response = await fetch(`${API_URL}/${id}`, {
            method: "DELETE"
        });

        if (!response.ok) {
            const message = await response.text();

            throw new Error(
                message || "No se pudo eliminar el paciente."
            );
        }

        alert("Paciente eliminado correctamente.");

        if (patientId.value === String(id)) {
            resetForm();
        }

        await loadPatients();

    } catch (error) {
        alert(`Error: ${error.message}`);
    }
}

function resetForm() {
    patientForm.reset();
    patientId.value = "";

    formTitle.textContent = "Registrar paciente";
    saveButton.textContent = "Guardar paciente";
    cancelButton.hidden = true;
}

searchInput.addEventListener("input", renderPatients);

refreshButton.addEventListener("click", loadPatients);

cancelButton.addEventListener("click", resetForm);

document.addEventListener("DOMContentLoaded", loadPatients);