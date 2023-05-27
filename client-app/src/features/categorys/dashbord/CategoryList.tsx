import React from "react";
import { Category } from "../../../app/models/Category";
import { Button, Item, ItemDescription, ItemExtra, ItemGroup, Segment } from "semantic-ui-react";


interface Props {
    categories: Category[];
    selectCategory: (id: number) => void;
    openForm: (id:number) => void;
    closeForm: ()=>void;
}


  

export default function CategoryList({categories,selectCategory,openForm,closeForm}: Props)
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
                            <Item.Extra>
                                <Button onClick={event=>{selectCategory(category.id); closeForm()}} floated='right' content='View' color="blue"/>
                                <Button onClick={()=>openForm(category.id)} floated='left' content='Edit' color="blue"/>
                                <Button floated='left' content='Delete' color="red"/>
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>
    )
}
