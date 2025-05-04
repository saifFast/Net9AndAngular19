import { Component, OnInit } from '@angular/core';
import { ApiService } from './api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'AngularProject1';
  data: any;
  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.apiService.getData().subscribe(response => {
      this.data = response
    });
  }
}
