import { Observable } from "rxjs"; // dati ricevuti in asincrono
import { Injectable } from "@angular/core"; //dependency injection
import { ICliente, INotaio, IImmobile, IAtto } from "./Interface/IModel";
import { HttpClient, HttpHeaders } from "@angular/common/http"; // modulo apertura canale http

@Injectable()
export class ModelService {
  constructor(private channel: HttpClient) { }

  private uri: string = "https://localhost:7242/Deed/";


  getDeeds(): Observable<Array<IAtto>> {
    return this.channel.get<Array<IAtto>>(this.uri+"deeds");
  }

  getClients(): Observable<Array<ICliente>> {
    return this.channel.get<Array<ICliente>>(this.uri + "clients");
  }

  getEstates(): Observable<Array<IImmobile>> {
    return this.channel.get<Array<IImmobile>>(this.uri + "estates");
  }

  getNoraies(): Observable<Array<INotaio>> {
    return this.channel.get<Array<INotaio>>(this.uri + "notaries");
  }

  ////oggetto da inviare come intestazione della chiamata
  //httpOption = {
  //  headers: new HttpHeaders({
  //    "Content-type": "application/json"
  //  })
  //}

  //postPost(post: any): Observable<any> {

  //  return this.channel.post<Array<IPost>>(this.postsUrl, post, this.httpOption);
  //}

}
