import React from 'react';
import { useState, useEffect } from "react";
import { Card, Image } from 'semantic-ui-react';
import MovieService from '../services/movieService';
import { NavLink } from 'react-router-dom';

export default function MovieList() {

    const [movies, setMovies] = useState([]);

    useEffect(() => {
        let movieService = new MovieService();
        movieService.getMovies()
            .then(result => setMovies(result.data))
    }, [])

    return (
        <div>
            <Card.Group itemsPerRow={4}>
                {
                    movies.map(movie => (
                        <Card key={movie.id} as={NavLink} to={`/movies/${movie.id}`}>
                            <Image src={`https://picsum.photos/id/${movie.id}/100`} wrapped ui={false} />
                            <Card.Content>
                                <Card.Header>{movie.title}</Card.Header>
                                <Card.Meta>{movie.releaseDate}</Card.Meta>
                                <Card.Description>
                                    movie description_?
                                </Card.Description>
                            </Card.Content>
                        </Card>
                    ))
                }
            </Card.Group >
        </div>
    )
}
