import { TestBed } from '@angular/core/testing';
import { MapNavService } from './map-nav.service';
describe('MapNavService', () => {
    let service;
    beforeEach(() => {
        TestBed.configureTestingModule({});
        service = TestBed.inject(MapNavService);
    });
    it('should be created', () => {
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=map-nav.service.spec.js.map