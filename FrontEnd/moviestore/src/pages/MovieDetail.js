import React from 'react'
import { useParams } from 'react-router'
import { Card, Image, Button } from 'semantic-ui-react';
import MovieService from '../services/movieService';
import { useState, useEffect } from "react";

export default function MovieDetail() {
    let { id } = useParams();

    const [movie, setMovie] = useState({});


    useEffect(() => {
        let movieService = new MovieService();
        movieService.getMovieById(id)
            .then(result => setMovie(result.data))
    }, [])


    return (
        <div>
            <Card.Group>
                <Card fluid>
                    <Card.Content>
                        <Image
                            floated='left'
                            size='small'
                            src={`https://picsum.photos/id/${id}/100`}
                        />
                        <Card.Header>{movie.title}</Card.Header>
                        <Card.Meta>{movie.releaseDate}</Card.Meta>
                        <Card.Meta>{movie.genre}</Card.Meta>
                        <Card.Meta>{movie.director}</Card.Meta>
                        <Card.Meta>{movie.performers}</Card.Meta>
                    </Card.Content>
                    <Card.Content extra>
                        <div className='ui two buttons'>
                            <Button basic color='green'>
                                Approve
                            </Button>
                            <Button basic color='red'>
                                Decline
                            </Button>
                        </div>
                    </Card.Content>
                </Card>
            </Card.Group>
        </div >
    )
}
