import React from "react";
import { Category } from "../../../app/models/Category";
import { Button } from "semantic-ui-react";

interface Props {
    category: Category;
    cancelSelectCategory: () =>void;
    openForm: (id:number) => void;
}



export default function CategoryDetails({category,cancelSelectCategory,openForm}: Props)
{
    return(
        <div className="ui card">
        <div className="content">
          <a className="header">{category.id}</a>
          <div className="meta">
            <span className="date">{category.name}</span>
          </div>
          <div className="description">
          <b>Is Active: {category.isActive ? 'Tak' : 'Nie'}</b>
          <b>Is Deleted: {category.isDeleted ? 'Tak' : 'Nie'}</b>
          </div>
        </div>
        <Button content="Cencle" onClick={cancelSelectCategory}></Button>
        <Button content="Edit" onClick={()=>openForm(category.id)}></Button>
      </div>
    )
}
