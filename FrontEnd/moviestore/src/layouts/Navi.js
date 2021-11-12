import React, { useState } from 'react';
import CartSummary from './CartSummary';
import LogIn from './LogIn';
import LogOut from './LogOut';
import { Menu, Container } from 'semantic-ui-react';
import { NavLink } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';

export default function Navi() {

    const [isAuthenticated, setIsAuthenticated] = useState(false);
    const history = useNavigate();

    function handleLogOut() {
        setIsAuthenticated(false)
        history("/")
    }

    function handleLogIn() {
        setIsAuthenticated(true)
    }

    return (
        <div >
            <Menu inverted >
                <Container>
                    <Menu.Item name='home' as={NavLink} to={"/"} />
                    <Menu.Item name='messages' />
                    <Menu.Menu position='right'>
                        <CartSummary />
                        {isAuthenticated ? <LogIn logOut={handleLogOut} /> : <LogOut logIn={handleLogIn} />}
                    </Menu.Menu>
                </Container>
            </Menu>
        </div >
    )
}
