import React, { useRef, useState } from "react";

import classes from "./Form.module.css";
import Input from "../../UI/Input";

interface Props {
  id: string;
  addItem: (item: number) => void;
}

const FormItem: React.FC<Props> = (props) => {
  const amountInputRef = useRef<HTMLInputElement>(null);
  const [amountIsValid, setAmountIsValid] = useState<boolean>(true);

  const submitHandler = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const enteredAmount = amountInputRef.current!.value;
    const enteredAmountNumber = +enteredAmount;

    if (
      enteredAmount.trim().length === 0 ||
      enteredAmountNumber < 1 ||
      enteredAmountNumber > 10
    ) {
      setAmountIsValid(false);
      return;
    }
    props.addItem(enteredAmountNumber);
  };

  return (
    <form className={classes.form} onSubmit={submitHandler}>
      <Input
        ref={amountInputRef}
        label="Ilość: "
        input={{
          id: "amount_" + props.id,
          type: "number",
          min: "1",
          max: "10",
          step: "1",
          defaultValue: "1",
        }}
      />
      <button>Dodaj</button>
      {!amountIsValid && <p>Proszę wprowadzić poprawną ilość (1-10).</p>}
    </form>
  );
};

export default FormItem;