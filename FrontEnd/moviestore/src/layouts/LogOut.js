import React from 'react';
import { Button, Menu } from 'semantic-ui-react';

export default function LogOut({ logIn }) {
    return (
        <div>
            <Menu.Menu position="right">
                <Menu.Item >
                    <Button negative>Kayıt Ol</Button>
                </Menu.Item>
                <Menu.Item >
                    <Button onClick={logIn} primary>Giriş Yap</Button>
                </Menu.Item>
            </Menu.Menu>

        </div>
    )
}
