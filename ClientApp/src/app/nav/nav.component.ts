import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../services/account.service';
import { User } from '../models/user';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { HomeService } from '../services/home.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};
  users: any;
  user: User;
  constructor(public accountService: AccountService, private httpClient: HttpClient,
              private router: Router, private toastr: ToastrService, 
              private homeService: HomeService) {
  }

  ngOnInit(): void {
    this.setCurrentUser();
    //this.getUser();
  }

  getUser(){
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
    return this.user;
  }

  login(){
    this.accountService.login(this.model).subscribe(response => {
      this.getUser();
      this.router.navigateByUrl('/tables');
      this.toastr.success(`Welcome, ${this.user.username}`);
      this.model = {};
    }, error => {
      console.log(error);
      this.toastr.error("Invalid username or password");
    });
  }

  setCurrentUser(){
    this.user = JSON.parse(localStorage.getItem('user'));
    this.accountService.setCurrentUser(this.user);
  }
  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/');
    this.toastr.success('You have logged out!');
  }
}