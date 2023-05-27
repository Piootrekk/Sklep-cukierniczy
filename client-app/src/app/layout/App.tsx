import React, { Fragment, useEffect, useState } from 'react';
import logo from './logo.svg';
import './styles.css';
import axios from 'axios';
import { Button, Container, Header, List } from 'semantic-ui-react';
import { Category } from '../models/Category';
import { Role } from '../models/Role';
import { ServiceResponse } from '../models/ServiceResponse';
import NavBar from './components/NavBar';
import CategoryDashboard from '../../features/categorys/dashbord/CategoryDashboard';


function App() {
  const [categories,setRoles]=useState<Category[]>([]);
  const [SelectedCategory,setSelectedCategory] = useState<Category|undefined>(undefined);
  const [editMode,setEditMode] =useState(false);

  useEffect(()=>{
    axios.get<ServiceResponse>('http://localhost:5003/api/categorys/getcategorys')
    .then(response=>
      {
        setRoles(response.data.value)
      })
  }, [])

  function HandleSelectCategory(id: number) {
    setSelectedCategory(categories.find(x=>x.id===id));
  }

  function handleCansleSelectCategory()
  {
    setSelectedCategory(undefined);
  }

  function HandleFormOpen(id?: number)
  {
    id ? HandleSelectCategory(id): handleCansleSelectCategory();
    setEditMode(true);
  }

  function HandleFormClose()
  {
    setEditMode(false);
  }
  return (
    <Fragment>
    <NavBar openForm={HandleFormOpen}/>
    <Container style={{marginTop:'7rem'}}>
      <CategoryDashboard categories={categories}
      selectedCategory = {SelectedCategory}
      selectCategory = {HandleSelectCategory}
      cancelSelectCategory={handleCansleSelectCategory}
      editMode={editMode}
      openForm={HandleFormOpen}
      closeForm={HandleFormClose}
      />
    </Container>
    </Fragment>
  );
}

export default App;
