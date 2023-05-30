import React from "react";
import { Category } from "../../../app/models/Category";
import { Button, Item, ItemDescription, ItemExtra, ItemGroup, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";





export default observer (function CategoryList()
{

    const {categoryStore} = useStore();
    const {deleteCategory,categorys,loading} = categoryStore;

    return(
        <Segment>
            <Item.Group divided>
                {categorys.map(category=>(
                    <Item key={category.id}>
                        <Item.Content>
                            <Item.Header as='a' > {category.name} </Item.Header>
                            <ItemDescription>
                                <div>Is Active: {category.isActive ? 'Tak' : 'Nie'}</div>
                                <div>Is Deleted: {category.isDeleted ? 'Tak' : 'Nie'}</div>
                            </ItemDescription>
                            <Item.Extra>
                                <Button onClick={event=>{categoryStore.selectCategory(category.id); categoryStore.closeForm()}} floated='right' content='View' color="blue"/>
                                <Button onClick={()=>categoryStore.openForm(category.id)} floated='left' content='Edit' color="blue"/>
                                <Button loading={loading} onClick={()=>deleteCategory(category.id)} floated='left' content='Delete' color="red"/>
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>
    )
})
