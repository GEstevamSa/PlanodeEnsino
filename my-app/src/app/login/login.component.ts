import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import {MatDialog} from '@angular/material';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  constructor(private router: Router) { }
username: string;
password: string;
  ngOnInit() {
  }
  login(): void {
// tslint:disable-next-line: triple-equals
    if (this.username == 'admin' && this.password == 'admin') {
     this.router.navigate(['app']);
    } else {
      alert('Invalid credentials');
    }
  }
}

