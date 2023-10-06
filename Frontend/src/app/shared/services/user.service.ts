import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { User, UserRole } from 'src/app/models/user.model';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private appUser: BehaviorSubject<User | null> =
    new BehaviorSubject<User | null>(null);

  public setCurrentUser(user: User | null) {
    this.appUser.next(user);
  }

  public getCurrentUser() {
    return this.appUser.asObservable();
  }

  public loginFromLocalStorage() {
    const email = localStorage.getItem('email');
    const roleId = localStorage.getItem('roleId');
    const userId = localStorage.getItem('userId');
    if(email && roleId && userId){
      this.setCurrentUser({id: +userId, email, role: +roleId});
    }
  }

  public logOutUser(){
    localStorage.clear();
    this.setCurrentUser(null);
  }
}
