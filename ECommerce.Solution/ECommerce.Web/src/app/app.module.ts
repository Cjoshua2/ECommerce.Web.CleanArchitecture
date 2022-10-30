import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { AuthorizationService } from './core/services/authorization.service';
import { AuthenticationModule } from './modules/authentication/authentication.module';
import { RoutesGuardDirective } from './shared/directives/routes-guard.directive';

const routes: Routes = [
  {
    path: 'authentication',
    loadChildren: () => import('./modules/authentication/authentication.module').then(m => m.AuthenticationModule)
  }
]

@NgModule({
  declarations: [
    AppComponent,
    RoutesGuardDirective
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule,
    AuthenticationModule,
    RouterModule.forRoot(routes)
  ],
  providers: [AuthorizationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
