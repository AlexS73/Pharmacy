import {Injectable} from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { ICharacteresticTypeModel } from "../Models/characteristictype.interface";

@Injectable()
export class CharacteristicService{

    constructor(private httpClient: HttpClient) {
    }

    public GetTypes(): Observable<ICharacteresticTypeModel[]>{
        return this.httpClient.get<ICharacteresticTypeModel[]>('/api/characteristic');
    }

    public SaveType(type: ICharacteresticTypeModel): Observable<ICharacteresticTypeModel>{
        return this.httpClient.post<ICharacteresticTypeModel>('/api/characteristic', type);
    }

}