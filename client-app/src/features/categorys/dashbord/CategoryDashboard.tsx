import React from "react";
import { Grid, GridColumn, List } from "semantic-ui-react";
import { Category } from "../../../app/models/Category";
import CategoryList from "./CategoryList";

interface Props {
    categories: Category[];
}


export default function CategoryDashboard({categories}: Props)
{
    return(
        <Grid>
            <GridColumn width={10}>
               <CategoryList categories={categories}/>
            </GridColumn>
        </Grid>
    )
}
