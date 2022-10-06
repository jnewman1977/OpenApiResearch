/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import type { Observable } from 'rxjs';

import type { WeatherForecast } from '../models/WeatherForecast';

import { BaseHttpRequest } from '../core/BaseHttpRequest';

@Injectable()
export class WeatherForecastService {

    constructor(public readonly httpRequest: BaseHttpRequest) {}

    /**
     * @returns WeatherForecast Success
     * @throws ApiError
     */
    public getWeatherForecast(): Observable<Array<WeatherForecast>> {
        return this.httpRequest.request({
            method: 'GET',
            url: '/WeatherForecast',
        });
    }

}
