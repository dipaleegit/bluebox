export class  Movie {
    Slug!: string;
    Name!: string;
    Year!: number;
    Description!: string;
    BannerUrl!: string;
    MovieImages!: MovieImage[];
}

export class  MovieImage {
    MovieId!: number;
    ImageUrl!: string;
    IsBanner!: boolean;
}
