import React, { Fragment, useEffect, useState } from 'react';
import './styles.css';
import { Button, Container, Header, List } from 'semantic-ui-react';
import { Category } from '../models/Category';
import { ServiceResponse } from '../models/ServiceResponse';
import NavBar from './components/NavBar';
import CategoryDashboard from '../../features/categorys/dashbord/CategoryDashboard';
import agent from '../api/agent';
import LoadingComponent from './LoadingComponent';
import { useStore} from '../stores/store';
import { observer } from 'mobx-react-lite';


function App() {

  const {categoryStore} =useStore()


  const [categories,setCategories]=useState<Category[]>([]);
  const [SelectedCategory,setSelectedCategory] = useState<Category|undefined>(undefined);
  const [editMode,setEditMode] =useState(false);
  const [loading, setLoading]=useState(true);
  const [submiting,setSubmiting]=useState(false)

  useEffect(()=>{
  agent.Categorys.list()
    .then(response=>
      {
        setCategories(response)
        setLoading(false)
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

  function HandleEditOrCreateCategory(category: Category)
  {
    setSubmiting(true);
    if(categories.find(x=>x.id===category.id))
    {
      agent.Categorys.update(category).then(()=>{setCategories([...categories.filter(x=>x.id!==category.id),category])})
      setSelectedCategory(category);
      setEditMode(false);
      setSubmiting(false);
      console.log (category);
    }
    else
    {
      agent.Categorys.create(category).then(()=>{setCategories([...categories,category]);
      setSelectedCategory(category)
      setEditMode(false);
      setSubmiting(false);})
    }
  }

  function HandleDeleteCategory(id: number)
  {
    setSubmiting(true);
    agent.Categorys.delete(id).then(()=>{
      setCategories([...categories.filter(x=>x.id!==id)]);
      setSubmiting(false);
    })
    
  }

  if(loading)
  {
    return(
      <LoadingComponent content='Loading app'></LoadingComponent>
    )
  }

  return (
    <Fragment>
    <NavBar openForm={HandleFormOpen}/>
    <Container style={{marginTop:'7rem'}}>
      <h2>{categoryStore.title}</h2>
      <Button content="MAke it loud" positive onClick={categoryStore.setTitle}/>
      <CategoryDashboard categories={categories}
      selectedCategory = {SelectedCategory}
      selectCategory = {HandleSelectCategory}
      cancelSelectCategory={handleCansleSelectCategory}
      editMode={editMode}
      openForm={HandleFormOpen}
      closeForm={HandleFormClose}
      createOrEdit={HandleEditOrCreateCategory}
      deleteCategory={HandleDeleteCategory}
      submiting={submiting}
      />
    </Container>
    </Fragment>
  );
}

export default observer(App);
