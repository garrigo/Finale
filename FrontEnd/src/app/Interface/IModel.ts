export interface IPersona {
  name: string;
  surname: string;
  city: string;
  dateOfBirth: string;
}

export interface ICliente extends IPersona{
  clientId: number;


}

export interface INotaio extends IPersona {
  notaryId: number;
}

export interface IImmobile {
  realEstateId: string;
  city: string;
  address: string;
  mq: number;
  price: number;
}

export interface IAtto {
  cliente: ICliente;
  notaio: INotaio;
  immobile: IImmobile
}
