import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Table } from '../models/Table'
import { TableService } from '../services/table.service';
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  selectedFile: File = null;
  url: string = "D://Computer Science//Projects//Restaurant Reservation//API//Images//profileimg.png"
  table: Table = {"available": true, "status": ""};
  tableObj :  {
    "available": string,
    "status": string
  } = {"available": "", "status": ""}

  @ViewChild('addForm') addForm: NgForm;

  constructor(private httpClient: HttpClient, private toastr: ToastrService, 
              private tableService: TableService) { }

  ngOnInit(): void {
  }

  onFileSelected(event){
    this.selectedFile = <File>event.target.files[0];
  }

  onFileUpload(){
    const fd = new FormData();
    fd.append('image', this.selectedFile, this.selectedFile.name);
    this.httpClient.post("https://localhost:5001/api/images/upload", fd).subscribe(res => {
      console.log(res + "from client");
    });
  }

  addTable(){
    if(this.tableObj.available === "true")
    {
      this.table.available = true;
    }
    else {
      this.table.available = false;
    }
    this.tableService.addTable(this.table);
  }
}
