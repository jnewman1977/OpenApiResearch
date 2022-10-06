/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import type { Observable } from 'rxjs';

import type { User } from '../models/User';
import type { UserGroup } from '../models/UserGroup';

import { BaseHttpRequest } from '../core/BaseHttpRequest';

@Injectable()
export class UserGroupService {

    constructor(public readonly httpRequest: BaseHttpRequest) {}

    /**
     * @returns UserGroup Success
     * @throws ApiError
     */
    public getUserGroup(): Observable<Array<UserGroup>> {
        return this.httpRequest.request({
            method: 'GET',
            url: '/UserGroup',
        });
    }

    /**
     * @param id
     * @returns User Success
     * @throws ApiError
     */
    public getUserGroupUsers(
id: string,
): Observable<Array<User>> {
        return this.httpRequest.request({
            method: 'GET',
            url: '/UserGroup/{id}/users',
            path: {
                'id': id,
            },
        });
    }

}
