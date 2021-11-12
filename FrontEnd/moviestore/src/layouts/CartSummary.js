import React from 'react'
import { NavLink } from 'react-router-dom';
import { Dropdown } from 'semantic-ui-react';

export default function CartSummary() {
    return (
        <Dropdown item text='Sepet'>
            <Dropdown.Menu>
                <Dropdown.Item>Movie1</Dropdown.Item>
                <Dropdown.Item>movie2</Dropdown.Item>
                <Dropdown.Item>movie3</Dropdown.Item>
                <Dropdown.Divider />
                <Dropdown.Item as={NavLink} to={"/orders"}>Sepete Git</Dropdown.Item>
            </Dropdown.Menu>
        </Dropdown>
    )
}
