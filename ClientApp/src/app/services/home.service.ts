import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  tables: any = [];
  baseUrl: string = "https://localhost:5001/api/";
  constructor(private accountService: AccountService, private httpClient: HttpClient) { }
  getTables() {
    this.httpClient.get(this.baseUrl + "home/tables").subscribe(response => {
      this.tables = response;
    }, error => {
      console.log(error);
    });
  }
}
