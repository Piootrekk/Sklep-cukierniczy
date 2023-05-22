import React from "react";
import { Category } from "../../../app/models/Category";
import { Button, Item, ItemDescription, ItemExtra, ItemGroup, Segment } from "semantic-ui-react";


interface Props {
    categories: Category[];
}


export default function CategoryList({categories}: Props)
{
    return(
        <Segment>
            <Item.Group divided>
                {categories.map(category=>(
                    <Item key={category.id}>
                        <Item.Content>
                            <Item.Header as='a' > {category.name} </Item.Header>
                            <ItemDescription>
                                <div>Is Active: {category.isActive ? 'Tak' : 'Nie'}</div>
                                <div>Is Deleted: {category.isDeleted ? 'Tak' : 'Nie'}</div>
                            </ItemDescription>
                            <ItemExtra>
                                <Button floated='right' content='Edit' color="blue"/>
                                <Button floated='left' content='Delete' color="red"/>
                            </ItemExtra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>
    )
}
