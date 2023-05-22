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

  useEffect(()=>{
    axios.get<ServiceResponse>('http://localhost:5003/api/categorys/getcategorys')
    .then(response=>
      {
        setRoles(response.data.value)
      })
  }, [])

  return (
    <Fragment>
    <NavBar/>
    <Container style={{marginTop:'7rem'}}>
      <CategoryDashboard categories={categories}/>
    </Container>
    </Fragment>
  );
}

export default App;
