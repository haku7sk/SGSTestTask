import { createApp } from "vue";
import App from "./App.vue";
import PrimeVue from "primevue/config";
import "primevue/resources/themes/saga-blue/theme.css"; // выберите тему по вашему вкусу
import "primevue/resources/primevue.min.css";
import "primeicons/primeicons.css";
import "./assets/tailwind.css";

const app = createApp(App);
app.use(PrimeVue);
app.mount("#app");
