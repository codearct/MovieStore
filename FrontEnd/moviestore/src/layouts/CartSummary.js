import React from 'react'
import { NavLink } from 'react-router-dom';
import { Dropdown } from 'semantic-ui-react';

export default function CartSummary() {
    return (
        <Dropdown item text='Sepetiniz' fluid>
            <Dropdown.Menu>
                <Dropdown.Item>Pulp Fiction</Dropdown.Item>
                <Dropdown.Item>Catch Me If You Can</Dropdown.Item>
                <Dropdown.Item>Fight Club</Dropdown.Item>
                <Dropdown.Divider />
                <Dropdown.Item as={NavLink} to={"/orders"}>Sepete Git</Dropdown.Item>
            </Dropdown.Menu>
        </Dropdown>
    )
}
