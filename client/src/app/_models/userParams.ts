import { User } from "./user";

export class UserParams {
    gender: string;
    minAge = 18;
    maxAge = 99;
    pageNumber = 1;
    pageSize = 5;
    orderBy = 'lastActive';
    CurrentUsername: string;
  static CurrentUsername: any;

    constructor(user: User) {
        this.gender = user.gender === 'female' ? 'male' : 'female';
        this.CurrentUsername = user.username;
    }
}