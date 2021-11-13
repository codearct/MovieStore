import React from 'react';
import { useState, useEffect } from "react";
import { Card, Image, Button } from 'semantic-ui-react';
import MovieService from '../services/movieService';
import { Link } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import { addToCart } from "../store/actions/cartActions";
import { toast } from 'react-toastify';

export default function MovieList() {

    const dispatch = useDispatch()

    const [movies, setMovies] = useState([]);

    useEffect(() => {
        let movieService = new MovieService();
        movieService.getMovies()
            .then(result => setMovies(result.data))
    }, [])

    const handleAddToCart = (movie) => {
        dispatch(addToCart(movie))
        toast.success(`${movie.title} sepete eklendi!`)
    }

    return (
        <div>
            <Card.Group itemsPerRow={4}>
                {
                    movies.map(movie => (
                        <Card key={movie.id} >
                            <Image src={`https://picsum.photos/id/${movie.id}/100`} wrapped ui={false} />
                            <Card.Content>
                                <Card.Header>
                                    <Link to={`/movies/${movie.id}`}>{movie.title}</Link>
                                </Card.Header>
                            </Card.Content>
                            <Card.Content>
                                <Button onClick={() => handleAddToCart(movie)} negative fluid>
                                    Sepete Ekle
                                </Button>
                            </Card.Content>
                        </Card>
                    ))
                }
            </Card.Group >
        </div>
    )
}
