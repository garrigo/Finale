import { Component, OnInit, OnChanges, OnDestroy } from '@angular/core';
import { ICliente } from '../Interface/IModel'
import { ModelService } from '../service';

@Component({
  selector: 'app-clienti',
  templateUrl: './clienti.component.html',
  styleUrls: ['./clienti.component.css'],
  providers: [ModelService] // array di servizi, se serve su tutto l'applicativo si mette in app.module.ts
})
export class ClientiComponent implements OnInit {

  constructor(private _IModel: ModelService) { }

  ngOnInit(): void {
    this._IModel.getClients().subscribe(
      (clients) => this.clienti = clients
    );
  }
  cliente: ICliente = {
    clientId : 0,
    name: "",
    surname: "",
    city: "",
    dateOfBirth : ""
  }

  selected: number = 0;
  clienti: Array<ICliente> = [];
  filtrati: Array<ICliente> = [];
  displayedColumns: string[] = ['ID', 'name', 'surname'];
  /* Variabile di appoggio dei post filtrati per userId */
  // filteredPosts : Array<IPost> = [];

  loadClienti() {
    this.filtrati = [];
    /* Filtra tutti i post per userId */
    this.filtrati = this.clienti.filter(
       (post) => post.clientId == this.selected
    );
    console.log(this.filtrati);
  }

  addPost() {
    //this._IModel.postPost(this.neoPost).subscribe(
    //  (post) => console.log(post)
    //);
  }
}
