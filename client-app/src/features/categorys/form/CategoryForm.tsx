import React, { ChangeEvent, useState } from "react";
import { Category } from "../../../app/models/Category";
import { Button, Form, Segment } from "semantic-ui-react";


interface Props
{
  category: Category|undefined;
  closeForm:()=>void;
  createOrEdit: (category: Category)=>void;
  submiting: boolean
}

export default function CategoryForm({category: selectedCategory,closeForm,createOrEdit,submiting}:Props)
{

  const initialState = selectedCategory ?? {
    id: 0,
    name: '',
    isActive: true,
    isDeleted: false
  }

  const [category,setCategory]=useState(initialState);

  function HandleSubmit()
  {
    createOrEdit(category);
  }

  function HandleImputchange(event: ChangeEvent<HTMLInputElement>)
  {
    const { name, value, type, checked } = event.target;
    
    if (type === "checkbox") {
      setCategory({ ...category, [name]: checked });
      console.log(category)
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
  <Button loading={submiting} className="ui inverted primary button" type='submit'>Submit</Button>
  <button className="ui inverted orange button" onClick={()=>closeForm()} type='button' >Cencle</button>
</form>
        </Segment>
    )
}
