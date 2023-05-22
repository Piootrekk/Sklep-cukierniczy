import React from "react";
import Modal from "../UI/Model";
import classes from "./UserMenu.module.css";

const UserMenu = (props) => {
    return (
        <Modal onClose={props.onClose}>
        <div className={classes.total}>
            <h2>Ustawienia Użytkownika</h2>
            <span>W trakcie budowy</span>
            <span>YeeMEN</span>
        </div>
        </Modal>
    );
    }

export default UserMenu;