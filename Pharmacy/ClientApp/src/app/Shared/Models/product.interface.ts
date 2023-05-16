import { ICharacteresticModel } from "./characteristictype.interface";

export interface IProduct{
  Id: number;
  Name: string;
  Article: string;
  Description: string;
  Characteristics: ICharacteresticModel[]
}
