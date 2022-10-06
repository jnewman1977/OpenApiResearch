import {Component} from '@angular/core';
import {UserGroupService} from "api-client-lib";
import {from, Observable} from "rxjs";
import {User} from 'api-client-lib';
import {map} from "rxjs/operators";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'angular-client';

  public groups$ = this.userGroupService.getUserGroup();
  public users$: Observable<User[]> = from([]);

  constructor(private userGroupService: UserGroupService) {
  }

  public getUsers(groupId: string | null | undefined): void {
    console.log(`Group Id = ${groupId}`);
    if (!groupId) {
      return;
    }
    this.users$ = this.userGroupService.getUserGroupUsers(groupId);
  }
}
