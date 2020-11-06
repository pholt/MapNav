import { Component } from '@angular/core';
import { FormControl } from '@angular/forms'
import { MapNavService } from '../services/map-nav.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'MapNavFE';
  public input: FormControl;
  public output: string;

  constructor(
    private mapNavService: MapNavService
  ) { 
    this.input = new FormControl("L3, R2, L5, R1, L1, L2");
  }

  public getDistance() {
    this.mapNavService.getMapNav(this.input.value).subscribe(result => {
      let obj: {data:string} = JSON.parse(result);
      this.output = obj.data;
    });
  }

}
