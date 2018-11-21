import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-po-item-detail',
    templateUrl: './poitem-detail.component.html'
})
export class PoItemDetailComponent {
    public poitemdetails: PoItemDetails[];

    constructor(
        http: HttpClient,
        @Inject('BASE_URL') baseUrl: string,
        route: ActivatedRoute
    ) {

        route.params.subscribe(params => {
            console.log(params['id']);
            http.get<PoItemDetails[]>(baseUrl + 'api/Po/getitemdetail/' + params['id']).subscribe(result => {
                this.poitemdetails = result;
            }, error => console.error(error));
        })

    }
}

interface PoItemDetails {
    orderItemDetailId: number;
    orderItemId: number;
    branch: string;
    qtyAvailable: number;
    itemDetailStatus: string;
    etadate: Date;
    lastUpdatedDate: Date;
}
