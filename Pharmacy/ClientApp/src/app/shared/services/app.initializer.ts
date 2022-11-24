import {UserService} from './user.service';

/*export function AppInitializer(userService: UserService) {
  return () => new Promise(resolve => {
    // attempt to refresh token on app start up to auto authenticate
    userService.RefreshToken()
      .subscribe()
      .add(resolve);
  });
}*/

export function initializeApp(): Promise<any> {
  return new Promise((resolve, reject) => {
    // Do some asynchronous stuff
    resolve();
  });
}
