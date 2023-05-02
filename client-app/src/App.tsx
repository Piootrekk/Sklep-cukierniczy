import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { Button, Header, List } from 'semantic-ui-react';

function App() {
  const [roles,setRoles]=useState([]);

  useEffect(()=>{
    axios.get('http://localhost:5003/api/autentication/getallroles')
    .then(response=>
      {
        console.log(response)
        setRoles(response.data.value)
      })
  }, [])

  return (
    <div>
     <Header
    as='h2'
    icon='users'
    content='Account Settings'
    />
        <List>
          {roles.map((role:any) => (
              <List.Item key={role.id}>
                    {role.name}
              </List.Item>
              ))}
        </List>
        <Button content = "Test"/>
    </div>
  );
}

export default App;
