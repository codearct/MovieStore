import axios from "axios";

export default class MovieService {
    getMovies() {
        return axios.get("https://localhost:44363/Movies");
    }
    getMovieById(id) {
        return axios.get(`https://localhost:44363/Movies/${id}`);
    }
}