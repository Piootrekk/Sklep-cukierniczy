import React from 'react';
import { Controller } from 'react-hook-form';

interface Option {
  id: number;
  name: string;
  isActive: boolean;
  isDeleted: boolean;
}

interface SelectProps {
  options: Option[];
  control: any;
  name: string;
  required?: boolean;
  error?: string;
}

const Select: React.FC<SelectProps> = ({
  options,
  control,
  name,
  required = false,
  error,
}) => {
  return (
    <div>
      <label htmlFor={name}>Kategoria:</label>
      <Controller
        control={control}
        name={name}
        rules={{ required: required }}
        render={({ field }) => (
          <select {...field} id={name}>
            <option value="">Wybierz kategorie</option>
            {options.map((option) => (
              <option key={option.id} value={option.id}>
                {option.name}
              </option>
            ))}
          </select>
        )}
      />
      {error && <span>{error}</span>}
    </div>
  );
};

export default Select;