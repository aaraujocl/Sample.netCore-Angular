import { Component, OnInit } from '@angular/core';
import { StorageserviceService } from '../service/storageservice.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css'],
})
export class MainComponent implements OnInit {
  user: any;

  constructor(private storageService: StorageserviceService) {}

  ngOnInit(): void {
    this.user = this.storageService.getCurrentUser();
  }
}
