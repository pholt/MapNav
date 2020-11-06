import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
let AppComponent = class AppComponent {
    constructor(mapNavService) {
        this.mapNavService = mapNavService;
        this.title = 'MapNavFE';
        this.input = new FormControl("L3, R2, L5, R1, L1, L2");
    }
    getDistance() {
        this.mapNavService.getMapNav(this.input.value).subscribe(result => {
            let obj = JSON.parse(result);
            this.output = obj.data;
        });
    }
};
AppComponent = __decorate([
    Component({
        selector: 'app-root',
        templateUrl: './app.component.html',
        styleUrls: ['./app.component.css']
    })
], AppComponent);
export { AppComponent };
//# sourceMappingURL=app.component.js.map