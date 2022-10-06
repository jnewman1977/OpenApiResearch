/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import { NgModule} from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AngularHttpRequest } from './core/AngularHttpRequest';
import { BaseHttpRequest } from './core/BaseHttpRequest';
import type { OpenAPIConfig } from './core/OpenAPI';
import { OpenAPI } from './core/OpenAPI';

import { UserGroupService } from './services/UserGroupService';
import { WeatherForecastService } from './services/WeatherForecastService';

@NgModule({
    imports: [HttpClientModule],
    providers: [
        {
            provide: OpenAPI,
            useValue: {
              // BASE: OpenAPI?.BASE ?? '',
                BASE: 'https://localhost:7210',
                VERSION: OpenAPI?.VERSION ?? '1.0',
                WITH_CREDENTIALS: OpenAPI?.WITH_CREDENTIALS ?? false,
                CREDENTIALS: OpenAPI?.CREDENTIALS ?? 'include',
                TOKEN: OpenAPI?.TOKEN,
                USERNAME: OpenAPI?.USERNAME,
                PASSWORD: OpenAPI?.PASSWORD,
                HEADERS: OpenAPI?.HEADERS,
                ENCODE_PATH: OpenAPI?.ENCODE_PATH,
            } as OpenAPIConfig,
        },
        {
            provide: BaseHttpRequest,
            useClass: AngularHttpRequest,
        },
        UserGroupService,
        WeatherForecastService,
    ]
})
export class ApiClientModule {}
