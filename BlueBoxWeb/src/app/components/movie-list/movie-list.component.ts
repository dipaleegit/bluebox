import { Component, OnInit } from '@angular/core';
import { Movie } from 'src/app/model/movie';
import { MovieService } from 'src/app/services/movie.service';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent implements OnInit {

  data: any;
  movies: any;
  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
    this.getAllTrendingMovies();
  }

  getAllTrendingMovies(): void {
    this.movieService.getAllTrendingMovies().subscribe((data) => {
      this.data = data;
      this.movies= this.data.result;
    });
  }
}
