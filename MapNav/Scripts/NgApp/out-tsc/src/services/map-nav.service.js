import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
let MapNavService = class MapNavService {
    constructor(httpClient) {
        this.httpClient = httpClient;
    }
    getMapNav(input) {
        const headers = new HttpHeaders().set('Content-Type', 'application/json; charset=utf-8');
        return this.httpClient.post("/api/MapNav", `{"data": "${input}"}`, {
            headers: headers
        });
    }
};
MapNavService = __decorate([
    Injectable({
        providedIn: 'root'
    })
], MapNavService);
export { MapNavService };
//# sourceMappingURL=map-nav.service.js.map