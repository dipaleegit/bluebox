import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private httpClient: HttpClient) { }

  getAllTrendingMovies() {
   return this.httpClient.get(environment.baseUrl + 'api/movies/trending/');
  }
}
