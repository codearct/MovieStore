import React from 'react';
import Categories from './Categories';
import MovieList from '../pages/MovieList';
import { Grid } from 'semantic-ui-react';
import { Route, Routes } from 'react-router';
import MovieDetail from '../pages/MovieDetail';
import OrderDetail from '../pages/OrderDetail';
import { ToastContainer } from 'react-toastify';

export default function Dashboard() {
    return (
        <div>
            <ToastContainer position="bottom-center" />
            <Grid>
                <Grid.Row>
                    <Grid.Column width={4}>
                        <Categories />
                    </Grid.Column>
                    <Grid.Column width={12}>
                        <Routes>
                            <Route exact path="/" element={<MovieList />} />
                            <Route path="/movies" element={<MovieList />} />
                            <Route path="/movies/:id" element={<MovieDetail />} />
                            <Route path="/orders" element={<OrderDetail />} />
                        </Routes>
                    </Grid.Column>
                </Grid.Row>
            </Grid>
        </div>
    )
}
