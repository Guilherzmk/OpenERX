import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  constructor(private router: Router) {}
  ngOnInit(): void {
    let validation: boolean = getToken();

    if (validation == false) {
    }
  }
}

function getToken(): boolean {
  if (localStorage.getItem('Token') == null) {
    return false;
  } else {
    return true;
  }
}
