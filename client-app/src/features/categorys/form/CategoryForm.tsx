import React from "react";
import { Category } from "../../../app/models/Category";
import { Button, Form, Segment } from "semantic-ui-react";


interface Props
{
  category: Category|undefined;
  closeForm:()=>void;
}

export default function CategoryForm({category,closeForm}:Props)
{
    return(
        <Segment>
           <form className="ui form">
  <div className="field">
    <label>Name</label>
    <input type="text" name="name" placeholder="Name"/>
  </div>
  <div className="ui segment">
    <div className="field">
      <div className="ui toggle checkbox">
        <input type="checkbox" name="IsActive" />
        <label>IsActive</label>
      </div>
    </div>
  </div>
  <button className="ui inverted primary button" type="button">Submit</button>
  <button className="ui inverted orange button" onClick={()=>closeForm()} type='button'>Cencle</button>
</form>
        </Segment>
    )
}
