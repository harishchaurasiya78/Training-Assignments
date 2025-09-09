import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class TaskService {
  private api = 'https://jsonplaceholder.typicode.com/todos?_limit=5';
  constructor(private http: HttpClient) {}
  getTasks(): Observable<any[]> {
    return this.http.get<any[]>(this.api);
  }
}
