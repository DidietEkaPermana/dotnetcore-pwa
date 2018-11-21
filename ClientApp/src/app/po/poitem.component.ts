import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-po-item',
    templateUrl: './poitem.component.html'
})
export class PoItemComponent {
    public poitems: PoItems[];

    constructor(
        http: HttpClient,
        @Inject('BASE_URL') baseUrl: string,
        route: ActivatedRoute
    ) {

        route.params.subscribe(params => {
            console.log(params['id']);
            http.get<PoItems[]>(baseUrl + 'api/Po/getitem/' + params['id']).subscribe(result => {
                this.poitems = result;
            }, error => console.error(error));
        })

    }

    viewItem(arg) {
        alert(arg);
    }
}

interface PoItems {
    orderItemId: number;
    orderId: number;
    partNo: string;
    qtyOrder: number;
    qtyAvailable: number;
    partDescription: string;
    itemStatus: string;
    lastUpdatedDate: Date;
}
