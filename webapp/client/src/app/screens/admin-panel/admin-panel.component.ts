import { Component, OnInit } from '@angular/core';
import {CountryService} from "../../services/country-service.service";

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.scss'],
})
export class AdminPanelComponent implements OnInit {
  countries: any[] = [];

  constructor(private countryService: CountryService) {}

  ngOnInit(): void {
    this.getAllCountries();
  }

  getAllCountries(): void {
    this.countryService.GetAll().subscribe({
      next: (response) => {
        if (response.success) {
          this.countries = response.data;
        } else {
          console.error('Error fetching countries:', response.message);
        }
      },
      error: (error) => {
        console.error('API call failed:', error);
      },
    });
  }

}
