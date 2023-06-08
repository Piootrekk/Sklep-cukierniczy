import classes from "./HeaderCart.module.css";


const NavLink = (props: { onClick: () => void, name: string}) => {
  return (
    <button className={classes.button} onClick={props.onClick}>
      <span>{props.name}</span>
    </button>
  );
};

export default NavLink;