import { forwardRef } from 'react';
import { Controller } from 'react-hook-form';
import { MenuItem, Select as MuiSelect, SelectChangeEvent } from '@mui/material';

interface Option {
  id: string;
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
  categoryId: string;
  setCategoryId(e: SelectChangeEvent): void;
}

const Select = forwardRef<HTMLSelectElement, SelectProps>(
    ({ options, control, name, required = false, error, setCategoryId, categoryId }, ref) => {
      return (
        <div>
          <label htmlFor={name}>Kategoria:</label>
          <Controller
            control={control}
            name={name}
            rules={{ required: required }}
            render={({ field }) => (
              <MuiSelect
              placeholder='Wybierz kategorię'
              fullWidth
              id={name}
              {...field}
              ref={ref}
              value={categoryId} // Użyj wartości kontrolowanej
              onChange={setCategoryId} // Aktualizuj wartość kontrolowaną
              >
                {options.map((option) => (
                  <MenuItem key={option.id} value={option.id}>
                    {option.name}
                  </MenuItem>
                ))}
              </MuiSelect>
            )}
          />
          {error && <span>{error}</span>}
        </div>
      );
    }
  );

export default Select;