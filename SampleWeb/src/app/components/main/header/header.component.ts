import { Component, OnInit } from '@angular/core';
import { StorageserviceService } from '../../service/storageservice.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  user: any;

  constructor(private storageService: StorageserviceService) {}

  ngOnInit(): void {
    this.user = this.storageService.getCurrentUser();
  }

  public logout(): void {
    this.storageService.logout();
  }
}
