import React from 'react'
import { NavLink } from 'react-router-dom';
import { Dropdown, Label } from 'semantic-ui-react';
import { useSelector } from 'react-redux';

export default function CartSummary() {

    const { cartItems } = useSelector(state => state.cart)

    return (
        <Dropdown item text='Sepetiniz'>
            <Dropdown.Menu>
                {
                    cartItems.map((cartItem) => (
                        <Dropdown.Item position="left">
                            {cartItem.movie.title}
                            <Label color="blue" size="mini" circular>
                                {cartItem.quantity}
                            </Label>
                        </Dropdown.Item>
                    ))
                }

                <Dropdown.Divider />
                <Dropdown.Item as={NavLink} to={"/orders"}>Sepete Git</Dropdown.Item>
            </Dropdown.Menu>
        </Dropdown>
    )
}
