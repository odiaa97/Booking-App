import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { User } from '../models/user';
import { AccountService } from '../services/account.service';
import { HomeService } from '../services/home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {


  baseUrl = "https://localhost:5001/api/";
  user: User;
  tables: any = [];
  model: any;
  status1: string = "Available";
  status2: string = "Unavailable"
  constructor(public accountService: AccountService, private httpClient: HttpClient,
              private homeService: HomeService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getUser();
    if(this.user)
    {
      this.getTables();
      console.log("USer");
    }
      
  }

  getUser(){
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
    return this.user;
  }

  getTables() {
    this.httpClient.get(this.baseUrl + "home/tables").subscribe(response => {
      this.tables = response;
    }, error => {
      console.log(error);
    });
  }

  bookToggle(event: MatSlideToggleChange, tableId: any){
    if(event.checked)
      {
        this.model = {
          "id": tableId,
          "available": !event.checked,
          "status": this.status2
        }
      }
      else if(!event.checked)
      {
        this.model = {
          "id": tableId,
          "available": !event.checked,
          "status": this.status1
        }
      }
    
    this.httpClient.put(this.baseUrl + "home/book", this.model).subscribe(response =>{
      if(!event.checked)
      {
        this.toastr.success("You have canceled your reservation");
        this.getTables();
      }
      else if(event.checked)
      {
        this.toastr.success("You have booked the table");
        this.getTables();
      }

    }, error => {
      console.log(error.statusText);
      event.source.checked = !event.checked;
    });
    console.log('toggle', event.checked, tableId);
  }

}
