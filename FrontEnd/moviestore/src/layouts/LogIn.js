import React from 'react';
import { Menu, Dropdown, Image } from 'semantic-ui-react';

export default function LogIn({ logOut }) {
    return (
        <div>
            <Menu.Item>
                <Image avatar spaced="right" src="https://avatars.githubusercontent.com/u/84242220?v=4" />
                <Dropdown pointing="top right" text="Akif">
                    <Dropdown.Menu>
                        <Dropdown.Item text="Bilgilerim" icon="info" />
                        <Dropdown.Item onClick={logOut} text="Çıkış Yap" icon="sign-out" />
                    </Dropdown.Menu>
                </Dropdown>
            </Menu.Item>
        </div>
    )
}
