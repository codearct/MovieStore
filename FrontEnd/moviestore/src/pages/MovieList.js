import React from 'react';
import { Card, Icon, Image } from 'semantic-ui-react';

export default function MovieList() {
    return (
        <div>
            <Card.Group itemsPerRow={4}>
                <Card>
                    <Image src='https://picsum.photos/id/11/200/300' wrapped ui={false} />
                    <Card.Content>
                        <Card.Header>Daniel</Card.Header>
                        <Card.Meta>Joined in 2016</Card.Meta>
                        <Card.Description>
                            Daniel is a comedian living in Nashville.
                        </Card.Description>
                    </Card.Content>
                    <Card.Content extra>
                        <a>
                            <Icon name='user' />
                            10 Friends
                        </a>
                    </Card.Content>
                </Card>

                <Card>
                    <Image src='https://picsum.photos/id/22/200/300' wrapped ui={false} />
                    <Card.Content>
                        <Card.Header>Daniel</Card.Header>
                        <Card.Meta>Joined in 2016</Card.Meta>
                        <Card.Description>
                            Daniel is a comedian living in Nashville.
                        </Card.Description>
                    </Card.Content>
                    <Card.Content extra>
                        <a>
                            <Icon name='user' />
                            10 Friends
                        </a>
                    </Card.Content>
                </Card>

                <Card>
                    <Image src='https://picsum.photos/id/33/200/300' wrapped ui={false} />
                    <Card.Content>
                        <Card.Header>Daniel</Card.Header>
                        <Card.Meta>Joined in 2016</Card.Meta>
                        <Card.Description>
                            Daniel is a comedian living in Nashville.
                        </Card.Description>
                    </Card.Content>
                    <Card.Content extra>
                        <a>
                            <Icon name='user' />
                            10 Friends
                        </a>
                    </Card.Content>
                </Card>

                <Card>
                    <Image src='https://picsum.photos/id/44/200/300' wrapped ui={false} />
                    <Card.Content>
                        <Card.Header>Daniel</Card.Header>
                        <Card.Meta>Joined in 2016</Card.Meta>
                        <Card.Description>
                            Daniel is a comedian living in Nashville.
                        </Card.Description>
                    </Card.Content>
                    <Card.Content extra>
                        <a>
                            <Icon name='user' />
                            10 Friends
                        </a>
                    </Card.Content>
                </Card>

                <Card>
                    <Image src='https://picsum.photos/id/55/200/300' wrapped ui={false} />
                    <Card.Content>
                        <Card.Header>Daniel</Card.Header>
                        <Card.Meta>Joined in 2016</Card.Meta>
                        <Card.Description>
                            Daniel is a comedian living in Nashville.
                        </Card.Description>
                    </Card.Content>
                    <Card.Content extra>
                        <a>
                            <Icon name='user' />
                            10 Friends
                        </a>
                    </Card.Content>
                </Card>
            </Card.Group >
        </div>
    )
}
