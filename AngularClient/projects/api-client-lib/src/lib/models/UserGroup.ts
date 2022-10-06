/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { User } from './User';

export type UserGroup = {
    id?: string | null;
    name?: string | null;
    users?: Array<User> | null;
};
