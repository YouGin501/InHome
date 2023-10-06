import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class TranslateService {

  data: any = {};
  currentLanguage: BehaviorSubject<string> = new BehaviorSubject<string>('en');

  constructor(private http: HttpClient) {}

  getCurrentLanguage(){
    return this.currentLanguage.asObservable();
  }

  use(lang: string): Promise<{}> {
    this.currentLanguage.next(lang);
    return new Promise<{}>(resolve => {
      const langPath = `../../assets/languages/${lang || 'en'}.json`;

      this.http.get(langPath).subscribe(
        response => {
          this.data = response || {};
          resolve(this.data);
        },
        err => {
          this.data = {};
          resolve(this.data);
        }
      );
    });
  }
}