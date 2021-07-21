import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {};
  registerMode: boolean;
  constructor(public accountService: AccountService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  register(){
    this.accountService.register(this.model).subscribe(response => {
      console.log(response);
      this.toastr.success('You have created an account!');
      this.model = {};
      this.accountService.getUsers();
    }, error => {
        console.log(error);
        if(error.error.errors)
        {
          for(const key in error.error.errors )
            this.toastr.error(error.error.errors[key]);
        }
        else
          this.toastr.error(error.error);
    });
  }

  toggleRegister(){
    this.registerMode = !this.registerMode;
  }
}
