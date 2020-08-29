import { Component, Inject } from '@angular/core';

@Component({
  selector: 'admin-component',
  templateUrl:'Pages/Admin'
})

export class AdminComponent{

}

interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
