<template>
  <div class="p-4 max-w-md mx-auto bg-white shadow-md rounded-lg">
    <form @submit.prevent="saveForm">
      <div class="mb-4">
        <label for="city" class="block text-gray-700">Город:</label>
        <Dropdown
          v-model="selectedCity"
          :options="cities"
          optionLabel="name"
          optionValue="value"
          @change="updateWorkshops"
          placeholder="Выберите город"
          class="w-full"
        />
      </div>

      <div class="mb-4">
        <label for="workshop" class="block text-gray-700">Цех:</label>
        <Dropdown
          v-model="selectedWorkshop"
          :options="workshops"
          optionLabel="name"
          optionValue="value"
          @change="updateEmployees"
          placeholder="Выберите цех"
          class="w-full"
        />
      </div>

      <div class="mb-4">
        <label for="employee" class="block text-gray-700">Сотрудник:</label>
        <Dropdown
          v-model="selectedEmployee"
          :options="employees"
          optionLabel="name"
          optionValue="value"
          placeholder="Выберите сотрудника"
          class="w-full"
        />
      </div>

      <div class="mb-4">
        <label for="team" class="block text-gray-700">Бригада:</label>
        <Dropdown
          v-model="selectedTeam"
          :options="teams"
          optionLabel="name"
          optionValue="value"
          placeholder="Выберите бригаду"
          class="w-full"
        />
      </div>

      <div class="mb-4">
        <label for="shift" class="block text-gray-700">Смена:</label>
        <Dropdown
          v-model="selectedShift"
          :options="shifts"
          optionLabel="name"
          optionValue="value"
          placeholder="Выберите смену"
          class="w-full"
        />
      </div>

      <button
        type="submit"
        class="w-full bg-blue-500 text-white py-2 px-4 rounded hover:bg-blue-700"
      >
        Сохранить
      </button>
    </form>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from "vue";
import Dropdown from "primevue/dropdown";

export default defineComponent({
  components: {
    Dropdown,
  },
  setup() {
    const cities = ref([
      { name: "Москва", value: "Moscow" },
      { name: "Санкт-Петербург", value: "SaintPetersburg" },
      { name: "Новосибирск", value: "Novosibirsk" },
    ]);

    const workshopsMap = {
      Moscow: [
        { name: "Цех 1", value: "Workshop1" },
        { name: "Цех 2", value: "Workshop2" },
      ],
      SaintPetersburg: [
        { name: "Цех 3", value: "Workshop3" },
        { name: "Цех 4", value: "Workshop4" },
      ],
      Novosibirsk: [
        { name: "Цех 5", value: "Workshop5" },
        { name: "Цех 6", value: "Workshop6" },
      ],
    };

    const employeesMap = {
      Workshop1: [
        { name: "Сотрудник 1", value: "Employee1" },
        { name: "Сотрудник 2", value: "Employee2" },
      ],
      Workshop2: [
        { name: "Сотрудник 3", value: "Employee3" },
        { name: "Сотрудник 4", value: "Employee4" },
      ],
      Workshop3: [
        { name: "Сотрудник 5", value: "Employee5" },
        { name: "Сотрудник 6", value: "Employee6" },
      ],
      Workshop4: [
        { name: "Сотрудник 7", value: "Employee7" },
        { name: "Сотрудник 8", value: "Employee8" },
      ],
      Workshop5: [
        { name: "Сотрудник 9", value: "Employee9" },
        { name: "Сотрудник 10", value: "Employee10" },
      ],
      Workshop6: [
        { name: "Сотрудник 11", value: "Employee11" },
        { name: "Сотрудник 12", value: "Employee12" },
      ],
    };

    const selectedCity = ref(null);
    const selectedWorkshop = ref(null);
    const selectedEmployee = ref(null);
    const selectedTeam = ref(null);
    const selectedShift = ref(null);

    const workshops = ref([]);
    const employees = ref([]);

    const teams = ref([
      { name: "Бригада 1", value: "Team1" },
      { name: "Бригада 2", value: "Team2" },
    ]);

    const shifts = ref([
      { name: "Смена 1", value: "Shift1" },
      { name: "Смена 2", value: "Shift2" },
    ]);

    const updateWorkshops = () => {
      workshops.value = selectedCity.value
        ? workshopsMap[selectedCity.value]
        : [];
      selectedWorkshop.value = null;
      employees.value = [];
      selectedEmployee.value = null;
    };

    const updateEmployees = () => {
      employees.value = selectedWorkshop.value
        ? employeesMap[selectedWorkshop.value]
        : [];
      selectedEmployee.value = null;
    };

    const saveForm = () => {
      const formData = {
        city: selectedCity.value,
        workshop: selectedWorkshop.value,
        employee: selectedEmployee.value,
        team: selectedTeam.value,
        shift: selectedShift.value,
      };
      document.cookie = `formValues=${JSON.stringify(formData)}; path=/`;
      alert("Значения сохранены в Cookie");
    };

    return {
      cities,
      workshops,
      employees,
      teams,
      shifts,
      selectedCity,
      selectedWorkshop,
      selectedEmployee,
      selectedTeam,
      selectedShift,
      updateWorkshops,
      updateEmployees,
      saveForm,
    };
  },
});
</script>

<style scoped></style>
