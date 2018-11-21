import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-po-header',
    templateUrl: './poheader.component.html'
})
export class PoHeaderComponent {
    public poheaders: PoHeaders[];

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        http.get<PoHeaders[]>(baseUrl + 'api/Po/getheader').subscribe(result => {
            this.poheaders = result;
        }, error => console.error(error));
    }
}

interface PoHeaders {
    ponumber: number;
    orderNumber: number;
    orderDate: Date;
    eta: Date;
    lastUpdatedDate: Date;
    orderId: number;
}
