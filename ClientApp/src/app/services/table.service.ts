import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Table } from '../models/Table';

@Injectable({
  providedIn: 'root'
})
export class TableService {

  constructor(private http: HttpClient, private toastr: ToastrService) { }

  addTable(table: Table){
    return this.http.post("https://localhost:5001/api/tables/add", table).subscribe(res => {
      this.toastr.success("New table has been added successfully");
    }, error => {
      console.log(error);
    });
  }
}
