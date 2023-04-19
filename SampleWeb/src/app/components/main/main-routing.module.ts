import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from './main.component';
import { TableinformationComponent } from './tableinformation/tableinformation.component';

const routes: Routes = [
  {
    path: '',
    component: MainComponent,
    children: [
      {
        path: '',
        component: TableinformationComponent,
      },
      {
        path: 'tablero',
        component: TableinformationComponent,
      },
      {
        path: 'component',
        loadChildren: () =>
          import('../../components/student/student.module').then(
            (y) => y.StudentModule
          ),
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MainRoutingModule {}
