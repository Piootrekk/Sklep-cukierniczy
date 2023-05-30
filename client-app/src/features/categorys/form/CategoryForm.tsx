import React, { ChangeEvent, useState } from "react";
import { Category } from "../../../app/models/Category";
import { Button, Form, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import { observable } from "mobx";
import { observer } from "mobx-react-lite";


export default observer (function CategoryForm()
{

  const {categoryStore} =useStore();
  const {selectedCategory,createCategory,updateCategory,loading} = categoryStore;

  const initialState = selectedCategory ?? {
    id: 0,
    name: '',
    isActive: true,
    isDeleted: false
  }

  const [category,setCategory]=useState(initialState);

  function HandleSubmit()
  {
    category.id ? updateCategory(category) : createCategory(category);
  }

  function HandleImputchange(event: ChangeEvent<HTMLInputElement>)
  {
    const { name, value, type, checked } = event.target;
    
    if (type === "checkbox") {
      setCategory({ ...category, [name]: checked });
    } else {
    setCategory({ ...category, [name]: value });
    }
  }


    return(
        <Segment>
           <form className="ui form" onSubmit={HandleSubmit} autoComplete="off">
  <div className="field">
    <label>Name</label>
    <input type="text" value={category.name} name="name" placeholder="Name" onChange={HandleImputchange}/>
  </div>
  <div className="ui segment">
    <div className="field">
      <div className="ui toggle checkbox">
        <input type="checkbox" name="isActive" checked={category.isActive}  onChange={HandleImputchange} />
        <label>IsActive</label>
      </div>
    </div>
  </div>
  <Button loading={loading} className="ui inverted primary button" type='submit'>Submit</Button>
  <button className="ui inverted orange button" onClick={()=>categoryStore.closeForm()} type='button' >Cencle</button>
</form>
        </Segment>
    )
})
