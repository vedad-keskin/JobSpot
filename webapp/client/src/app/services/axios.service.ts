import { Injectable } from '@angular/core';
import axios, { AxiosInstance } from 'axios';
import { environment } from 'src/env/environment';
import { ApiResponse } from './response.interface';

@Injectable({
  providedIn: 'root',
})
export class AxiosService {
  private axiosInstance: AxiosInstance;

  constructor() {
    this.axiosInstance = axios.create({
      baseURL: environment.apiUrl,
    });

    this.axiosInstance.interceptors.request.use(
      (config) => {
        const token = localStorage.getItem('token');

        if (token) {
          config.headers['Authorization'] = `Bearer ${token}`;
        }

        config.headers['Content-Type'] = 'application/json';
        return config;
      },
      (error) => {
        return Promise.reject(error);
      }
    );

    this.axiosInstance.interceptors.response.use(
      (response) => {
        return response;
      },
      (error) => {
        if (error.response && error.response.status === 401) {
          console.error('Unauthorized request');
        }
        return Promise.reject(error);
      }
    );
  }

  get<T>(url: string, config?: any): Promise<T> {
    return this.axiosInstance
      .get(url, config)
      .then((res) => res.data as ApiResponse)
      .catch((e) => e);
  }

  post<T>(url: string, data: any, config?: any): Promise<T> {
    return this.axiosInstance
      .post(url, data, config)
      .then((res) => res.data as ApiResponse)
      .catch((e) => e);
  }
}
