import { Component, OnInit } from '@angular/core';
import { StudentService } from '../../service/student.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css'],
})
export class StudentListComponent implements OnInit {
  List: any[] = [];
  id: any;

  constructor(private service: StudentService, private router: Router) {}

  ngOnInit(): void {
    this.list();
  }

  list() {
    //this.loading = true;
    this.service.listView().subscribe({
      next: (response) => {
        this.List = response as any[];
        //this.lstAlmacenes.sort();
        //this.dataSource = new MatTableDataSource(this.lstAlmacenes);
        //this.dataSource.paginator = this.paginator;
        //this.LengthTable = this.lstAlmacenes.length;
        //this.sortedData = this.lstAlmacenes.slice();
        //this.loading = false;
      },
      error: (error: HttpErrorResponse) => {
        //this.loading = false;
        if (error.status === 404) {
        } else {
        }
      },
    });
  }
  view(id: any) {
    this.router.navigate(['/main/dashboard/component/student-details/', id]);
  }

  delete() {
    //this.loading = true;
    this.service.delete(this.id).subscribe({
      next: () => {
        this.list();
        //this.loading = false;
        //this.handlePageChange(1);
        //this.listarCategorias();
      },
      error: (error: HttpErrorResponse) => {
        //this.loading = false;
        if (error.status === 404) {
        } else if (error.status === 409) {
        } else {
        }
      },
    });
  }

  parameter(id: any) {
    this.id = id;
  }
}
