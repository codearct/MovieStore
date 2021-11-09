import React from 'react';
import Categories from './Categories';
import MovieList from '../pages/MovieList';
import { Grid } from 'semantic-ui-react';

export default function Dashboard() {
    return (
        <div>
            <Grid>
                <Grid.Row>
                    <Grid.Column width={4}>
                        <Categories />
                    </Grid.Column>
                    <Grid.Column width={12}>
                        <MovieList />
                    </Grid.Column>
                </Grid.Row>
            </Grid>
        </div>
    )
}
