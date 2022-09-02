import { Component, OnInit } from '@angular/core';

@Component({
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {

  underConstruction = "./src/assets/images/under-construction.png";
  constructor() { }

  ngOnInit(): void {
  }

}
