import { Routes } from "@angular/router";
import { ClientiComponent } from "./clienti/clienti.component";
import { NotaiComponent } from "./notai/notai.component";
import { AttiComponent } from "./atti/atti.component";
import { ImmobiliComponent } from "./immobili/immobili.component";


// Regole di routing 
// path = chiamata che arriva al server
// component = componente da montare
// quando arriva un componente, dice di smontare gli altri
export const AppRoutes: Routes = [
  { path: "clienti", component: ClientiComponent },
  { path: "notai", component: NotaiComponent },
  { path: "atti", component: AttiComponent },
  { path: "immobili", component: ImmobiliComponent },
]
