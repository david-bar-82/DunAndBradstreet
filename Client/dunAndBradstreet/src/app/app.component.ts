import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit {
  items = Array<any>();
  pageOfItems!: Array<any>;
  query: string | undefined;
  searchQuery: string = '';

  constructor(private http: HttpClient) { }

  ngOnInit() {
      // an example array of 150 items to be paged
      //this.items = Array(150).fill(0).map((x, i) => ({ id: (i + 1), name: `Item ${i + 1}`}));
  }

  onChangePage(pageOfItems: Array<any>) {
      // update current page of items
      this.pageOfItems = pageOfItems;
  }

  onKey(event: any) { 
    this.query = event.target.value ;
  }

  SearchServer(){
    this.http.get<any>('https://localhost:5001/Search?query=' + this.query).subscribe(data => {
        console.log(data);
            this.items = data.searchResults;
        })
   }
}
