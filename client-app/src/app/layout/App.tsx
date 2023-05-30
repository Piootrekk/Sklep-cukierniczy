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

  useEffect(()=>{
    categoryStore.LoadCategorys();
  }, [categoryStore])


  if(categoryStore.loadingInitial)
  {
    return(
      <LoadingComponent content='Loading app'></LoadingComponent>
    )
  }

  return (
    <Fragment>
    <NavBar/>
    <Container style={{marginTop:'7rem'}}>
      <CategoryDashboard/>
    </Container>
    </Fragment>
  );
}

export default observer(App);
