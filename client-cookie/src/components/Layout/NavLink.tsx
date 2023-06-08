import classes from "./HeaderCart.module.css";


const NavLink = (props: { onClick: () => void}) => {
  return (
    <button className={classes.button} onClick={props.onClick}>
      <span>Konfigurator</span>
    </button>
  );
};

export default NavLink;