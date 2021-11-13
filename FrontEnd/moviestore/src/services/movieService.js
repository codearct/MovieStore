import axios from "axios";

export default class MovieService {
    getMovies() {
        return axios.get("https://localhost:5001/Movies");
    }
    getMovieById(id) {
        return axios.get(`https://localhost:5001/Movies/${id}`);
    }
}