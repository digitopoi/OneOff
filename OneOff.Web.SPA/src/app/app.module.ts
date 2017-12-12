//  Angular Modules
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';

//  Material Components
import {
        MatToolbarModule,
        MatButtonModule,
        MatFormFieldModule,
        MatInputModule
} from '@angular/material';

//  Angular Components
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { AuthService } from './services/auth.service';
import { LandingComponent } from './components/landing/landing.component';
import { ArtistComponent } from './components/artist/artist.component';
import { VenueComponent } from './components/venue/venue.component';
import { ArtistUserInputComponent } from './components/artist/artist-user-input/artist-user-input.component';

const routes = [
  { path: 'venue', component: VenueComponent },
  { path: 'venue/*', component: VenueComponent },
  { path: 'artist', component: ArtistComponent },
  { path: 'artist/*', component: ArtistComponent },
  { path: '**', component: LandingComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    RegistrationComponent,
    LandingComponent,
    ArtistComponent,
    ArtistUserInputComponent,
    VenueComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(routes),
    ReactiveFormsModule,
    HttpModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatToolbarModule,
    MatFormFieldModule,
    MatInputModule
  ],
  providers: [
    AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
