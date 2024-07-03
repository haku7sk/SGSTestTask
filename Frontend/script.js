document.addEventListener('DOMContentLoaded', function () {
    const cityWorkshopMap = {
        'Moscow': ['Цех 1', 'Цех 2'],
        'SaintPetersburg': ['Цех 3', 'Цех 4'],
        'Novosibirsk': ['Цех 5', 'Цех 6']
    };

    const workshopEmployeeMap = {
        'Цех 1': ['Сотрудник 1', 'Сотрудник 2'],
        'Цех 2': ['Сотрудник 3', 'Сотрудник 4'],
        'Цех 3': ['Сотрудник 5', 'Сотрудник 6'],
        'Цех 4': ['Сотрудник 7', 'Сотрудник 8'],
        'Цех 5': ['Сотрудник 9', 'Сотрудник 10'],
        'Цех 6': ['Сотрудник 11', 'Сотрудник 12']
    };

    const citySelect = document.getElementById('city');
    const workshopSelect = document.getElementById('workshop');
    const employeeSelect = document.getElementById('employee');

    citySelect.addEventListener('change', function () {
        const selectedCity = citySelect.value;
        updateWorkshopOptions(selectedCity);
    });

    workshopSelect.addEventListener('change', function () {
        const selectedWorkshop = workshopSelect.value;
        updateEmployeeOptions(selectedWorkshop);
    });

    function updateWorkshopOptions(city) {
        workshopSelect.innerHTML = '<option value="">Выберите цех</option>';
        if (city && cityWorkshopMap[city]) {
            cityWorkshopMap[city].forEach(workshop => {
                const option = document.createElement('option');
                option.value = workshop;
                option.textContent = workshop;
                workshopSelect.appendChild(option);
            });
        }
        employeeSelect.innerHTML = '<option value="">Выберите сотрудника</option>';
    }

    function updateEmployeeOptions(workshop) {
        employeeSelect.innerHTML = '<option value="">Выберите сотрудника</option>';
        if (workshop && workshopEmployeeMap[workshop]) {
            workshopEmployeeMap[workshop].forEach(employee => {
                const option = document.createElement('option');
                option.value = employee;
                option.textContent = employee;
                employeeSelect.appendChild(option);
            });
        }
    }

    const form = document.getElementById('dependentForm');
    form.addEventListener('submit', function (event) {
        event.preventDefault();
        const selectedValues = {
            city: citySelect.value,
            workshop: workshopSelect.value,
            employee: employeeSelect.value,
            team: document.getElementById('team').value,
            shift: document.getElementById('shift').value
        };
        document.cookie = `formValues=${JSON.stringify(selectedValues)}; path=/`;
        alert('Значения сохранены в Cookie');
    });
});
