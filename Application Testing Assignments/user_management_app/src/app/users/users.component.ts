import { Component, OnInit } from '@angular/core';
import { UserService } from './user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  providers: [UserService]
})
export class UsersComponent implements OnInit {
  users: any[] = [];
  loading = true;
  error = '';

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getUsers().subscribe({
      next: data => { this.users = data; this.loading = false; },
      error: () => { this.error = 'Failed to fetch users'; this.loading = false; }
    });
  }
}
