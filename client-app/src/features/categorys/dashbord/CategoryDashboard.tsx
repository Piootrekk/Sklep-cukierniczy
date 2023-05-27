import React from "react";
import { Grid, GridColumn, List } from "semantic-ui-react";
import { Category } from "../../../app/models/Category";
import CategoryList from "./CategoryList";
import CategoryDetails from "../details/CategoryDetails";
import CategoryForm from "../form/CategoryForm";

interface Props {
    categories: Category[];
    selectedCategory: Category | undefined;
    selectCategory: (id: number) => void;
    cancelSelectCategory: () =>void;
    editMode: boolean;
    openForm:(id?: number)=> void;
    closeForm:() => void;
}


export default function CategoryDashboard({categories,selectedCategory,selectCategory,cancelSelectCategory,editMode,openForm,closeForm}: Props)
{
    return(
        <Grid>
            <GridColumn width={10}>
               <CategoryList 
                categories={categories}
                selectCategory={selectCategory}
                openForm={openForm}
                closeForm={closeForm}/>
            </GridColumn>
            <GridColumn width={6}>
                {selectedCategory && !editMode &&
                <CategoryDetails 
                category={selectedCategory} 
                cancelSelectCategory={cancelSelectCategory}
                openForm={openForm} />}
                {editMode &&
                <CategoryForm closeForm={closeForm} category={selectedCategory}/>}
            </GridColumn>
        </Grid>
    )
}
