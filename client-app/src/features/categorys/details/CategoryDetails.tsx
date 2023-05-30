import React from "react";
import { Button } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import LoadingComponent from "../../../app/layout/LoadingComponent";




export default function CategoryDetails()
{
  const {categoryStore} =useStore();
  const {selectedCategory: category} =categoryStore;

  if (!category) return <LoadingComponent/>;

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
        <Button content="Cencle" onClick={categoryStore.cencleSelectedCategory}></Button>
        <Button content="Edit" onClick={()=>categoryStore.openForm(category.id)}></Button>
      </div>
    )
}
