import React from "react";
import { Grid, GridColumn, List } from "semantic-ui-react";
import { Category } from "../../../app/models/Category";
import CategoryList from "./CategoryList";
import CategoryDetails from "../details/CategoryDetails";
import CategoryForm from "../form/CategoryForm";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";




export default observer (function CategoryDashboard()
{
    const {categoryStore} = useStore();

    return(
        <Grid>
            <GridColumn width={10}>
               <CategoryList/>
            </GridColumn>
            <GridColumn width={6}>
                {categoryStore.selectedCategory && !categoryStore.editMode &&
                <CategoryDetails/>}
                {categoryStore.editMode &&
                <CategoryForm/>}
            </GridColumn>
        </Grid>
    )
})
