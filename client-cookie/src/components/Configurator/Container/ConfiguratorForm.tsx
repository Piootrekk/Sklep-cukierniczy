import React, { useContext, useState } from 'react';
import { useForm, Controller } from 'react-hook-form';
import { CakeContext, Ingredient } from "../../../storage/CustomCakeCont";
import Select from './Select';
import { CartContext, CartReturn } from '../../../storage/CartProvider';
import { Box, Button, Grid, SelectChangeEvent, TextField } from '@mui/material';
import { v4 as uuidv4 } from 'uuid';

export interface Categories {
    id: string,
    name: string,
    isActive: boolean,
    isDeleted: boolean
}
const MyForm: React.FC<{ categories: Categories[] }> = ({ categories }) => {
    const { control, handleSubmit, formState: { errors } } = useForm<Ingredient>();
    const cakeContext = useContext(CakeContext);
    const cartContext = useContext(CartContext);
    const [categoryId, setSelectedValue] = useState('');
    const setCategoryId = (e: SelectChangeEvent) => {
        setSelectedValue(e.target.value);
    }
    const cartItemAddHandler = (item: Ingredient) => {
        (cartContext as CartReturn).addItem({ ...item, amountInStock: 1 });
    };
    const onSubmit = (data: Ingredient) => {
        cartItemAddHandler({
            id: uuidv4(),
            name: data.name,
            description: data.description,
            priceBrutto: Number(data.priceBrutto),
            amountInStock: Number(data.amountInStock),
            categoryId: Number(categoryId),
            configurationPositionId: 4,
            images: [],
            isActive: true,
            isIngredient: false,
            uid: uuidv4()
        })
    };

    if (!cakeContext) {
        return null;
    }
    return (
        <Box sx={{ width: '100%' }}>
            <form onSubmit={handleSubmit(onSubmit)}>
                <Grid container spacing={2}>
                    <Grid item xs={6}>
                        <label htmlFor="name">Nazwa:</label>
                        <Controller
                            control={control}
                            name="name"
                            rules={{ required: true }}
                            render={({ field }) => <TextField fullWidth type="text" id="name" {...field} />}
                        />
                        {errors.name && <span style={{ color: 'red' }}>To pole jest wymagane!</span>}
                    </Grid>

                    <Grid item xs={6}>
                        <label htmlFor="description">Opis:</label>
                        <Controller
                            control={control}
                            name="description"
                            rules={{ required: true }}
                            render={({ field }) => <TextField fullWidth type="text" id="description" {...field} />}
                        />
                        {errors.description && <span style={{ color: 'red' }}>To pole jest wymagane!</span>}
                    </Grid>

                    <Grid item xs={6}>
                        <label htmlFor="priceBrutto">Cena:</label>
                        <Controller
                            control={control}
                            name="priceBrutto"
                            rules={{ required: true }}
                            render={({ field }) => <TextField fullWidth type="number" id="priceBrutto" {...field} />}
                        />
                        {errors.priceBrutto && <span style={{ color: 'red' }}>To pole jest wymagane!</span>}
                    </Grid>
                    <Grid item xs={6}>
                        <Select categoryId={categoryId} setCategoryId={e => setCategoryId(e)} control={control} name='categoryId' options={categories} />
                    </Grid>
                    <Grid item style={{ paddingLeft: 16 }} xs={6}>
                        Lista składników:
                        <ul>
                            {cakeContext?.cake.ingredients.map(i => (
                                <li key={uuidv4()}>{i.name}</li>
                            ))}
                        </ul>
                    </Grid>
                    <Button
                        type="submit"
                        fullWidth
                        variant="contained"
                        style={{ background: '#8a2b06' }}
                        sx={{ mt: 3, mb: 2 }}
                    >
                        Dodaj do koszyka!
                    </Button>
                </Grid>
            </form>
        </Box>
    );
};

export default MyForm;