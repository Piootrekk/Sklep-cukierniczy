import React from "react";
import { Button, Container, Menu, MenuItem } from "semantic-ui-react";
import logo from "../assets/ciastko___/ciastko_napis.png";
import classes from'./NavBar.module.css';

interface Props
{
  openForm:()=>void;
}


export default function NavBar({openForm}:Props)
{
    return(
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item as="div" className={classes.header}>
                    <img src={logo} className={classes.imageLogo}/>
                    <h1>ZaczarowanaCukiernia</h1>
                </Menu.Item>
                <Menu.Item as="div" name="Categories" className={classes.div}/>
                <Menu.Item as="div">
                    <Button onClick={()=>openForm()} positive content='Create Role'/>
                </Menu.Item>
            </Container>
        </Menu>
    )
}
